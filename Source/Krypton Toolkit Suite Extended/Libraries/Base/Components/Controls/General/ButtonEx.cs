using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Base
{
    internal class ButtonEx : KryptonButton
    {
        ButtonState state;

        public ButtonEx()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            state = ButtonState.Flat;

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            state = ButtonState.Normal;

            base.OnMouseUp(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            ControlPaint.DrawComboButton(e.Graphics, e.ClipRectangle, state);
        }
    }
}