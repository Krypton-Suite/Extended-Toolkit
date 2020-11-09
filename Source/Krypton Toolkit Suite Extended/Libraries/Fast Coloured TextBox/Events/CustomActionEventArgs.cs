using System;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    /// <summary>
    /// CustomAction event args
    /// </summary>
    public class CustomActionEventArgs : EventArgs
    {
        public FCTBAction Action { get; private set; }

        public CustomActionEventArgs(FCTBAction action)
        {
            Action = action;
        }
    }
}