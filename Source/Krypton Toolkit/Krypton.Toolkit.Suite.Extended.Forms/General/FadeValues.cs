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

namespace Krypton.Toolkit.Suite.Extended.Forms
{
    [ToolboxItem(false), DesignerCategory(@"code")]
    public class FadeValues : Storage
    {
        #region Instance Variables

        private bool _useFade;

        private FadeController _fadeController = new();

        private int _fadeInterval;

        private KryptonFormExtended _currentWindow;

        private KryptonFormExtended _nextWindow;

        private VirtualForm _currentVirtualWindow;

        private VirtualForm _nextVirtualWindow;

        #endregion

        #region Public

        [DefaultValue(false)]
        public bool UseFade { get => _useFade; set => _useFade = value; }

        internal FadeController FadeController => _fadeController;

        [DefaultValue(50)]
        public int FadeInterval { get => _fadeInterval; set => _fadeInterval = value; }

        [DefaultValue(null)]
        public KryptonFormExtended CurrentWindow { get => _currentWindow; set => _currentWindow = value; }

        [DefaultValue(null)]
        public KryptonFormExtended NextWindow { get => _nextWindow; set => _nextWindow = value; }

        [DefaultValue(null)]
        public VirtualForm CurrentVirtualWindow { get => _currentVirtualWindow; set => _currentVirtualWindow = value; }

        [DefaultValue(null)]
        public VirtualForm NextVirtualWindow { get => _nextVirtualWindow; set => _nextVirtualWindow = value; }

        #endregion

        #region Identity

        public FadeValues() => Reset();

        internal void Reset()
        {
            UseFade = false;

            FadeInterval = 50;

            CurrentWindow = null;

            NextWindow = null;

            CurrentVirtualWindow = null;

            NextVirtualWindow = null;
        }

        #endregion

        #region Default Instance

        public override bool IsDefault => UseFade == false &&
                                          FadeInterval.Equals(50) &&
                                          CurrentWindow.Equals(null) &&
                                          NextWindow.Equals(null) &&
                                          CurrentVirtualWindow.Equals(null) &&
                                          NextVirtualWindow.Equals(null);

        #endregion
    }
}