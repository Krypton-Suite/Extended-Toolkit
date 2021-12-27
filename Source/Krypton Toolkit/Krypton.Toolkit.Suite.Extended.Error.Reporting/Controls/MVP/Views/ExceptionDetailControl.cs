namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    internal partial class ExceptionDetailControl : UserControl
    {
        #region Designer Code
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExceptionDetailControl));
            this.label2 = new KryptonLabel();
            this.txtExceptionTabStackTrace = new KryptonTextBox();
            this.label1 = new KryptonLabel();
            this.txtExceptionTabMessage = new KryptonTextBox();
            this.listviewExceptions = new KryptonListView();
            this.SuspendLayout();
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtExceptionTabStackTrace
            // 
            resources.ApplyResources(this.txtExceptionTabStackTrace, "txtExceptionTabStackTrace");
            this.txtExceptionTabStackTrace.BackColor = System.Drawing.SystemColors.Window;
            this.txtExceptionTabStackTrace.Name = "txtExceptionTabStackTrace";
            this.txtExceptionTabStackTrace.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtExceptionTabMessage
            // 
            resources.ApplyResources(this.txtExceptionTabMessage, "txtExceptionTabMessage");
            this.txtExceptionTabMessage.BackColor = System.Drawing.SystemColors.Window;
            this.txtExceptionTabMessage.Name = "txtExceptionTabMessage";
            this.txtExceptionTabMessage.ReadOnly = true;
            // 
            // listviewExceptions
            // 
            resources.ApplyResources(this.listviewExceptions, "listviewExceptions");
            this.listviewExceptions.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listviewExceptions.FullRowSelect = true;
            this.listviewExceptions.HotTracking = true;
            this.listviewExceptions.HoverSelection = true;
            this.listviewExceptions.Name = "listviewExceptions";
            this.listviewExceptions.UseCompatibleStateImageBehavior = false;
            this.listviewExceptions.View = System.Windows.Forms.View.Details;
            // 
            // ExceptionDetailControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtExceptionTabStackTrace);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtExceptionTabMessage);
            this.Controls.Add(this.listviewExceptions);
            this.Name = "ExceptionDetailControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KryptonLabel label2;
        private KryptonTextBox txtExceptionTabStackTrace;
        private KryptonLabel label1;
        private KryptonTextBox txtExceptionTabMessage;
        private KryptonListView listviewExceptions;
        #endregion

        public ExceptionDetailControl()
        {
            InitializeComponent();

            WireUpEvents();
        }

        public void SetControlBackgrounds(Color color)
        {
            listviewExceptions.BackColor =
                txtExceptionTabMessage.BackColor =
                txtExceptionTabStackTrace.BackColor = color;
        }

        // Note: this is duplicated almost entirely (without ListView) in ReportBuilder)
        public void PopulateExceptionTab(Exception rootException)
        {
            TheException = rootException;
            listviewExceptions.Clear();
            listviewExceptions.Columns.Add("Level", 100, HorizontalAlignment.Left);
            listviewExceptions.Columns.Add("Exception Type", 150, HorizontalAlignment.Left);
            listviewExceptions.Columns.Add("Target Site / Method", 150, HorizontalAlignment.Left);

            var listViewItem = new ListViewItem
            {
                Text = "Top Level"
            };
            listViewItem.SubItems.Add(rootException.GetType().ToString());

            AddTargetSite(listViewItem, rootException);
            listViewItem.Tag = "0";
            listviewExceptions.Items.Add(listViewItem);
            listViewItem.Selected = true;

            int index = 0;
            Exception currentException = rootException;

            while (currentException.InnerException != null)
            {
                index++;
                currentException = currentException.InnerException;
                listViewItem = new ListViewItem
                {
                    Text = string.Format("Inner Exception {0}", index)
                };
                listViewItem.SubItems.Add(currentException.GetType().ToString());
                AddTargetSite(listViewItem, currentException);
                listViewItem.Tag = index.ToString();
                listviewExceptions.Items.Add(listViewItem);
            }

            txtExceptionTabStackTrace.Text = rootException.StackTrace;
            txtExceptionTabMessage.Text = rootException.Message;
        }

        private static void AddTargetSite(ListViewItem listViewItem, Exception exception)
        {   //TargetSite can be null (http://msdn.microsoft.com/en-us/library/system.exception.targetsite.aspx)
            if (exception.TargetSite != null)
            {
                listViewItem.SubItems.Add(exception.TargetSite.ToString());
            }
        }

        private void WireUpEvents()
        {
            listviewExceptions.SelectedIndexChanged += ExceptionsSelectedIndexChanged;
        }

        private void ExceptionsSelectedIndexChanged(object sender, EventArgs e)
        {
            var displayException = TheException;
            foreach (ListViewItem listViewItem in listviewExceptions.Items)
            {
                if (!listViewItem.Selected) continue;
                for (var count = 0; count < int.Parse(listViewItem.Tag.ToString()); count++)
                {
                    displayException = displayException?.InnerException;
                }
            }

            txtExceptionTabStackTrace.Text = string.Empty;
            txtExceptionTabMessage.Text = string.Empty;

            if (displayException == null)
            {
                displayException = TheException;
            }
            if (displayException == null)
            {
                return;
            }

            txtExceptionTabStackTrace.Text = displayException.StackTrace;
            txtExceptionTabMessage.Text = displayException.Message;
        }

        public Exception TheException { get; set; }
    }

}