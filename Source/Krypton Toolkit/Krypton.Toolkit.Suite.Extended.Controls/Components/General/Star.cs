#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Controls;

internal class Star : PictureBox
{
    private Container _components;
    public int StarNumber { get; private set; }

    private enum States { Off, On }

    private readonly Dictionary<States, Image> _stars;

    private readonly Action<int> _clicked;
    private readonly Action<int> _mouseEnter;
    private readonly Action<int> _mouseLeave;

    internal Star(int starNumber, Image offImage, Image onImage, Action<int> clicked, Action<int> mouseEnter, Action<int> mouseLeave)
    {
        Size = new Size(offImage.Width, offImage.Height);
        Left = Width * (starNumber - 1);

        _stars = new Dictionary<States, Image>
        {
            {States.On, onImage},
            {States.Off, offImage}
        };
        StarNumber = starNumber;
        Image = _stars[States.Off];

        _clicked = clicked;
        _mouseEnter = mouseEnter;
        _mouseLeave = mouseLeave;


        InitializeComponent();
    }

    public void ToggleStar(int starNumber)
    {
        Image = StarNumber > starNumber ? _stars[States.Off] : _stars[States.On];
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        _mouseEnter(StarNumber);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        _mouseLeave(StarNumber);
    }

    protected override void OnClick(EventArgs e)
    {
        _clicked(StarNumber);
    }

    #region Component Designer generated code

    private void InitializeComponent()
    {
        _components = new Container();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_components != null)
            {
                _components.Dispose();
            }
        }

        base.Dispose(disposing);
    }
    #endregion
}