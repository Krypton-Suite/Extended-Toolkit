﻿#region MIT License
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

namespace Krypton.Toolkit.Suite.Extended.Forms
{
    internal class FadeController
    {
        #region Variables
        private int _fadeInterval;

        private KryptonFormExtended _currentWindow, _nextWindow;

        private VirtualForm _owner, _nextVirtualWindow;
        #endregion

        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="FadeController" /> class.</summary>
        public FadeController() { }

        /// <summary>Initializes a new instance of the <see cref="FadeController" /> class.</summary>
        /// <param name="fadeInterval">The fade sleep timer.</param>
        /// <param name="owner">The owner.</param>
        /// <param name="nextWindow">The next window.</param>
        public FadeController(int fadeInterval, VirtualForm owner, VirtualForm nextWindow = null)
        {
            _fadeInterval = fadeInterval;

            _owner = owner;

            _nextVirtualWindow = nextWindow;
        }

        /// <summary>Initializes a new instance of the <see cref="FadeController" /> class.</summary>
        /// <param name="fadeInterval">The fade interval.</param>
        /// <param name="currentWindow">The current window.</param>
        /// <param name="nextWindow">The next window.</param>
        public FadeController(int fadeInterval, KryptonFormExtended currentWindow, KryptonFormExtended nextWindow)
        {
            _fadeInterval = fadeInterval;

            _currentWindow = currentWindow;

            _nextWindow = nextWindow;
        }
        #endregion

        #region Methods
        /// <summary>Fades the window in. Credit: https://stackoverflow.com/questions/12497826/better-algorithm-to-fade-a-winform.</summary>
        /// <param name="owner">The owner.</param>
        /// <param name="fadeInterval">The fade interval.</param>
        public async void FadeWindowIn(VirtualForm owner, int fadeInterval = 50)
        {
            if (fadeInterval <= 0)
            {
                fadeInterval = _fadeInterval;
            }

            // The window is not visible, so fade it in
            while (owner.Opacity <= 1.0)
            {
                await Task.Delay(fadeInterval);

                owner.Opacity += 0.05;
            }

            // Now, the window is fully visible
            owner.Opacity = 1;
        }

        /// <summary>Fades the window in.</summary>
        /// <param name="currentWindow">The current window.</param>
        /// <param name="fadeInterval">The fade interval.</param>
        public async void FadeWindowIn(KryptonFormExtended currentWindow, int fadeInterval = 0)
        {
            if (fadeInterval <= 0)
            {
                fadeInterval = _fadeInterval;
            }

            // The window is not visible, so fade it in
            while (currentWindow.Opacity <= 1.0)
            {
                await Task.Delay(fadeInterval);

                currentWindow.Opacity += 0.05;
            }

            // Now, the window is fully visible
            currentWindow.Opacity = 1;
        }

        /// <summary>Fades the window out. Credit: https://stackoverflow.com/questions/12497826/better-algorithm-to-fade-a-winform.</summary>
        /// <param name="owner">The owner.</param>
        /// <param name="nextWindow">The next window.</param>
        /// <param name="fadeInterval">The fade interval.</param>
        public async void FadeWindowOut(VirtualForm owner, VirtualForm nextWindow = null, int fadeInterval = 0)
        {
            if (fadeInterval <= 0)
            {
                fadeInterval = _fadeInterval;
            }

            // The window is visible, so fade it out
            while (owner.Opacity > 0.0)
            {
                await Task.Delay(fadeInterval);

                owner.Opacity -= 0.05;
            }

            // Now, the window is invisible
            owner.Opacity = 0;

            // Move on to the next window if necessary
            if (nextWindow != null)
            {
                nextWindow.Show();
            }
        }

        /// <summary>Fades the window out.</summary>
        /// <param name="currentWindow">The current window.</param>
        /// <param name="nextWindow">The next window.</param>
        /// <param name="fadeInterval">The fade interval.</param>
        public async void FadeWindowOut(KryptonFormExtended currentWindow, KryptonFormExtended nextWindow = null, int fadeInterval = 0)
        {
            if (fadeInterval <= 0)
            {
                fadeInterval = _fadeInterval;
            }

            // The window is visible, so fade it out
            while (currentWindow.Opacity > 0.0)
            {
                await Task.Delay(fadeInterval);

                currentWindow.Opacity -= 0.05;
            }

            // Now, the window is invisible
            currentWindow.Opacity = 0;

            // Move on to the next window if necessary
            if (nextWindow != null)
            {
                nextWindow.Show();
            }
        }
        #endregion
    }
}