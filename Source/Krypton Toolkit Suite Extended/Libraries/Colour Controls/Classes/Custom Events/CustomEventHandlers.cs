using System;

namespace Krypton.Toolkit.Suite.Extended.Drawing.Suite
{
    public class ColourEvents
    {
        public delegate void SelectedColourChangedEventHandler(object sender, EventArgs e);

        public event SelectedColourChangedEventHandler SelectedColourChanged;


        protected virtual void OnSelectedColourChanged()
        {
            if (SelectedColourChanged != null) SelectedColourChanged(this, EventArgs.Empty);
        }
    }
}