#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */

// Original license

/**
* MIT License
*
* Copyright (c) 2017 - 2018 Jacob Mesu
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
*/
#endregion

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    public class AnimationCache
    {
        // Fields

        Image[] cache;
        Timer animationTimer;
        Control control;
        Dictionary<string, int> animatables = new Dictionary<string, int>();
        AnimationEventHandler paintFrame;

        int frameRate = 24;
        int length = 10;
        int direction = 1;
        int currentFrame = 0;

        #region Constructor

        public AnimationCache()
        {
            animationTimer = new Timer();
            animationTimer.Tick += new EventHandler(AnimationTick);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the animation cache. Can be used to draw the control from the OnPaint event
        /// </summary>
        public Image[] Cache
        {
            get { return cache; }
            set { cache = value; }
        }

        /// <summary>
        /// Gets the framerate in frames per second
        /// </summary>
        public int FrameRate
        {
            get { return frameRate; }
        }

        /// <summary>
        /// Gets the length (in frames) of the animation
        /// </summary>
        public int Length
        {
            get { return length; }
        }

        /// <summary>
        /// Gets or sets the direction of the animation
        /// </summary>
        public int Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public Dictionary<string, int> Animatables
        {
            get { return animatables; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Moves the cursor forward or backward depending on direction to a new frame
        /// </summary>
        private void Animate()
        {
            currentFrame = currentFrame + direction;
            if ((currentFrame <= 0) && (direction < 0))
                Stop();
            else if ((currentFrame >= (length - 1)) && (direction > 0))
                Stop();
            else { }
        }

        /// <summary>
        /// Overriden. Raises the item added event 
        /// </summary>      
        protected virtual void OnPaintFrame()
        {
            AnimationEventHandler handler = paintFrame;
            if (handler != null)
            {
                using (Graphics graphics = Graphics.FromImage(cache[currentFrame]))
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.InterpolationMode = InterpolationMode.Bicubic;

                    handler(this, new AnimationEventArgs(graphics,
                       this.animatables));
                }
            }
        }

        /// <summary>
        /// Initializes the animation cache 
        /// </summary>
        /// <param name="control">The control to invalidate when drawing new frames</param>
        /// <param name="length">The length of the animation</param>
        /// <param name="frameRate">The framerate per second of the animation</param>
        /// <param name="size">The dimensions of the animation</param>
        public void Initialize(Control control, int length, int frameRate, Size size)
        {
            this.control = control;
            this.length = length;
            this.frameRate = frameRate;
            this.currentFrame = 0;

            animationTimer.Interval = 1000 / frameRate;
            cache = new Image[length];

            for (int i = 0; i < length; i++)
            {
                cache[i] = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppPArgb);
            }
        }

        /// <summary>
        /// Paints the animatable frames to a local cache
        /// </summary>
        public void PaintAnimation()
        {
            for (int i = 0; i < length; i++)
            {
                currentFrame = i;
                OnPaintFrame();
            }
            currentFrame = 0;
        }

        /// <summary>
        /// Draws the the frame from the cache to the graphics object
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        public void DrawFrame(Graphics g)
        {
            g.DrawImageUnscaled(cache[currentFrame], new Point(0, 0));
        }

        /// <summary>
        /// Starts the animations
        /// </summary>
        public void Start()
        {
            currentFrame = 0;
            if (!animationTimer.Enabled)
                animationTimer.Start();
        }

        /// <summary>
        /// Stops the animation
        /// </summary>
        public void Stop()
        {
            animationTimer.Stop();
        }

        /// <summary>
        /// Reverses the direction of the animation
        /// </summary>
        public void Reverse()
        {
            direction *= -direction;
        }

        #endregion

        #region Overloaded

        #endregion

        #region Event Handling

        private void AnimationTick(object sender, EventArgs e)
        {
            Animate();
            this.control.Invalidate();
        }

        /// <summary>
        /// Occurs when the control should paint a frame for the first time
        /// </summary>
        public event AnimationEventHandler PaintFrame
        {
            add { paintFrame += value; }
            remove { paintFrame -= value; }
        }

        #endregion
    }
}