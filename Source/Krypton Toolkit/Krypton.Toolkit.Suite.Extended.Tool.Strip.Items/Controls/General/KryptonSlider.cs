#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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
    [DefaultEvent("ValueChanged"), ToolboxBitmap(typeof(TrackBar)), ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ContextMenuStrip | ToolStripItemDesignerAvailability.StatusStrip | ToolStripItemDesignerAvailability.ToolStrip)]
    public partial class KryptonSlider : ToolStripControlHostFixed
    {
        #region Events
        public event ValueChangedEventHandler ValueChanged;
        #endregion

        #region Delegates
        public delegate void ValueChangedEventHandler(KryptonToolbarSlider sender, KryptonToolbarSlider.SliderEventArgs eventArgs);
        #endregion

        #region Properties
        [Category("Control")]
        public KryptonToolbarSlider Tracker => Control as KryptonToolbarSlider;

        [Category("Slider Values"), DefaultValue(typeof(bool), "false")]
        public bool SingleClick
        {
            get => (Control as KryptonToolbarSlider).SingleClick;
            set => (Control as KryptonToolbarSlider).SingleClick = value;
        }
        [Category("Slider Values"), DefaultValue(typeof(int), "200")]
        public int FireInterval
        {
            get => (Control as KryptonToolbarSlider).FireInterval;
            set => (Control as KryptonToolbarSlider).FireInterval = value;
        }
        [Category("Slider Values"), DefaultValue(typeof(Size), "140, 16")]
        public Size TrackerSize
        {
            get => (Control as KryptonToolbarSlider).Size;
            set => (Control as KryptonToolbarSlider).Size = value;
        }
        [Category("Slider Values"), DefaultValue(0)]
        public int Value
        {
            get => (Control as KryptonToolbarSlider).Value;
            set => (Control as KryptonToolbarSlider).Value = value;
        }
        [Category("Slider Values"), DefaultValue(100)]
        public int Range
        {
            get => (Control as KryptonToolbarSlider).Range;
            set => (Control as KryptonToolbarSlider).Range = value;
        }
        [Category("Slider Values"), DefaultValue(5)]
        public int Steps
        {
            get => (Control as KryptonToolbarSlider).Steps;
            set => (Control as KryptonToolbarSlider).Steps = value;
        }
        [Category("Slider Values")]
        public int Maximum => (Control as KryptonToolbarSlider).Maximum;

        [Category("Slider Values")]
        public int Minimum => (Control as KryptonToolbarSlider).Minimum;

        #endregion

        #region Constructor
        public KryptonSlider() : base(new KryptonToolbarSlider())
        {

        }
        #endregion

        #region Overrides
        protected override void OnSubscribeControlEvents(Control control)
        {
            base.OnSubscribeControlEvents(control);

            (Control as KryptonToolbarSlider).ValueChanged += OnValueChanged;

            //(Control as KryptonToolbarSlider).kminus.SliderButtonFire += kminus_SliderButtonFire;

            //(Control as KryptonToolbarSlider).kplus.SliderButtonFire += kplus_SliderButtonFire;
        }

        protected override void OnUnsubscribeControlEvents(Control control)
        {
            base.OnUnsubscribeControlEvents(control);

            (Control as KryptonToolbarSlider).ValueChanged -= OnValueChanged;
            //(this.Control as KryptonToolbarSlider).kminus.SliderButtonFire -= kminus_SliderButtonFire;
            //(this.Control as KryptonToolbarSlider).kplus.SliderButtonFire -= kplus_SliderButtonFire;
        }
        #endregion

        #region Event Handlers
        private void OnValueChanged(KryptonToolbarSlider Sender, KryptonToolbarSlider.SliderEventArgs e) => ValueChanged?.Invoke(Sender, e);

        private void kminus_SliderButtonFire(KryptonSliderButton sender, EventArgs e)
        {

        }

        private void kplus_SliderButtonFire(KryptonSliderButton sender, EventArgs e)
        {

        }
        #endregion
    }
}