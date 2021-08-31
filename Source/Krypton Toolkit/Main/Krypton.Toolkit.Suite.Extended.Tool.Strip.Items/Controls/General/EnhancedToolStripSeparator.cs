#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    /// <summary>
    /// Enhanced menu separator. It act as "standard" menu separator with 
    /// additional ability to display positioned text.
    /// </summary>
    [ToolboxBitmap(typeof(ToolStripSeparator)), RefreshProperties(RefreshProperties.Repaint), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
    public partial class EnhancedToolStripSeparator : ToolStripMenuItem
    {
        #region Variables
        private bool _showSeparatorLine;
        #endregion

        #region Properties
        /// <summary>
        /// If set to 'true' separator line will be displayed in areas not occupied by text.
        /// Otherwise only text will be displayed.
        /// </summary>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Description("If set to 'true' separator line will be displayed in areas not occupied by text. Otherwise only text will be displayed.")]
        public bool ShowSeparatorLine { get => _showSeparatorLine; set { _showSeparatorLine = value; Invalidate(); } }

        /// <summary>
        /// Checked property doesn't make sense for separator, we need to hide 
        /// base functionality and never call base property in case Checked is used in code. 
        /// Setting Checked property to any value does nothing.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool Checked { set; get; }

        /// <summary>
        /// CheckState property doesn't make sense for separator, we need to hide 
        /// base functionality and never call base property in case CheckState is used in code. 
        /// Setting CheckState property to any value does nothing.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new CheckState CheckState { set; get; }

        /// <summary>
        /// DropDown property doesn't make sense for separator, we need to hide 
        /// base functionality and never call base property in case DropDown is used in code. 
        /// Setting DropDown property to any value does nothing.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ToolStripDropDown DropDown { set; get; }


        /// <summary>
        /// DropDownItems property doesn't make sense for separator, we need to hide 
        /// base functionality and never set base property in case DropDownItems is used in code. 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ToolStripItemCollection DropDownItems => base.DropDownItems;

        /// <summary>
        /// Separator cannot have DropDown items, therefore <b>HasDropDownItems</b> always returns <i>false</i>.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool HasDropDownItems => false;

        /// <summary>
        /// Separator is not selectable, therefore CanSelect always returns false.
        [EditorBrowsable(EditorBrowsableState.Never)]
        /// </summary>
        [Browsable(false)]
        public override bool CanSelect
        {
            get { return false; }
        }
        #endregion

        #region Constructor
        public EnhancedToolStripSeparator()
        {
            ForeColor = SystemColors.GrayText;

            ShowSeparatorLine = false;
        }
        #endregion

        #region Overrides
        public override Size GetPreferredSize(Size constrainingSize)
        {
            if (string.IsNullOrEmpty(Text))
                return new Size(base.GetPreferredSize(constrainingSize).Width, 5);
            else
                return base.GetPreferredSize(constrainingSize);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ToolStrip ts = this.Owner ?? this.GetCurrentParent();
            int textLeft = ts.Padding.Horizontal;

            if (ts.BackColor != this.BackColor)
            {
                using (SolidBrush sb = new SolidBrush(BackColor))
                {
                    e.Graphics.FillRectangle(sb, e.ClipRectangle);
                }
            }



            Size textSize = TextRenderer.MeasureText(Text, Font);

            //Find horizontal text position offset
            switch (TextAlign)
            {
                case System.Drawing.ContentAlignment.BottomCenter:
                case System.Drawing.ContentAlignment.MiddleCenter:
                case System.Drawing.ContentAlignment.TopCenter:
                    textLeft = (ContentRectangle.Width + textLeft - textSize.Width) / 2;
                    break;
                case System.Drawing.ContentAlignment.BottomRight:
                case System.Drawing.ContentAlignment.MiddleRight:
                case System.Drawing.ContentAlignment.TopRight:
                    textLeft = ContentRectangle.Right - textSize.Width;
                    break;

            }

            int yLinePosition = (ContentRectangle.Bottom - ContentRectangle.Top) / 2;
            int yTextPosition = (ContentRectangle.Bottom - textSize.Height - ContentRectangle.Top) / 2;

            switch (TextAlign)
            {
                case System.Drawing.ContentAlignment.BottomCenter:
                case System.Drawing.ContentAlignment.BottomLeft:
                case System.Drawing.ContentAlignment.BottomRight:
                    yLinePosition = yTextPosition;
                    break;
                case System.Drawing.ContentAlignment.TopCenter:
                case System.Drawing.ContentAlignment.TopLeft:
                case System.Drawing.ContentAlignment.TopRight:
                    yLinePosition = yTextPosition + textSize.Height;
                    break;
            }

            using (Pen pen = new Pen(ForeColor))
            {
                if (ShowSeparatorLine)
                    e.Graphics.DrawLine(pen, ts.Padding.Horizontal, yLinePosition, textLeft, yLinePosition);

                TextRenderer.DrawText(e.Graphics, Text, Font, new Point(textLeft, yTextPosition), ForeColor);

                if (ShowSeparatorLine)
                    e.Graphics.DrawLine(pen, textLeft + textSize.Width, yLinePosition, ContentRectangle.Right, yLinePosition);
            }
        }
        #endregion
    }
}