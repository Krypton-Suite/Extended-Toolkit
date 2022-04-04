namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    internal partial class ExceptionDetailControl : UserControl
    {
#region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonTextBox ktxtStackTrace;
        private KryptonLabel kryptonLabel2;
        private KryptonTextBox ktxtExceptionTabMessage;
        private KryptonLabel kryptonLabel1;
        private KryptonListView klvExceptions;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.klvExceptions = new Krypton.Toolkit.KryptonListView();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtExceptionTabMessage = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtStackTrace = new Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.ktxtStackTrace);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Controls.Add(this.ktxtExceptionTabMessage);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Controls.Add(this.klvExceptions);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(614, 535);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // klvExceptions
            // 
            this.klvExceptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.klvExceptions.HideSelection = false;
            this.klvExceptions.ItemStyle = Krypton.Toolkit.ButtonStyle.ListItem;
            this.klvExceptions.Location = new System.Drawing.Point(4, 4);
            this.klvExceptions.Name = "klvExceptions";
            this.klvExceptions.OwnerDraw = true;
            this.klvExceptions.Size = new System.Drawing.Size(607, 120);
            this.klvExceptions.StateCommon.Item.Content.ShortText.MultiLine = Krypton.Toolkit.InheritBool.True;
            this.klvExceptions.StateCommon.Item.Content.ShortText.MultiLineH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klvExceptions.StateCommon.Item.Content.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klvExceptions.TabIndex = 0;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(4, 131);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(64, 20);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Message:";
            // 
            // ktxtExceptionTabMessage
            // 
            this.ktxtExceptionTabMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ktxtExceptionTabMessage.Location = new System.Drawing.Point(20, 158);
            this.ktxtExceptionTabMessage.Multiline = true;
            this.ktxtExceptionTabMessage.Name = "ktxtExceptionTabMessage";
            this.ktxtExceptionTabMessage.ReadOnly = true;
            this.ktxtExceptionTabMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ktxtExceptionTabMessage.Size = new System.Drawing.Size(591, 52);
            this.ktxtExceptionTabMessage.TabIndex = 2;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(4, 216);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(70, 20);
            this.kryptonLabel2.TabIndex = 3;
            this.kryptonLabel2.Values.Text = "Call Stack:";
            // 
            // ktxtStackTrace
            // 
            this.ktxtStackTrace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ktxtStackTrace.Location = new System.Drawing.Point(20, 243);
            this.ktxtStackTrace.Multiline = true;
            this.ktxtStackTrace.Name = "ktxtStackTrace";
            this.ktxtStackTrace.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ktxtStackTrace.Size = new System.Drawing.Size(591, 289);
            this.ktxtStackTrace.TabIndex = 4;
            // 
            // ExceptionDetailControl
            // 
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "ExceptionDetailControl";
            this.Size = new System.Drawing.Size(614, 535);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Property
        public Exception CapturedException { get; set; }
        #endregion

        #region Constructor

        public ExceptionDetailControl()
        {
            InitializeComponent();

            WireUpEvents();
        }
        #endregion

        #region Methods

        public void SetControlBackgrounds(string colour)
        {
            klvExceptions.StateCommon.Back.Color1 = ColorTranslator.FromHtml(colour);

            klvExceptions.StateCommon.Back.Color2 = ColorTranslator.FromHtml(colour);

            ktxtExceptionTabMessage.StateCommon.Back.Color1 = ColorTranslator.FromHtml(colour);

            ktxtStackTrace.StateCommon.Back.Color1 = ColorTranslator.FromHtml(colour);
        }

        public void PopulateExceptionTab(Exception rootException)
        {
            CapturedException = rootException;

            klvExceptions.Clear();

            klvExceptions.Columns.Add("Level", 100, HorizontalAlignment.Left);

            klvExceptions.Columns.Add("Exception Type", 150, HorizontalAlignment.Left);

            klvExceptions.Columns.Add("Target Site / Method", 150, HorizontalAlignment.Left);

            var lvi = new ListViewItem {Text = "Top Level"};

            lvi.SubItems.Add(rootException.GetType().ToString());

            AddTargetSite(lvi, rootException);

            lvi.Tag = "0";

            klvExceptions.Items.Add(lvi); 
                
            lvi.Selected = true;

            int index = 0;
            Exception currentException = rootException;

            while (currentException.InnerException != null)
            {
                index++;
                currentException = currentException.InnerException;
                lvi = new ListViewItem
                {
                    Text = $"Inner Exception {index}"
                };
                lvi.SubItems.Add(currentException.GetType().ToString());
                AddTargetSite(lvi, currentException);
                lvi.Tag = index.ToString();
                klvExceptions.Items.Add(lvi);
            }

            ktxtStackTrace.Text = rootException.StackTrace;
            ktxtExceptionTabMessage.Text = rootException.Message;
        }

        private static void AddTargetSite(ListViewItem lvi, Exception exception)
        {   //TargetSite can be null (http://msdn.microsoft.com/en-us/library/system.exception.targetsite.aspx)
            if (exception.TargetSite != null)
            {
                lvi.SubItems.Add(exception.TargetSite.ToString());
            }
        }

        private void WireUpEvents()
        {
            klvExceptions.SelectedIndexChanged += ExceptionsSelectedIndexChanged;
        }

        private void ExceptionsSelectedIndexChanged(object sender, EventArgs e)
        {
            var displayException = CapturedException;
            foreach (ListViewItem lvi in klvExceptions.Items)
            {
                if (!lvi.Selected) continue;
                for (var count = 0; count < int.Parse(lvi.Tag.ToString()); count++)
                {
                    displayException = displayException?.InnerException;
                }
            }

            ktxtStackTrace.Text = string.Empty;
            ktxtExceptionTabMessage.Text = string.Empty;

            if (displayException == null)
            {
                displayException = CapturedException;
            }
            if (displayException == null)
            {
                return;
            }

            ktxtStackTrace.Text = displayException.StackTrace;
            ktxtExceptionTabMessage.Text = displayException.Message;
        }

        #endregion
    }
}