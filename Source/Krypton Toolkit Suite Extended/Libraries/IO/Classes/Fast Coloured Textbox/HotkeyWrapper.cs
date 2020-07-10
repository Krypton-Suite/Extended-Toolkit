using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.IO
{
    public class HotkeyWrapper
    {
        public HotkeyWrapper(Keys keyData, FCTBAction action)
        {
            KeyEventArgs a = new KeyEventArgs(keyData);
            Ctrl = a.Control;
            Shift = a.Shift;
            Alt = a.Alt;

            Key = a.KeyCode;
            Action = action;
        }

        public Keys ToKeyData()
        {
            var res = Key;
            if (Ctrl) res |= Keys.Control;
            if (Alt) res |= Keys.Alt;
            if (Shift) res |= Keys.Shift;

            return res;
        }

        bool Ctrl;
        bool Shift;
        bool Alt;

        public string Modifiers
        {
            get
            {
                var res = "";
                if (Ctrl) res += "Ctrl + ";
                if (Shift) res += "Shift + ";
                if (Alt) res += "Alt + ";

                return res.Trim(' ', '+');
            }
            set
            {
                if (value == null)
                {
                    Ctrl = Alt = Shift = false;
                }
                else
                {
                    Ctrl = value.Contains("Ctrl");
                    Shift = value.Contains("Shift");
                    Alt = value.Contains("Alt");
                }
            }
        }

        public Keys Key { get; set; }
        public FCTBAction Action { get; set; }
    }
}