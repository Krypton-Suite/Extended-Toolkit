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
    /// Enhanced ToolStripMenuItem with the ability to display radio button for checked item.
    /// <br></br>
    /// If CheckOnClick property is set to true and CheckMarkDisplayStyle is set to RadioButton, context
    /// menu strip behaves similar way as GroupBox with RadioButton controls.
    /// Within same group only one item can be selected.
    /// </summary>
    [ToolboxBitmap(typeof(ToolStripMenuItem)), RefreshProperties(RefreshProperties.Repaint), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
    public class EnhancedToolStripMenuItem : ToolStripMenuItem
    {
        #region Variables
        private CheckMarkDisplayStyle _displayStyle;
        #endregion

        #region Properties
        /// <summary>
        /// Menu items with radio button display can be used to bind enum values.
        /// This property can be used to store associated Enum value.
        /// </summary>
        public Enum AssociatedEnumValue { set; get; }

        /// <summary>
        /// Switches between CheckkBox or RadioButton style.
        /// </summary>
        [RefreshProperties(RefreshProperties.Repaint), NotifyParentProperty(true), DefaultValue(CheckMarkDisplayStyle.RADIOBUTTON)]
        public CheckMarkDisplayStyle DisplayStyle
        {
            set
            {
                _displayStyle = value;

                Invalidate();
            }

            get => _displayStyle;
        }

        /// <summary>
        /// In order to provide behavior similar to RadioButton group, we need a way to mark groups. 
        /// This property is used for this purpose. All menu items with identical RadioButtonGroupName belong to the same group.
        /// It means that clicking one item within group de-selects previously selected item and 
        /// selects clicked item (only one item can be selected).
        /// </summary>
        [DefaultValue("")]
        public string RadioButtonGroupName { set; get; }
        #endregion

        #region Constructor
        public EnhancedToolStripMenuItem()
        {
            DisplayStyle = CheckMarkDisplayStyle.RADIOBUTTON;

            CheckOnClick = true;
        }
        #endregion

        #region Overrides
        protected override void OnClick(EventArgs e)
        {
            if ((DisplayStyle == CheckMarkDisplayStyle.RADIOBUTTON) && (CheckOnClick))
            {
                ToolStrip toolStrip = GetCurrentParent();

                foreach (ToolStripItem items in toolStrip.Items)
                {
                    if (items is EnhancedToolStripMenuItem)
                    {
                        EnhancedToolStripMenuItem menuItem = (EnhancedToolStripMenuItem)items;

                        if ((menuItem.DisplayStyle == CheckMarkDisplayStyle.RADIOBUTTON) && (menuItem.CheckOnClick) && (menuItem.RadioButtonGroupName == RadioButtonGroupName))
                        {
                            menuItem.Checked = false;
                        }
                    }
                }
            }

            base.OnClick(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //if CheckMarkDisplayStyle is equal RadioButton additional paining or radio button is needed
            if ((DisplayStyle == CheckMarkDisplayStyle.RADIOBUTTON))
            {
                //Find location of radio button
                Size radioButtonSize = RadioButtonRenderer.GetGlyphSize(e.Graphics, RadioButtonState.CheckedNormal);
                int radioButtonX = ContentRectangle.X + 3;
                int radioButtonY = ContentRectangle.Y + (ContentRectangle.Height - radioButtonSize.Height) / 2;

                //Find state of radio button
                RadioButtonState state = RadioButtonState.CheckedNormal;
                if (this.Checked)
                {
                    if (Pressed)
                        state = RadioButtonState.CheckedPressed;
                    else if (Selected)
                        state = RadioButtonState.CheckedHot;
                }
                else
                {
                    if (Pressed)
                        state = RadioButtonState.UncheckedPressed;
                    else if (Selected)
                        state = RadioButtonState.UncheckedHot;
                    else
                        state = RadioButtonState.UncheckedNormal;
                }

                //Draw RadioButton in proper state (Checked/Unchecked; Hot/Normal/Pressed)
                RadioButtonRenderer.DrawRadioButton(e.Graphics, new Point(radioButtonX, radioButtonY), state);

            }
        }
        #endregion
    }
}