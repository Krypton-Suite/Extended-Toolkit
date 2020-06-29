using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public enum BrowseButtonType
    {
        DEFAULT,
        DIRECTORY,
        FILE
    }

    [ToolboxBitmap(typeof(KryptonButton))]
    public class KryptonBrowseButton : KryptonButton
    {
        #region Variables
        private BrowseButtonType _type;
        #endregion

        #region Properties
        public BrowseButtonType BrowseButtonType { get => _type; set { _type = value; Invalidate(); } }
        #endregion

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            BrowseButtonType tmp = _type;

            AdaptToolTipValues(tmp);

            base.OnPaint(e);
        }

        private void AdaptToolTipValues(BrowseButtonType tmp, bool enableToolTip = true)
        {
            switch (tmp)
            {
                case BrowseButtonType.DEFAULT:
                    AdaptToolTipValues("Browse for folder/file", "Click here to browse to a folder or file.", enableToolTip);
                    break;
                case BrowseButtonType.DIRECTORY:
                    AdaptToolTipValues("Browse for a directory", "Click here to browse to a directory.", enableToolTip);
                    break;
                case BrowseButtonType.FILE:
                    AdaptToolTipValues("Browse for a file", "Click here to browse to a file.", enableToolTip);
                    break;
            }
        }

        private void AdaptToolTipValues(string header, string content, bool enableToolTip)
        {
            ToolTipValues.Heading = header;

            ToolTipValues.Description = content;

            ToolTipValues.EnableToolTips = enableToolTip;
        }
    }
}