#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    [ToolboxBitmap(typeof(KryptonProgressBar))]
    public partial class KryptonProgressBarMenuItem : ToolStripControlHost
    {
        #region Public

        public ProgressBarStyle Style
        {
            get => HostProgressBar!.Style; set => HostProgressBar!.Style = value;
        }

        public int MarqueeAnimationSpeed
        {
            get => HostProgressBar!.MarqueeAnimationSpeed; set => HostProgressBar!.MarqueeAnimationSpeed = value;
        }

        public int Maximum
        {
            get => HostProgressBar!.Maximum; set => HostProgressBar!.Maximum = value;
        }

        public int Minimum
        {
            get => HostProgressBar!.Minimum; set => HostProgressBar!.Minimum = value;
        }

        public int Step
        {
            get => HostProgressBar!.Step; set => HostProgressBar!.Step = value;
        }

        public int Value
        {
            get => HostProgressBar!.Value; set => HostProgressBar!.Value = value;
        }

        public string Text
        {
            get => HostProgressBar!.Text; set => HostProgressBar!.Text = value;
        }

        public VisualOrientation Orientation
        {
            get => HostProgressBar!.Orientation; set => HostProgressBar!.Orientation = value;
        }

        public bool UseValueAsText
        {
            get => HostProgressBar!.UseValueAsText; set => HostProgressBar!.UseValueAsText = value;
        }

        public LabelValues Values => HostProgressBar!.Values;

        public PaletteTripleRedirect StateCommon => HostProgressBar!.StateCommon;

        public PaletteTriple StateDisabled => HostProgressBar!.StateDisabled;

        public PaletteTriple StateNormal => HostProgressBar!.StateNormal;

        #endregion

        #region Host Control

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        internal KryptonProgressBar? HostProgressBar => Control as KryptonProgressBar;

        #endregion

        #region Identity

        public KryptonProgressBarMenuItem() : base(new KryptonProgressBar())
        {
        }

        #endregion
    }
}
