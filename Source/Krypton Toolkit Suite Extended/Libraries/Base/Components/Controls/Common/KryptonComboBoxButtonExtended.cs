using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class KryptonComboBoxButtonExtended : KryptonButton
    {
        ButtonState _state;

        public KryptonComboBoxButtonExtended()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            _state = ButtonState.Pushed;

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _state = ButtonState.Normal;

            base.OnMouseUp(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            ControlPaint.DrawComboButton(e.Graphics, 0, 0, Width, Height, _state);
        }
    }
}