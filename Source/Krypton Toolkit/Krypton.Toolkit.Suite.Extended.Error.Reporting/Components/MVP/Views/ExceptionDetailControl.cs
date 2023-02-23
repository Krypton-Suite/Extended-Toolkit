#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

// ReSharper disable InconsistentNaming
// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
#pragma warning disable CS8622, CS8604
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
            kryptonPanel1 = new KryptonPanel();
            klvExceptions = new KryptonListView();
            kryptonLabel1 = new KryptonLabel();
            ktxtExceptionTabMessage = new KryptonTextBox();
            kryptonLabel2 = new KryptonLabel();
            ktxtStackTrace = new KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(kryptonPanel1)).BeginInit();
            kryptonPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // kryptonPanel1
            // 
            kryptonPanel1.Controls.Add(ktxtStackTrace);
            kryptonPanel1.Controls.Add(kryptonLabel2);
            kryptonPanel1.Controls.Add(ktxtExceptionTabMessage);
            kryptonPanel1.Controls.Add(kryptonLabel1);
            kryptonPanel1.Controls.Add(klvExceptions);
            kryptonPanel1.Dock = DockStyle.Fill;
            kryptonPanel1.Location = new Point(0, 0);
            kryptonPanel1.Name = "kryptonPanel1";
            kryptonPanel1.Size = new Size(614, 535);
            kryptonPanel1.TabIndex = 0;
            // 
            // klvExceptions
            // 
            klvExceptions.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
            | AnchorStyles.Right)));
            klvExceptions.HideSelection = false;
            klvExceptions.ItemStyle = ButtonStyle.ListItem;
            klvExceptions.Location = new Point(4, 4);
            klvExceptions.Name = "klvExceptions";
            klvExceptions.OwnerDraw = true;
            klvExceptions.Size = new Size(607, 120);
            klvExceptions.StateCommon.Item.Content.ShortText.MultiLine = InheritBool.True;
            klvExceptions.StateCommon.Item.Content.ShortText.MultiLineH = PaletteRelativeAlign.Center;
            klvExceptions.StateCommon.Item.Content.ShortText.TextH = PaletteRelativeAlign.Center;
            klvExceptions.TabIndex = 0;
            // 
            // kryptonLabel1
            // 
            kryptonLabel1.LabelStyle = LabelStyle.BoldControl;
            kryptonLabel1.Location = new Point(4, 131);
            kryptonLabel1.Name = "kryptonLabel1";
            kryptonLabel1.Size = new Size(64, 20);
            kryptonLabel1.TabIndex = 1;
            kryptonLabel1.Values.Text = "Message:";
            // 
            // ktxtExceptionTabMessage
            // 
            ktxtExceptionTabMessage.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom)
            | AnchorStyles.Left)
            | AnchorStyles.Right)));
            ktxtExceptionTabMessage.Location = new Point(20, 158);
            ktxtExceptionTabMessage.Multiline = true;
            ktxtExceptionTabMessage.Name = "ktxtExceptionTabMessage";
            ktxtExceptionTabMessage.ReadOnly = true;
            ktxtExceptionTabMessage.ScrollBars = ScrollBars.Vertical;
            ktxtExceptionTabMessage.Size = new Size(591, 52);
            ktxtExceptionTabMessage.TabIndex = 2;
            // 
            // kryptonLabel2
            // 
            kryptonLabel2.LabelStyle = LabelStyle.BoldControl;
            kryptonLabel2.Location = new Point(4, 216);
            kryptonLabel2.Name = "kryptonLabel2";
            kryptonLabel2.Size = new Size(70, 20);
            kryptonLabel2.TabIndex = 3;
            kryptonLabel2.Values.Text = "Call Stack:";
            // 
            // ktxtStackTrace
            // 
            ktxtStackTrace.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom)
            | AnchorStyles.Left)
            | AnchorStyles.Right)));
            ktxtStackTrace.Location = new Point(20, 243);
            ktxtStackTrace.Multiline = true;
            ktxtStackTrace.Name = "ktxtStackTrace";
            ktxtStackTrace.ScrollBars = ScrollBars.Vertical;
            ktxtStackTrace.Size = new Size(591, 289);
            ktxtStackTrace.TabIndex = 4;
            // 
            // ExceptionDetailControl
            // 
            Controls.Add(kryptonPanel1);
            Name = "ExceptionDetailControl";
            Size = new Size(614, 535);
            ((System.ComponentModel.ISupportInitialize)(kryptonPanel1)).EndInit();
            kryptonPanel1.ResumeLayout(false);
            kryptonPanel1.PerformLayout();
            ResumeLayout(false);

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

            var lvi = new ListViewItem { Text = "Top Level" };

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