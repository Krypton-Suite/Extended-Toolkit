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
        [RefreshProperties(RefreshProperties.Repaint), NotifyParentProperty(true), DefaultValue(CheckMarkDisplayStyle.RadioButton)]
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
            DisplayStyle = CheckMarkDisplayStyle.RadioButton;

            CheckOnClick = true;
        }
        #endregion

        #region Overrides
        protected override void OnClick(EventArgs e)
        {
            if ((DisplayStyle == CheckMarkDisplayStyle.RadioButton) && (CheckOnClick))
            {
                ToolStrip toolStrip = GetCurrentParent();

                foreach (ToolStripItem items in toolStrip.Items)
                {
                    if (items is EnhancedToolStripMenuItem)
                    {
                        EnhancedToolStripMenuItem menuItem = (EnhancedToolStripMenuItem)items;

                        if ((menuItem.DisplayStyle == CheckMarkDisplayStyle.RadioButton) && (menuItem.CheckOnClick) && (menuItem.RadioButtonGroupName == RadioButtonGroupName))
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
            if ((DisplayStyle == CheckMarkDisplayStyle.RadioButton))
            {
                //Find location of radio button
                Size radioButtonSize = RadioButtonRenderer.GetGlyphSize(e.Graphics, RadioButtonState.CheckedNormal);
                int radioButtonX = ContentRectangle.X + 3;
                int radioButtonY = ContentRectangle.Y + (ContentRectangle.Height - radioButtonSize.Height) / 2;

                //Find state of radio button
                RadioButtonState state = RadioButtonState.CheckedNormal;
                if (Checked)
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