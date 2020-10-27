using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    internal class ExceptionDetailControl : UserControl
    {
        #region Design Code
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
            this.label2 = new Krypton.Toolkit.KryptonLabel();
            this.txtExceptionTabStackTrace = new Krypton.Toolkit.KryptonTextBox();
            this.label1 = new Krypton.Toolkit.KryptonLabel();
            this.txtExceptionTabMessage = new Krypton.Toolkit.KryptonTextBox();
            this.listviewExceptions = new System.Windows.Forms.ListView();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 33;
            this.label2.Values.Text = "Stack Trace";
            // 
            // txtExceptionTabStackTrace
            // 
            this.txtExceptionTabStackTrace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExceptionTabStackTrace.BackColor = System.Drawing.SystemColors.Window;
            this.txtExceptionTabStackTrace.Location = new System.Drawing.Point(13, 234);
            this.txtExceptionTabStackTrace.Multiline = true;
            this.txtExceptionTabStackTrace.Name = "txtExceptionTabStackTrace";
            this.txtExceptionTabStackTrace.ReadOnly = true;
            this.txtExceptionTabStackTrace.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExceptionTabStackTrace.Size = new System.Drawing.Size(598, 324);
            this.txtExceptionTabStackTrace.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 32;
            this.label1.Values.Text = "Message";
            // 
            // txtExceptionTabMessage
            // 
            this.txtExceptionTabMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExceptionTabMessage.BackColor = System.Drawing.SystemColors.Window;
            this.txtExceptionTabMessage.Location = new System.Drawing.Point(13, 156);
            this.txtExceptionTabMessage.Multiline = true;
            this.txtExceptionTabMessage.Name = "txtExceptionTabMessage";
            this.txtExceptionTabMessage.ReadOnly = true;
            this.txtExceptionTabMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExceptionTabMessage.Size = new System.Drawing.Size(598, 52);
            this.txtExceptionTabMessage.TabIndex = 30;
            // 
            // listviewExceptions
            // 
            this.listviewExceptions.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listviewExceptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listviewExceptions.FullRowSelect = true;
            this.listviewExceptions.HideSelection = false;
            this.listviewExceptions.HotTracking = true;
            this.listviewExceptions.HoverSelection = true;
            this.listviewExceptions.Location = new System.Drawing.Point(3, 3);
            this.listviewExceptions.Name = "listviewExceptions";
            this.listviewExceptions.Size = new System.Drawing.Size(608, 120);
            this.listviewExceptions.TabIndex = 29;
            this.listviewExceptions.UseCompatibleStateImageBehavior = false;
            this.listviewExceptions.View = System.Windows.Forms.View.Details;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.label2);
            this.kryptonPanel1.Controls.Add(this.label1);
            this.kryptonPanel1.Controls.Add(this.txtExceptionTabMessage);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(614, 561);
            this.kryptonPanel1.TabIndex = 34;
            // 
            // ExceptionDetailControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtExceptionTabStackTrace);
            this.Controls.Add(this.listviewExceptions);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "ExceptionDetailControl";
            this.Size = new System.Drawing.Size(614, 561);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KryptonLabel label2;
        private KryptonTextBox txtExceptionTabStackTrace;
        private KryptonLabel label1;
        private KryptonTextBox txtExceptionTabMessage;
        private KryptonPanel kryptonPanel1;
        private System.Windows.Forms.ListView listviewExceptions;
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

        //TODO this is duplicated almost entirely (without ListView) in ReportBuilder)
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