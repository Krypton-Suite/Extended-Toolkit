#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Controls
{
    [ToolboxBitmap(typeof(KryptonTextBox)), Description("")]
    public class KryptonValidationBox : KryptonTextBox
    {
        #region Variables
        private bool _validateEntry, _useAccessibilityColours, _modifyBackgroundColour, _useIntermediateColour;

        private Color _intermediateColour;

        private string _validValue;
        #endregion

        #region Properties
        public bool ValidateEntry { get => _validateEntry; set => _validateEntry = value; }

        public bool UseAccessibilityColours { get => _useAccessibilityColours; set => _useAccessibilityColours = value; }

        public bool ModifyBackgroundColour { get => _modifyBackgroundColour; set => _modifyBackgroundColour = value; }

        public bool UseIntermediateColour { get => _useIntermediateColour; set => _useIntermediateColour = value; }

        [DefaultValue("Color.FromArgb(255, 128, 0)"), Description("")]
        public Color IntermediateColour { get => _intermediateColour; set => _intermediateColour = value; }

        public string ValidValue { get => _validValue; private set => _validValue = value; }
        #endregion

        #region Constructors
        public KryptonValidationBox()
        {
            _validateEntry = false;

            _validValue = string.Empty;
        }
        #endregion

        #region Public Methods
        public bool IsInputValid(string input) => Text == input;
        #endregion

        #region Overrides
        protected override void OnTextChanged(EventArgs e)
        {
            //try
            //{
            //    if (_validValue != string.Empty && _validateEntry)
            //    {
            //        if (_modifyBackgroundColour)
            //        {
            //            if (IsInputValid(_validValue))
            //            {
            //                StateCommon.Border.Color1 = Color.Green;

            //                StateCommon.Border.Color2 = Color.Green;

            //                StateCommon.Back.Color1 = Color.FromArgb(128, 255, 128);
            //            }
            //            else if (!IsInputValid(_validValue))
            //            {
            //                StateCommon.Border.Color1 = Color.Red;

            //                StateCommon.Border.Color2 = Color.Red;

            //                StateCommon.Back.Color1 = Color.FromArgb(255, 128, 128);
            //            }
            //            else
            //            {
            //                StateCommon.Border.Color1 = _intermediateColour;

            //                StateCommon.Border.Color2 = _intermediateColour;

            //                StateCommon.Back.Color1 = Color.FromArgb(255, 192, 128);
            //            }
            //        }
            //        else
            //        {
            //            if (IsInputValid(_validValue))
            //            {
            //                StateCommon.Border.Color1 = Color.Green;

            //                StateCommon.Border.Color2 = Color.Green;
            //            }
            //            else if (!IsInputValid(_validValue))
            //            {
            //                StateCommon.Border.Color1 = Color.Red;

            //                StateCommon.Border.Color2 = Color.Red;
            //            }
            //            else
            //            {
            //                StateCommon.Border.Color1 = _intermediateColour;

            //                StateCommon.Border.Color2 = _intermediateColour;
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ExceptionCapture.CaptureException(ex);
            //}

            base.OnTextChanged(e);
        }

        // TODO: I have no idea why this isn't working
        protected override void OnValidating(CancelEventArgs e)
        {
            try
            {
                if (_validValue != string.Empty && _validateEntry)
                {
                    if (_modifyBackgroundColour)
                    {
                        if (IsInputValid(_validValue))
                        {
                            StateCommon.Border.Color1 = Color.Green;

                            StateCommon.Border.Color2 = Color.Green;

                            StateCommon.Back.Color1 = Color.FromArgb(128, 255, 128);
                        }
                        else if (!IsInputValid(_validValue))
                        {
                            StateCommon.Border.Color1 = Color.Red;

                            StateCommon.Border.Color2 = Color.Red;

                            StateCommon.Back.Color1 = Color.FromArgb(255, 128, 128);
                        }
                        else
                        {
                            StateCommon.Border.Color1 = _intermediateColour;

                            StateCommon.Border.Color2 = _intermediateColour;

                            StateCommon.Back.Color1 = Color.FromArgb(255, 192, 128);
                        }
                    }
                    else
                    {
                        if (IsInputValid(_validValue))
                        {
                            StateCommon.Border.Color1 = Color.Green;

                            StateCommon.Border.Color2 = Color.Green;
                        }
                        else if (!IsInputValid(_validValue))
                        {
                            StateCommon.Border.Color1 = Color.Red;

                            StateCommon.Border.Color2 = Color.Red;
                        }
                        else
                        {
                            StateCommon.Border.Color1 = _intermediateColour;

                            StateCommon.Border.Color2 = _intermediateColour;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionCapture.CaptureException(ex);
            }

            base.OnValidating(e);
        }
        #endregion

        #region Setters and Getters
        /// <summary>Sets the ValidValue to the value of value.</summary>
        /// <param name="value">The desired value of ValidValue.</param>
        public void SetValidValue(string value) => ValidValue = value;

        /// <summary>Returns the value of the ValidValue.</summary>
        /// <returns>The value of the ValidValue.</returns>
        public string GetValidValue() => ValidValue;
        #endregion
    }
}