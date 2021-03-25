﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    [ToolboxBitmap(typeof(KryptonComboBoxEnhanced))]
    public class KryptonColourComboBox : KryptonComboBoxEnhanced
    {
        #region Event
        public event DrawItemEventHandler DrawItem;
        #endregion

        #region Constructor
        public KryptonColourComboBox()
        {
            Text = string.Empty;

            DrawItem += KryptonColourComboBox_DrawItem;
        }
        #endregion

        #region Event Handlers
        /// <summary>Handles the DrawItem event of the KryptonColourComboBox control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DrawItemEventArgs"/> instance containing the event data.</param>
        private void KryptonColourComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            Type colourType = typeof(Color);

            PropertyInfo[] propertyInfo = colourType.GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public);

            Graphics gfx = e.Graphics;

            Rectangle rectangle = e.Bounds;

            foreach (PropertyInfo item in propertyInfo)
            {
                base.Items.Add(item);
            }

            if (e.Index >= 0)
            {
                string n = ((KryptonComboBoxEnhanced)sender).Items[e.Index].ToString();

                Font typeface = new Font(base.Font.FontFamily, 9, FontStyle.Regular);

                Color c = Color.FromName(n);

                Brush brush = new SolidBrush(c);

                gfx.DrawString(n, typeface, Brushes.Black, rectangle.X, rectangle.Top);

                gfx.FillRectangle(brush, rectangle.X + 110, rectangle.Y + 5, rectangle.Width - 10, rectangle.Height - 10);
            }

            gfx.Dispose();

            e.DrawFocusRectangle();
        }
        #endregion

        #region Protected Events

        #endregion
    }
}