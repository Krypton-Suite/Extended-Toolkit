#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    /// <summary>
    /// Panel is a panel with a glass look and feel
    /// </summary>
    [ToolboxBitmap(typeof(Panel))]
    public class InformationBoxPanel : Panel
    {
        #region Attributes

        /// <summary>
        /// Contains the side borders
        /// </summary>
        private SideBorder sideBorder;

        /// <summary>
        /// Contains the side border bottom column
        /// </summary>
        private Color sideBorderBottomColor = Color.Transparent;

        /// <summary>
        /// Contains the side border top column
        /// </summary>
        private Color sideBorderTopColor = Color.White;

        /// <summary>
        /// Contains the side border width
        /// </summary>
        private int sideBorderWidth = 1;

        #endregion Attributes

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Panel"/> class.
        /// </summary>
        public InformationBoxPanel()
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets if a custom border is shown on the sides of the control
        /// </summary>
        /// <value>The side border.</value>
        [Category("Side Border"), Description("Defines if a special side border should be displayed"),
         DefaultValue("None")]
        public SideBorder SideBorder
        {
            get
            {
                return this.sideBorder;
            }

            set
            {
                this.sideBorder = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border width
        /// </summary>
        /// <value>The width of the side border.</value>
        [Category("Side Border"), Description("Defines the width of the side border")]
        public int SideBorderWidth
        {
            get
            {
                return this.sideBorderWidth;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("The border width must be positive");
                }

                this.sideBorderWidth = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the top border color
        /// </summary>
        /// <value>The top color of the side border.</value>
        [Category("Side Border"), Description("Defines the top color of the side border")]
        public Color SideBorderTopColor
        {
            get
            {
                return this.sideBorderTopColor;
            }

            set
            {
                this.sideBorderTopColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the bottom border color
        /// </summary>
        /// <value>The bottom color of the side border.</value>
        [Category("Side Border"), Description("Defines the bottom color of the side border")]
        public Color SideBorderBottomColor
        {
            get
            {
                return this.sideBorderBottomColor;
            }

            set
            {
                this.sideBorderBottomColor = value;
                this.Invalidate();
            }
        }

        #endregion Properties

        #region Event Handlers

        /// <summary>
        /// Paints the background of the control.
        /// </summary>
        /// <param name="pevent">A <see cref="T:System.Windows.Forms.PaintEventArgs"></see> that contains information about the control to paint.</param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            PaintingEngine.PaintGlassEffect(pevent.Graphics, BackColor, Width, Height);
            PaintingEngine.PaintGradientBorders(pevent.Graphics, this.sideBorderTopColor, this.sideBorderBottomColor, Width, Height, this.sideBorderWidth, this.sideBorder);
        }

        #endregion Event Handlers
    }
}