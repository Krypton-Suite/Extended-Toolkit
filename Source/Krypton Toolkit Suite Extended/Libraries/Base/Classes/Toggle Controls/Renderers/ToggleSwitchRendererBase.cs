using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Base
{
    public abstract class ToggleSwitchRendererBase
    {
        #region Variables
        private ToggleSwitch _toggleSwitch;
        #endregion

        #region Property
        public ToggleSwitch ToggleSwitch { get => _toggleSwitch; set => _toggleSwitch = value; }
        #endregion

        #region Constructors
        public ToggleSwitchRendererBase()
        {

        }

        public ToggleSwitchRendererBase(ToggleSwitch toggleSwitch) => ToggleSwitch = toggleSwitch;
        #endregion

        #region Methods
        public void RenderBackground(PaintEventArgs e)
        {
            if (ToggleSwitch == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, _toggleSwitch.Width, _toggleSwitch.Height);

            FillBackground(e.Graphics, rect);

            RenderBorder(e.Graphics, rect);
        }

        public void RenderControl(PaintEventArgs e)
        {
            if (_toggleSwitch == null)
                return;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Rectangle buttonRectangle = GetButtonRectangle();
            int totalToggleFieldWidth = ToggleSwitch.Width - buttonRectangle.Width;

            if (buttonRectangle.X > 0)
            {
                Rectangle leftRectangle = new Rectangle(0, 0, buttonRectangle.X, ToggleSwitch.Height);

                if (leftRectangle.Width > 0)
                    RenderLeftToggleField(e.Graphics, leftRectangle, totalToggleFieldWidth);
            }

            if (buttonRectangle.X + buttonRectangle.Width < e.ClipRectangle.Width)
            {
                Rectangle rightRectangle = new Rectangle(buttonRectangle.X + buttonRectangle.Width, 0, ToggleSwitch.Width - buttonRectangle.X - buttonRectangle.Width, ToggleSwitch.Height);

                if (rightRectangle.Width > 0)
                    RenderRightToggleField(e.Graphics, rightRectangle, totalToggleFieldWidth);
            }

            RenderButton(e.Graphics, buttonRectangle);
        }

        public void FillBackground(Graphics g, Rectangle controlRectangle)
        {
            Color backColor = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? ToggleSwitch.BackColor.ToGrayScale() : ToggleSwitch.BackColor;

            using (Brush backBrush = new SolidBrush(backColor))
            {
                g.FillRectangle(backBrush, controlRectangle);
            }
        }


        public abstract void RenderBorder(Graphics g, Rectangle borderRectangle);
        public abstract void RenderLeftToggleField(Graphics g, Rectangle leftRectangle, int totalToggleFieldWidth);
        public abstract void RenderRightToggleField(Graphics g, Rectangle rightRectangle, int totalToggleFieldWidth);
        public abstract void RenderButton(Graphics g, Rectangle buttonRectangle);
        #endregion

        #region Helper Methods
        public abstract int GetButtonWidth();
        public abstract Rectangle GetButtonRectangle();
        public abstract Rectangle GetButtonRectangle(int buttonWidth);

        internal void SetToggleSwitch(ToggleSwitch toggleSwitch) => ToggleSwitch = toggleSwitch;
        #endregion
    }
}