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

namespace Krypton.Toolkit.Suite.Extended.Forms;

[DebuggerDisplay("({_visualOrientation} {_optimisedVisible})")]
internal class VisualShadowBase : NativeWindow, IDisposable
{
    #region Instance Fields
    private readonly ShadowValues _shadowValues;
    private readonly VisualOrientation _visualOrientation;
    private bool _optimisedVisible;
    private Bitmap _shadowClip;
    #endregion

    #region Identity

    /// <summary>
    /// Create a shadow thingy
    /// </summary>
    /// <param name="shadowValues">What value will be used</param>
    /// <param name="visualOrientation">What orientation for the shadow placement</param>
    public VisualShadowBase(ShadowValues shadowValues, VisualOrientation visualOrientation)
    {
        _shadowValues = shadowValues;
        _visualOrientation = visualOrientation;
        // Update form properties so we do not have a border and do not show
        // in the task bar. We draw the background in Magenta and set that as
        // the transparency key so it is a see through window.
        CreateParams cp = new()
        {
            // Define the screen position/size
            X = -2,
            Y = -2,
            Height = 2,
            Width = 2,

            Parent = IntPtr.Zero,//_ownerHandle,
            Style = unchecked((int)(PlatformInvoke.WS_.DISABLED | PlatformInvoke.WS_.POPUP)),
            ExStyle = unchecked((int)(PlatformInvoke.WS_EX_.LAYERED | PlatformInvoke.WS_EX_.NOACTIVATE | PlatformInvoke.WS_EX_.TRANSPARENT | PlatformInvoke.WS_EX_.NOPARENTNOTIFY))
        };

        _shadowClip = new Bitmap(1, 1);
        // Make the default transparent color transparent for myBitmap.
        _shadowClip.MakeTransparent();

        // Create the actual window
        CreateHandle(cp);
    }

    /// <summary>
    /// Make sure the resources are disposed of gracefully.
    /// </summary>
    public void Dispose()
    {
        DestroyHandle();
        _shadowClip.Dispose();
    }
    #endregion

