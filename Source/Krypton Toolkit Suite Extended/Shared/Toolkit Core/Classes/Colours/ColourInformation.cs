﻿using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public class ColourInformation
    {
        #region Constructor
        public ColourInformation()
        {

        }
        #endregion

        #region Methods
        /// <summary>Returns the colour informtion.</summary>
        /// <param name="colour">The colour.</param>
        /// <param name="colourHeader">The colour header.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static string ReturnColourInformtion(Color colour, string colourHeader = null)
        {
            StringBuilder builder = new StringBuilder();

            if (colourHeader != null)
            {
                builder.Append($"{ colourHeader }:\nARGB: { colour.ToArgb() }\nRGB: { colour.R }, { colour.G }, { colour.B }\nHex: { ColorTranslator.ToHtml(colour) }"); //Known Name: { Color.FromKnownColor(colour) }")
            }
            else
            {
                builder.Append($"ARGB: { colour.ToArgb() }\nRGB: { colour.R }, { colour.G }, { colour.B }\nHex: { ColorTranslator.ToHtml(colour) }");
            }

            return builder.ToString();
        }

        /// <summary>Sets the tooltip.</summary>
        /// <param name="control">The control.</param>
        /// <param name="colourHeader">The colour header.</param>
        public static void SetTooltip(Control control, string colourHeader = null)
        {
            ToolTip temp = new ToolTip();

            temp.SetToolTip(control, ReturnColourInformtion(control.BackColor, $"{ colourHeader } Colour"));
        }
        #endregion
    }
}