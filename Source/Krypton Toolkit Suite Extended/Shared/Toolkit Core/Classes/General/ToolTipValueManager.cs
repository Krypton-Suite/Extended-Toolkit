#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.ComponentModel;

namespace Krypton.Toolkit.Suite.Extended.Core
{
    [ToolboxItem(false), DesignerCategory("code")]
    public class ToolTipValueManager : HeaderValues
    {
        private LabelStyle _toolTipStyle;

        public ToolTipValueManager(NeedPaintHandler needPaint) : base(needPaint)
        {
            ResetToolTipStyle();

            ToolTipPosition = new PopupPositionValues();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            ResetEnableToolTips();
            ResetToolTipStyle();
            ResetToolTipPosition();
        }

        /// <summary>
        /// Make sure default values are         
        /// Gets and sets the EnableToolTips
        /// </summary>
        [DefaultValue(false)]
        public bool EnableToolTips { get; set; }

        private bool ShouldSerializeEnableToolTips()
        {
            return EnableToolTips;
        }

        /// <summary>
        /// 
        /// </summary>
        public void ResetEnableToolTips()
        {
            EnableToolTips = false;
        }

        /// <summary>
        /// Gets and sets the EnableToolTips
        /// </summary>
        [Description("The orientation of the ToolTip control when it opens, and specifies how the ToolTip control behaves when it overlaps screen boundaries.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PopupPositionValues ToolTipPosition { get; set; }

        private bool ShouldSerializeToolTipPosition()
        {
            return !ToolTipPosition.IsDefault;
        }

        /// <summary>
        /// Resets the ToolTipStyle property to its default value.
        /// </summary>
        public void ResetToolTipPosition()
        {
            ToolTipPosition.Reset();
        }

        #region ToolTipStyle

        /// <summary>
        /// Gets and sets the tooltip label style.
        /// </summary>
        [Description("Button tooltip label style.")]
        [DefaultValue(typeof(LabelStyle), "SuperTip")]
        public LabelStyle ToolTipStyle
        {
            get => _toolTipStyle;
            set => _toolTipStyle = value;
        }

        private bool ShouldSerializeToolTipStyle()
        {
            return ToolTipStyle != LabelStyle.SuperTip;
        }

        /// <summary>
        /// Resets the ToolTipStyle property to its default value.
        /// </summary>
        public void ResetToolTipStyle()
        {
            ToolTipStyle = LabelStyle.SuperTip;
        }
        #endregion

        #region IsDefault
        [Browsable(false)]
        public override bool IsDefault => (!ShouldSerializeEnableToolTips() && !ShouldSerializeToolTipStyle() && !ShouldSerializeToolTipPosition() && base.IsDefault);
        #endregion
    }
}
