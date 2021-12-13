#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class InputState
    {
        public float X { get; set; } = float.NaN;
        public float Y { get; set; } = float.NaN;
        public bool LeftWasJustPressed { get; set; } = false;
        public bool RightWasJustPressed { get; set; } = false;
        public bool MiddleWasJustPressed { get; set; } = false;
        public bool ButtonDown => LeftWasJustPressed || RightWasJustPressed || MiddleWasJustPressed;
        public bool ShiftDown { get; set; } = false;
        public bool CtrlDown { get; set; } = false;
        public bool AltDown { get; set; } = false;
        public bool WheelScrolledUp { get; set; } = false;
        public bool WheelScrolledDown { get; set; } = false;
    }
}