    #region Public
    /// <summary>
    /// Show the window without activating it (i.e. do not take focus)
    /// </summary>
    public bool Visible
    {
        get => _optimisedVisible;
        set
        {
            if (_optimisedVisible != value)
            {
                _optimisedVisible = value;
                if (!value)
                {
                    PlatformInvoke.ShowWindow(Handle, PlatformInvoke.ShowWindowCommands.SW_HIDE);
                }
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public Rectangle TargetRect { get; private set; }

    #endregion


    #region Implementation
    /// <summary>
    /// Calculate the new position, but DO NOT Move
    /// </summary>
    /// <param name="clientLocation">screen location of parent</param>
    /// <param name="windowBounds"></param>
    /// <returns>true, if the position has changed</returns>
    /// <remarks>
    /// Move operations have to be done as a single operation to reduce flickering
    /// </remarks>
    public bool CalcPositionShadowForm(Point clientLocation, Rectangle windowBounds)
    {
        Rectangle rect = CalcRectangle(windowBounds);
        rect.Offset(clientLocation);
        rect.Offset(_shadowValues.Offset);
        if (TargetRect != rect)
        {
            TargetRect = rect;
            return true;
        }

        return false;
    }


    /// <summary>
    /// Also invalidates to perform a redraw
    /// </summary>
    /// <param name="sourceBitmap">This will be a single bitmap that would represent all the shadows</param>
    /// <param name="windowBounds"></param>
    public void ReCalcShadow(Bitmap sourceBitmap, Rectangle windowBounds)
    {
        Rectangle clipRect = CalcRectangle(windowBounds);
        if (clipRect.Width > 0
            && clipRect.Height > 0)
        {
            _shadowClip = sourceBitmap.Clone(clipRect, sourceBitmap.PixelFormat);
        }
        else
        {
            _shadowClip = new Bitmap(1, 1);
            _shadowClip.MakeTransparent();
        }

        UpdateShadowLayer();
    }

    internal void UpdateShadowLayer()
    {
        // The Following is also in
        // $:\Krypton-NET-4.7\Source\Krypton Components\Krypton.Navigator\Dragging\DropDockingIndicatorsRounded.cs
        // Does this bitmap contain an alpha channel?
        if (_shadowClip.PixelFormat != PixelFormat.Format32bppArgb)
        {
            throw new ApplicationException("The bitmap must be 32bpp with alpha-channel.");
        }

        // Must have a visible rectangle to render
        if (TargetRect.Width <= 0 || TargetRect.Height <= 0)
        {
            return;
        }

        // Get device contexts
        IntPtr screenDc = PlatformInvoke.GetDC(IntPtr.Zero);
        IntPtr memDc = PlatformInvoke.CreateCompatibleDC(screenDc);
        IntPtr hBitmap = IntPtr.Zero;
        IntPtr hOldBitmap = IntPtr.Zero;

        try
        {
            // Get handle to the new bitmap and select it into the current 
            // device context.
            hBitmap = _shadowClip.GetHbitmap(Color.FromArgb(0));
            hOldBitmap = PlatformInvoke.SelectObject(memDc, hBitmap);

            // Set parameters for layered window update.
            PlatformInvoke.SIZE newSize = new(_shadowClip.Width, _shadowClip.Height);
            PlatformInvoke.POINT sourceLocation = new(0, 0);
            PlatformInvoke.POINT newLocation = new(TargetRect.Left, TargetRect.Top);
            PlatformInvoke.BLENDFUNCTION blend = new()
            {
                BlendOp = PlatformInvoke.AC_SRC_OVER,
                BlendFlags = 0,
                SourceConstantAlpha = (byte)(255 * _shadowValues.Opacity / 100.0),
                AlphaFormat = PlatformInvoke.AC_SRC_ALPHA
            };

            // Update the window.
            PlatformInvoke.UpdateLayeredWindow(
                Handle, // Handle to the layered window
                screenDc, // Handle to the screen DC
                ref newLocation, // New screen position of the layered window
                ref newSize, // New size of the layered window
                memDc, // Handle to the layered window surface DC
                ref sourceLocation, // Location of the layer in the DC
                0, // Color key of the layered window
                ref blend, // Transparency of the layered window
                PlatformInvoke.ULW_ALPHA // Use blend as the blend function
            );
        }
        finally
        {
            // Release device context.
            PlatformInvoke.ReleaseDC(IntPtr.Zero, screenDc);
            if (hBitmap != IntPtr.Zero)
            {
                PlatformInvoke.SelectObject(memDc, hOldBitmap);
                PlatformInvoke.DeleteObject(hBitmap);
            }

            PlatformInvoke.DeleteDC(memDc);
        }
    }

    /// <summary>
    /// Q: Why go to this trouble and not just have a "Huge bitmap"
    /// A: Memory for a 4K screen can eat a lot for a 32bit per PlatformInvokexel shader !
    /// </summary>
    /// <param name="windowBounds"></param>
    /// <returns></returns>
    private Rectangle CalcRectangle(Rectangle windowBounds)
    {
        int extraWidth = _shadowValues.ExtraWidth;
        var w = windowBounds.Width + extraWidth * 2;
        var h = windowBounds.Height + extraWidth * 2;

        var top = 0;
        var left = 0;
        var bottom = 0;
        var right = 0;

        switch (_visualOrientation)
        {
            case VisualOrientation.Top:
                top = 0;
                left = 0;
                bottom = Math.Abs(_shadowValues.Offset.Y) + extraWidth;
                right = w;
                break;
            case VisualOrientation.Left:
                top = Math.Abs(_shadowValues.Offset.Y) + extraWidth;
                left = 0;
                bottom = h;
                right = Math.Abs(_shadowValues.Offset.X) + extraWidth;
                break;
            case VisualOrientation.Bottom:
                top = windowBounds.Height - (Math.Abs(_shadowValues.Offset.Y) + extraWidth);
                left = Math.Abs(_shadowValues.Offset.X) + extraWidth;
                bottom = h;
                right = windowBounds.Width - (Math.Abs(_shadowValues.Offset.X) + extraWidth);
                break;
            case VisualOrientation.Right:
                top = Math.Abs(_shadowValues.Offset.Y) + extraWidth;
                left = windowBounds.Width - (Math.Abs(_shadowValues.Offset.X) + extraWidth);
                bottom = h;
                right = w;
                break;
        }

        return Rectangle.FromLTRB(left, top, right, bottom);
    }
    #endregion
}