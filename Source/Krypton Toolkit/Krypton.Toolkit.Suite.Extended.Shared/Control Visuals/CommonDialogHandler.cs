#region MIT License
/*
 *
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

// ReSharper disable IdentifierTypo

namespace Krypton.Toolkit.Suite.Extended.Shared
{
    public class CommonDialogHandler
    {
        #region Instance Fields

        private readonly bool _embed;

        private readonly KryptonManager _manager;

        private readonly List<Attributes> _controls = [];

        private readonly Color _backColor;

        private readonly Color _defaultFontColor;

        private readonly Color _inputFontColor;

        private IntPtr _backBrush = IntPtr.Zero;

        private readonly Font? _labelFont = null;

        private bool _embeddingDone;

        internal KryptonForm _toolBox;

        #endregion

        #region Public

        public string Title { get; set; }

        public Icon Icon { get; set; }

        public bool ShowIcon { get; set; }

        #endregion

        #region Identity

        public CommonDialogHandler(bool embed, Font? labelFont, Color backColor, Color defaultFontColor, Color inputFontColor)
        {
            _embed = embed;
            _labelFont = labelFont;
            _backColor = backColor;
            _defaultFontColor = defaultFontColor;
            _inputFontColor = inputFontColor;
            // Gain access to the global palette
            _manager = new KryptonManager();
            // ToDo: Use CurrentGlobal_Palette equivalent
            //_backColour = _manager.GlobalPaletteMode!.GetBackColor1(PaletteBackStyle.PanelClient, PaletteState.Normal);
            //_defaultFontColour = _manager.GlobalCustomPalette!.GetContentShortTextColor1(PaletteContentStyle.LabelNormalPanel, PaletteState.Normal);
            //_inputFontColour = _manager.GlobalCustomPalette!.GetContentShortTextColor1(PaletteContentStyle.InputControlStandalone, PaletteState.Normal);
            //_labelFont = _manager.GlobalCustomPalette?.GetContentShortTextFont(PaletteContentStyle.LabelNormalPanel, PaletteState.Normal)!;
        }

        #endregion

        #region Implementation

        public (bool handled, IntPtr retValue) HookProc(IntPtr hWnd, int msg, IntPtr wparam, IntPtr lparam)
        {
            switch (msg)
            {
                case PlatformInvoke.WM_.INITDIALOG:
                    {
                        if (!string.IsNullOrWhiteSpace(Title))
                        {
                            PlatformInvoke.SetWindowText(hWnd, Title);
                        }

                        var childHandles = new List<IntPtr>();
                        GCHandle gch = GCHandle.Alloc(childHandles);
                        try
                        {
                            var childProc = new PlatformInvoke.WindowEnumProc(EnumerateChildWindow);
                            PlatformInvoke.EnumChildWindows(hWnd, childProc, GCHandle.ToIntPtr(gch));
                            // Pre-allocate 256 characters, since this is the maximum class name length.
                            var name = new StringBuilder(256);
                            if (gch.Target is List<IntPtr> list)
                            {
                                foreach (var child in list)
                                {
                                    var attributes = new Attributes
                                    {
                                        hWnd = child,
                                        DlgCtrlId = PlatformInvoke.GetDlgCtrlID(child)
                                    };
                                    PlatformInvoke.GetWindowInfo(child, out attributes.WinInfo);
                                    var nRet = PlatformInvoke.GetClassName(child, name, name.Capacity);
                                    if (nRet != 0)
                                    {
                                        attributes.ClassName = name.ToString().ToLowerInvariant();
                                    }

                                    _controls.Add(attributes);
                                }
                            }
                        }
                        finally
                        {
                            if (gch.IsAllocated)
                            {
                                gch.Free();
                            }
                        }

                        var labelLogFont = _labelFont!.ToHfont();
                        //var buttonFont = _kryptonManager.GlobalPalette.GetContentShortTextFont(PaletteContentStyle.ButtonStandalone, PaletteState.Normal);
                        //var buttonLogFont = buttonFont.ToHfont();
                        var editFont = _manager.GlobalCustomPalette?.GetContentShortTextFont(PaletteContentStyle.InputControlStandalone, PaletteState.Normal);
                        var editLogFont = editFont!.ToHfont();
                        foreach (Attributes control in _controls)
                        {
                            switch (control.ClassName)
                            {
                                case @"static":
                                case @"combobox":
                                case @"combolbox":
                                    PlatformInvoke.SendMessage(control.hWnd, PlatformInvoke.WM_.SETFONT, labelLogFont, new IntPtr(1));
                                    break;
                                case @"edit":
                                    // Following is the magic required to handle the DlgEx
                                    //if ((control.WinInfo.dwStyle & 0x2000) == 0x2000)
                                    //{
                                    //    //PlatformInvoke.ES_.NUMBER == 0x2000
                                    //    var text = new StringBuilder(64);
                                    //    PlatformInvoke.GetWindowText(control.hWnd, text, 64);
                                    //    control.Text = text.ToString();
                                    //    control.DlgCtrlId = PlatformInvoke.GetDlgCtrlID(control.hWnd);

                                    //    var rcClient = control.WinInfo.rcClient;
                                    //    var lpPoint = new PlatformInvoke.POINT(rcClient.left, rcClient.top);
                                    //    PlatformInvoke.ScreenToClient(hWnd, ref lpPoint);
                                    //    control.ClientLocation = new Point(lpPoint.X, lpPoint.Y);
                                    //    control.Size = new Size(rcClient.right - rcClient.left, rcClient.bottom - rcClient.top+4);
                                    //    var panel = new KryptonPanel
                                    //    {
                                    //        Size = control.Size
                                    //    };
                                    //    panel.Location = control.ClientLocation;
                                    //    PlatformInvoke.SetParent(panel.Handle, hWnd);

                                    //    var button = new KryptonNumericUpDown
                                    //    {
                                    //        AutoSize = false,
                                    //        Text = control.Text,
                                    //        Dock = DockStyle.Fill,
                                    //        InputControlStyle = InputControlStyle.Standalone,
                                    //        Enabled = (control.WinInfo.dwStyle & PlatformInvoke.WS_.DISABLED) == 0
                                    //    };
                                    //    panel.Controls.Add(button);
                                    //    control.Button = button;
                                    //    button.NumericUpDown.ValueChanged += delegate(object sender, EventArgs args)
                                    //    {
                                    //        PlatformInvoke.SendMessage(control.hWnd, PlatformInvoke.WM_.SETTEXT, IntPtr.Zero,
                                    //            button.NumericUpDown.Text);
                                    //    };
                                    //    button.Click += delegate (object sender, EventArgs args)
                                    //    {
                                    //        PlatformInvoke.SendMessage(control.hWnd, PlatformInvoke.BM_CLICK, IntPtr.Zero, IntPtr.Zero);
                                    //        ClickCallback?.Invoke(control);
                                    //    };
                                    //    PlatformInvoke.ShowWindow(control.hWnd, PlatformInvoke.ShowWindowCommands.SW_HIDE);
                                    //}

                                    PlatformInvoke.SendMessage(control.hWnd, PlatformInvoke.WM_.SETFONT, editLogFont, new IntPtr(1));
                                    break;
                                case @"button":
                                    {

                                        if ((control.WinInfo.dwStyle & PlatformInvoke.WS_.VISIBLE) != PlatformInvoke.WS_.VISIBLE)
                                        {
                                            break;
                                        }

                                        var text = new StringBuilder(64);
                                        PlatformInvoke.GetWindowText(control.hWnd, text, 64);
                                        control.Text = text.ToString();
                                        var rcClient = control.WinInfo.rcClient;
                                        var lpPoint = new PlatformInvoke.POINT(rcClient.left, rcClient.top);
                                        PlatformInvoke.ScreenToClient(hWnd, ref lpPoint);
                                        control.ClientLocation = new Point(lpPoint.X, lpPoint.Y);
                                        control.Size = new Size(rcClient.right - rcClient.left, rcClient.bottom - rcClient.top);

                                        if ((control.WinInfo.dwStyle & PlatformInvoke.BS_.GROUPBOX) == PlatformInvoke.BS_.GROUPBOX)
                                        {
                                            PlatformInvoke.SendMessage(control.hWnd, PlatformInvoke.WM_.SETFONT, labelLogFont, new IntPtr(1));
                                        }
                                        else if ((control.WinInfo.dwStyle & PlatformInvoke.BS_.AUTORADIOBUTTON) == PlatformInvoke.BS_.AUTORADIOBUTTON
                                                || (control.WinInfo.dwStyle & PlatformInvoke.BS_.RADIOBUTTON) == PlatformInvoke.BS_.RADIOBUTTON)
                                        {
                                            //PlatformInvoke.SendMessage(control.hWnd, PlatformInvoke.WM_.SETFONT, buttonLogFont, new IntPtr(1));
                                            var panel = new KryptonPanel
                                            {
                                                Size = control.Size
                                            };
                                            panel.Location = control.ClientLocation;
                                            PlatformInvoke.SetParent(panel.Handle, hWnd);

                                            var button = new KryptonRadioButton
                                            {
                                                AutoCheck = (control.WinInfo.dwStyle & PlatformInvoke.BS_.AUTORADIOBUTTON) == PlatformInvoke.BS_.AUTORADIOBUTTON,
                                                AutoSize = false,
                                                Text = control.Text,
                                                Dock = DockStyle.Fill,
                                                LabelStyle = LabelStyle.NormalPanel,
                                                Enabled = (control.WinInfo.dwStyle & PlatformInvoke.WS_.DISABLED) == 0,
                                            };
                                            panel.Controls.Add(button);
                                            control.Button = button;
                                            button.Click += delegate
                                            {
                                                PlatformInvoke.SendMessage(control.hWnd, PlatformInvoke.BM_CLICK, IntPtr.Zero, IntPtr.Zero);
                                                ClickCallback.Invoke(control);
                                            };
                                            PlatformInvoke.ShowWindow(control.hWnd, PlatformInvoke.ShowWindowCommands.SW_HIDE);
                                        }
                                        else if ((control.WinInfo.dwStyle & PlatformInvoke.BS_.AUTO3STATE) == PlatformInvoke.BS_.AUTO3STATE
                                                 || (control.WinInfo.dwStyle & PlatformInvoke.BS_._3STATE) == PlatformInvoke.BS_._3STATE
                                                 || (control.WinInfo.dwStyle & PlatformInvoke.BS_.AUTOCHECKBOX) == PlatformInvoke.BS_.AUTOCHECKBOX
                                            || (control.WinInfo.dwStyle & PlatformInvoke.BS_.CHECKBOX) == PlatformInvoke.BS_.CHECKBOX)
                                        {
                                            var panel = new KryptonPanel
                                            {
                                                Size = control.Size
                                            };
                                            panel.Location = control.ClientLocation;
                                            PlatformInvoke.SetParent(panel.Handle, hWnd);

                                            var button = new KryptonCheckBox
                                            {
                                                AutoCheck = (control.WinInfo.dwStyle & PlatformInvoke.BS_.AUTO3STATE) == PlatformInvoke.BS_.AUTO3STATE
                                                            || (control.WinInfo.dwStyle & PlatformInvoke.BS_.AUTOCHECKBOX) == PlatformInvoke.BS_.AUTOCHECKBOX,
                                                ThreeState = (control.WinInfo.dwStyle & PlatformInvoke.BS_.AUTO3STATE) == PlatformInvoke.BS_.AUTO3STATE
                                                             || (control.WinInfo.dwStyle & PlatformInvoke.BS_._3STATE) == PlatformInvoke.BS_._3STATE,
                                                AutoSize = false,
                                                Text = control.Text,
                                                Dock = DockStyle.Fill,
                                                LabelStyle = LabelStyle.NormalPanel,
                                                Enabled = (control.WinInfo.dwStyle & PlatformInvoke.WS_.DISABLED) == 0,
                                            };
                                            panel.Controls.Add(button);
                                            control.Button = button;
                                            button.Click += delegate
                                            {
                                                PlatformInvoke.SendMessage(control.hWnd, PlatformInvoke.BM_CLICK, IntPtr.Zero, IntPtr.Zero);
                                                ClickCallback.Invoke(control);
                                            };
                                            PlatformInvoke.ShowWindow(control.hWnd, PlatformInvoke.ShowWindowCommands.SW_HIDE);
                                        }
                                        else // Normal Button
                                        {
                                            var panel = new KryptonPanel
                                            {
                                                Size = control.Size
                                            };
                                            panel.Location = control.ClientLocation;
                                            PlatformInvoke.SetParent(panel.Handle, hWnd);

                                            var button = new KryptonButton
                                            {
                                                AutoSize = false,
                                                Text = control.Text,
                                                Dock = DockStyle.Fill,
                                                Enabled = (control.WinInfo.dwStyle & PlatformInvoke.WS_.DISABLED) == 0
                                            };
                                            panel.Controls.Add(button);
                                            control.Button = button;
                                            button.Click += delegate
                                            {
                                                PlatformInvoke.SendMessage(control.hWnd, PlatformInvoke.BM_CLICK, IntPtr.Zero, IntPtr.Zero);
                                                ClickCallback.Invoke(control);
                                            };
                                            PlatformInvoke.ShowWindow(control.hWnd, PlatformInvoke.ShowWindowCommands.SW_HIDE);

                                        }
                                    }
                                    break;
                                default:
                                    PlatformInvoke.SendMessage(control.hWnd, PlatformInvoke.WM_.SETFONT, labelLogFont, new IntPtr(1));
                                    break;
                            }
                        }
                        if (_embed && !_embeddingDone)
                        {
                            PerformEmbedding(hWnd);
                            return (true, new IntPtr(1));
                        }
                    }
                    break;
                case PlatformInvoke.WM_.DESTROY:
                    if (_embeddingDone)
                    {
                        _toolBox.Close();
                    }

                    break;
                case PlatformInvoke.WM_.PAINT:
                    {
                        foreach (Attributes control in _controls)
                        {
                            if ((control.WinInfo.dwStyle & PlatformInvoke.WS_.VISIBLE) != PlatformInvoke.WS_.VISIBLE)
                            {
                                continue;
                            }

                            if (control.ClassName != @"button")
                            {
                                continue;
                            }

                            if ((control.WinInfo.dwStyle & PlatformInvoke.BS_.GROUPBOX) == PlatformInvoke.BS_.GROUPBOX)
                            {
                                PlatformInvoke.PAINTSTRUCT ps = new();

                                // Do we need to BeginPaint or just take the given HDC?
                                var hdc = PlatformInvoke.BeginPaint(control.hWnd, ref ps);
                                if (hdc == IntPtr.Zero)
                                {
                                    break;
                                }

                                using (Graphics g = Graphics.FromHdc(hdc))
                                {
                                    g.SmoothingMode = SmoothingMode.AntiAlias;
                                    var lineColor = _manager.GlobalCustomPalette!.GetBorderColor1(PaletteBorderStyle.ControlGroupBox, PaletteState.Normal);
                                    DrawRoundedRectangle(g, new Pen(lineColor), new Point(0, 10), control.Size - new Size(1, 11), 5);
                                    var font = _manager.GlobalCustomPalette!.GetContentShortTextFont(
                                        PaletteContentStyle.LabelNormalPanel, PaletteState.Normal);
                                    TextRenderer.DrawText(g, control.Text, font, new Point(4, 0), _defaultFontColor, _backColor,
                                        TextFormatFlags.HidePrefix | TextFormatFlags.NoClipping);
                                }

                                PlatformInvoke.EndPaint(control.hWnd, ref ps);
                            }
                        }

                        break;
                    }
                case PlatformInvoke.WM_.CTLCOLORDLG:
                    {
                        if (_backBrush == IntPtr.Zero)
                        {
                            _backBrush = PlatformInvoke.CreateSolidBrush(ColorTranslator.ToWin32(_backColor));
                        }
                        return (true, _backBrush);
                    }
                case PlatformInvoke.WM_.CTLCOLORSTATIC:
                    // WM_CTLCOLORSTATIC was the correct way to control the color of the group box title.
                    // However, it no longer works: If your application uses a manifest to include the version 6 comctl library,
                    // the Groupbox control no longer sends the WM_CTLCOLORSTATIC to its parent to get a brush

                    PlatformInvoke.SetTextColor(wparam, ColorTranslator.ToWin32(_defaultFontColor));
                    PlatformInvoke.SetBkColor(wparam, ColorTranslator.ToWin32(_backColor));
                    //PlatformInvoke.SetBkMode(wparam, ColorTranslator.ToWin32(Color.Transparent));
                    return (true, _backBrush);
                case PlatformInvoke.WM_.CTLCOLORBTN:
                    {
                        // By default, the DefWindowProc function selects the default system colors for the button.
                        // Buttons with the BS_PUSHBUTTON, BS_DEFPUSHBUTTON, or BS_PUSHLIKE styles do not use the returned brush.
                        // Buttons with these styles are always drawn with the default system colors.
                        // Drawing push buttons requires several different brushes-face, highlight, and shadow
                        // but the WM_CTLCOLORBTN message allows only one brush to be returned.
                        var fontColour = _manager.GlobalCustomPalette!.GetContentShortTextColor1(PaletteContentStyle.ButtonStandalone, PaletteState.Normal);
                        var backColour = _manager.GlobalCustomPalette!.GetBackColor1(PaletteBackStyle.ButtonStandalone, PaletteState.Normal);
                        PlatformInvoke.SetTextColor(wparam, ColorTranslator.ToWin32(fontColour));
                        PlatformInvoke.SetBkColor(wparam, ColorTranslator.ToWin32(backColour));
                        //PlatformInvoke.SetBkMode(wparam, ColorTranslator.ToWin32(Color.Transparent));
                        return (true, _backBrush);
                    }
                //else if (msg == PlatformInvoke.WM_.CTLCOLORLISTBOX)
                //{
                //    var fontColour = _kryptonManager.GlobalPalette.GetContentShortTextColor1(PaletteContentStyle.InputControlStandalone, PaletteState.Normal);
                //    var backColour = _kryptonManager.GlobalPalette.GetBackColor1(PaletteBackStyle.InputControlStandalone, PaletteState.Normal);
                //    PlatformInvoke.SetTextColor(wparam, ColorTranslator.ToWin32(fontColour));
                //    PlatformInvoke.SetBkColor(wparam, ColorTranslator.ToWin32(backColour));
                //    PlatformInvoke.SetBkMode(wparam, ColorTranslator.ToWin32(Color.Black));
                //    return PlatformInvoke.CreateSolidBrush(ColorTranslator.ToWin32(backColour));
                //    ////return _backBrush;
                //}
                case PlatformInvoke.WM_.CTLCOLOREDIT:
                    {
                        var backColour = _manager.GlobalCustomPalette!.GetBackColor1(PaletteBackStyle.InputControlStandalone, PaletteState.Normal);
                        PlatformInvoke.SetTextColor(wparam, ColorTranslator.ToWin32(_inputFontColor));
                        PlatformInvoke.SetBkColor(wparam, ColorTranslator.ToWin32(backColour));
                        PlatformInvoke.SetBkMode(wparam, ColorTranslator.ToWin32(Color.Black));
                        return (true, PlatformInvoke.CreateSolidBrush(ColorTranslator.ToWin32(backColour)));
                    }
            }

            return (false, IntPtr.Zero);
        }

        public Action<Attributes /*control*/> ClickCallback { get; set; }

        public IReadOnlyList<Attributes> Controls => _controls.AsReadOnly();

        private void PerformEmbedding(IntPtr hWnd)
        {
            var controlType = PlatformInvoke.GetWindowLong(hWnd, PlatformInvoke.GWL_.STYLE);
            controlType &= ~(PlatformInvoke.WS_.POPUPWINDOW | PlatformInvoke.WS_.CAPTION | PlatformInvoke.WS_.DLGFRAME | PlatformInvoke.WS_.OVERLAPPEDWINDOW);
            controlType |= PlatformInvoke.WS_.CHILD | PlatformInvoke.WS_.VISIBLE | PlatformInvoke.WS_.GROUP;
            PlatformInvoke.SetWindowLong(hWnd, PlatformInvoke.GWL_.STYLE, controlType);

            var lExStyle = PlatformInvoke.GetWindowLong(hWnd, PlatformInvoke.GWL_.EXSTYLE);
            lExStyle &= ~(PlatformInvoke.WS_EX_.DLGMODALFRAME | PlatformInvoke.WS_EX_.CLIENTEDGE | PlatformInvoke.WS_EX_.STATICEDGE);
            PlatformInvoke.SetWindowLong(hWnd, PlatformInvoke.GWL_.EXSTYLE, lExStyle);
            PlatformInvoke.GetWindowInfo(hWnd, out var winInfo);
            var text = new StringBuilder(64);
            PlatformInvoke.GetWindowText(hWnd, text, 64);
            _toolBox = new KryptonForm
            {
                AutoScaleMode = AutoScaleMode.Font,
                ClientSize = new Size(winInfo.rcClient.right - winInfo.rcClient.left, winInfo.rcClient.bottom - winInfo.rcClient.top),
                FormBorderStyle = FormBorderStyle.FixedToolWindow,
                StartPosition = FormStartPosition.Manual,
                Name = text.ToString(),
                Text = text.ToString(),
                Location = new Point(winInfo.rcWindow.left, winInfo.rcWindow.top),
                Padding = new Padding(0),
                TopMost = true
            };
            if (ShowIcon)
            {
                _toolBox.FormBorderStyle = FormBorderStyle.Fixed3D;
                _toolBox.MaximizeBox = false;
                _toolBox.MinimizeBox = false;
                _toolBox.Icon = Icon;
            }

            Size toolBoxClientSize = _toolBox.ClientSize;
            var kryptonPanel1 = new KryptonPanel
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Name = "kryptonPanel1",
                ClientSize = toolBoxClientSize,
                TabIndex = 0,
                Margin = new Padding(0),
                Padding = new Padding(0)
            };
            _toolBox.Controls.Add(kryptonPanel1);

            PlatformInvoke.MoveWindow(hWnd, 0, 0, toolBoxClientSize.Width, toolBoxClientSize.Height, false);
            var toolParent = PlatformInvoke.GetParent(hWnd);
            PlatformInvoke.SetParent(hWnd, kryptonPanel1.Handle);
            var nativeWindow = new NativeWindow();
            nativeWindow.AssignHandle(toolParent);
            _toolBox.Show(nativeWindow);
            _embeddingDone = true;
        }

        public bool EmbeddingDone => _embeddingDone;

        private static bool EnumerateChildWindow(IntPtr hWnd, IntPtr lParam)
        {
            var result = false;
            GCHandle gch = GCHandle.FromIntPtr(lParam);
            if (gch.Target is List<IntPtr> list)
            {
                list.Add(hWnd);
                result = true; // return true as long as children are found
            }
            return result;
        }

        private static void DrawRoundedRectangle(Graphics g, Pen pen, Point location, Size size, int radius)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var roundRect = new RoundedRectangleF(size.Width, size.Height, radius, location.X, location.Y);
            g.DrawPath(pen, roundRect.Path);
        }

        internal bool SetNewPosAndClientSize(Point loc, Size size)
        {
            if (size == Size.Empty)
            {
                return false; // Probably already been triggered !
            }

            _toolBox.Location = loc;
            _toolBox.ClientSize = size;
            return true;
        }

        #endregion
    }

    #region Class: Attributes

    public class Attributes
    {
        public IntPtr hWnd;

        public string Text;

        public PlatformInvoke.WINDOWINFO WinInfo;

        public string ClassName { get; set; }

        public Point ClientLocation { get; set; }

        public Size Size { get; set; }

        public int DlgCtrlId { get; set; }

        public VisualControlBase Button { get; set; }
    }

    #endregion
}