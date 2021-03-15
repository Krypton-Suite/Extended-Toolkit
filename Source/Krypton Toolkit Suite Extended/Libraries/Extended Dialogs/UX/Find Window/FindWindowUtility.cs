#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class FindWindowUtility : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnClose;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private KryptonGroupBox kryptonGroupBox1;
        private Base.KryptonBorderedLabel kblPoint;
        private KryptonLabel kryptonLabel6;
        private Base.KryptonBorderedLabel kblRect;
        private KryptonLabel kryptonLabel5;
        private Base.KryptonBorderedLabel kblClass;
        private KryptonLabel kryptonLabel4;
        private Base.KryptonBorderedLabel kblCaption;
        private KryptonLabel kryptonLabel3;
        private System.Windows.Forms.ToolTip toolTip;
        private System.ComponentModel.IContainer components;
        private KryptonLabel kryptonLabel2;
        private KryptonLabel kryptonLabel1;
        private System.Windows.Forms.PictureBox pbxHitTarget;
        private KryptonLabel klblCursor;
        private System.Windows.Forms.ImageList imageList;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindWindowUtility));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnClose = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.klblCursor = new Krypton.Toolkit.KryptonLabel();
            this.pbxHitTarget = new System.Windows.Forms.PictureBox();
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.kblPoint = new Krypton.Toolkit.Suite.Extended.Base.KryptonBorderedLabel();
            this.kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            this.kblRect = new Krypton.Toolkit.Suite.Extended.Base.KryptonBorderedLabel();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.kblClass = new Krypton.Toolkit.Suite.Extended.Base.KryptonBorderedLabel();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kblCaption = new Krypton.Toolkit.Suite.Extended.Base.KryptonBorderedLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHitTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnClose);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 262);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(380, 42);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnClose
            // 
            this.kbtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnClose.Location = new System.Drawing.Point(278, 5);
            this.kbtnClose.Name = "kbtnClose";
            this.kbtnClose.Size = new System.Drawing.Size(90, 25);
            this.kbtnClose.TabIndex = 0;
            this.kbtnClose.Values.Text = "C&lose";
            this.kbtnClose.Click += new System.EventHandler(this.kbtnClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 259);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 3);
            this.panel1.TabIndex = 1;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.klblCursor);
            this.kryptonPanel2.Controls.Add(this.pbxHitTarget);
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(380, 259);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // klblCursor
            // 
            this.klblCursor.Location = new System.Drawing.Point(196, 56);
            this.klblCursor.Name = "klblCursor";
            this.klblCursor.Size = new System.Drawing.Size(6, 2);
            this.klblCursor.TabIndex = 6;
            this.klblCursor.Values.Text = "";
            // 
            // pbxHitTarget
            // 
            this.pbxHitTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxHitTarget.BackColor = System.Drawing.Color.Transparent;
            this.pbxHitTarget.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxHitTarget.Image = ((System.Drawing.Image)(resources.GetObject("pbxHitTarget.Image")));
            this.pbxHitTarget.Location = new System.Drawing.Point(158, 54);
            this.pbxHitTarget.Name = "pbxHitTarget";
            this.pbxHitTarget.Size = new System.Drawing.Size(32, 32);
            this.pbxHitTarget.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxHitTarget.TabIndex = 5;
            this.pbxHitTarget.TabStop = false;
            this.toolTip.SetToolTip(this.pbxHitTarget, "Start dragging ...");
            this.pbxHitTarget.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxHitTarget_MouseDown);
            this.pbxHitTarget.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbxHitTarget_MouseMove);
            this.pbxHitTarget.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbxHitTarget_MouseUp);
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(12, 103);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kblPoint);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel6);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kblRect);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel5);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kblClass);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel4);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kblCaption);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel3);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(356, 150);
            this.kryptonGroupBox1.TabIndex = 3;
            this.kryptonGroupBox1.Values.Heading = "Found Window Details";
            // 
            // kblPoint
            // 
            this.kblPoint.AutoSize = false;
            this.kblPoint.BackColor = System.Drawing.Color.Transparent;
            this.kblPoint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(192)))), ((int)(((byte)(214)))));
            this.kblPoint.Location = new System.Drawing.Point(77, 90);
            this.kblPoint.Name = "kblPoint";
            this.kblPoint.Size = new System.Drawing.Size(261, 20);
            this.kblPoint.TabIndex = 8;
            this.kblPoint.Values.Text = "";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(15, 90);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(42, 20);
            this.kryptonLabel6.TabIndex = 9;
            this.kryptonLabel6.Values.Text = "Point:";
            // 
            // kblRect
            // 
            this.kblRect.AutoSize = false;
            this.kblRect.BackColor = System.Drawing.Color.Transparent;
            this.kblRect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(192)))), ((int)(((byte)(214)))));
            this.kblRect.Location = new System.Drawing.Point(77, 64);
            this.kblRect.Name = "kblRect";
            this.kblRect.Size = new System.Drawing.Size(261, 20);
            this.kblRect.TabIndex = 6;
            this.kblRect.Values.Text = "";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(15, 64);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(37, 20);
            this.kryptonLabel5.TabIndex = 7;
            this.kryptonLabel5.Values.Text = "Rect:";
            // 
            // kblClass
            // 
            this.kblClass.AutoSize = false;
            this.kblClass.BackColor = System.Drawing.Color.Transparent;
            this.kblClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(192)))), ((int)(((byte)(214)))));
            this.kblClass.Location = new System.Drawing.Point(77, 38);
            this.kblClass.Name = "kblClass";
            this.kblClass.Size = new System.Drawing.Size(261, 20);
            this.kblClass.TabIndex = 4;
            this.kblClass.Values.Text = "";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(15, 38);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(41, 20);
            this.kryptonLabel4.TabIndex = 5;
            this.kryptonLabel4.Values.Text = "Class:";
            // 
            // kblCaption
            // 
            this.kblCaption.AutoSize = false;
            this.kblCaption.BackColor = System.Drawing.Color.Transparent;
            this.kblCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(192)))), ((int)(((byte)(214)))));
            this.kblCaption.Location = new System.Drawing.Point(77, 12);
            this.kblCaption.Name = "kblCaption";
            this.kblCaption.Size = new System.Drawing.Size(261, 20);
            this.kblCaption.TabIndex = 3;
            this.kblCaption.Values.Text = "";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(15, 12);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(56, 20);
            this.kryptonLabel3.TabIndex = 3;
            this.kryptonLabel3.Values.Text = "Caption:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(77, 56);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(75, 20);
            this.kryptonLabel2.TabIndex = 3;
            this.kryptonLabel2.Values.Text = "Finder Tool:";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(358, 36);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Drag the Finder Tool over a window to select it, then release the \r\nmouse button." +
    "";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "");
            this.imageList.Images.SetKeyName(1, "");
            // 
            // FindWindowUtility
            // 
            this.ClientSize = new System.Drawing.Size(380, 304);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "FindWindowUtility";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHitTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Enums
        public enum GetSystem_Metrics : int
        {
            SM_CXBORDER = 5,
            SM_CXFULLSCREEN = 16,
            SM_CYFULLSCREEN = 17
        }
        #endregion

        #region API
        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(int smIndex);
        #endregion

        #region Variables
        private IntPtr _lastWindow = IntPtr.Zero;
        #endregion

        #region Constructor
        public FindWindowUtility()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        /// <summary>
		/// Paint a rect into the given window
		/// </summary>
		/// <param name="window"></param>
		static void ShowInvertRectTracker(IntPtr window)
        {
            if (window != IntPtr.Zero)
            {
                // get the coordinates from the window on the screen
                Rectangle WindowRect = Dialogs.Window.GetWindowRect(window);
                // get the window's device context
                IntPtr dc = Dialogs.Window.GetWindowDC(window);

                // Create an inverse pen that is the size of the window border
                Dialogs.Gdi.SetROP2(dc, (int)Dialogs.Gdi.RopMode.R2_NOT);

                Color color = Color.FromArgb(0, 255, 0);
                IntPtr Pen = Dialogs.Gdi.CreatePen((int)Dialogs.Gdi.PenStyles.PS_INSIDEFRAME, 3 * GetSystemMetrics((int)GetSystem_Metrics.SM_CXBORDER), (uint)color.ToArgb());

                // Draw the rectangle around the window
                IntPtr OldPen = Dialogs.Gdi.SelectObject(dc, Pen);
                IntPtr OldBrush = Dialogs.Gdi.SelectObject(dc, Dialogs.Gdi.GetStockObject((int)Dialogs.Gdi.StockObjects.NULL_BRUSH));
                Dialogs.Gdi.Rectangle(dc, 0, 0, WindowRect.Width, WindowRect.Height);

                Dialogs.Gdi.SelectObject(dc, OldBrush);
                Dialogs.Gdi.SelectObject(dc, OldPen);

                //release the device context, and destroy the pen
                Dialogs.Window.ReleaseDC(window, dc);
                Dialogs.Gdi.DeleteObject(Pen);
            }
        }

        /// <summary>
        /// return the window from the given point
        /// </summary>
        /// <param name="point"></param>
        /// <returns>if return == IntPtr.Zero no window was found</returns>
        static IntPtr ChildWindowFromPoint(Point point)
        {
            IntPtr WindowPoint = Dialogs.Window.WindowFromPoint(point);
            if (WindowPoint == IntPtr.Zero)
                return IntPtr.Zero;

            if (Dialogs.Window.ScreenToClient(WindowPoint, ref point) == false)
                throw new Exception("ScreenToClient failed");

            IntPtr Window = Dialogs.Window.ChildWindowFromPointEx(WindowPoint, point, 0);
            if (Window == IntPtr.Zero)
                return WindowPoint;

            if (Dialogs.Window.ClientToScreen(WindowPoint, ref point) == false)
                throw new Exception("ClientToScreen failed");

            if (Dialogs.Window.IsChild(Dialogs.Window.GetParent(Window), Window) == false)
                return Window;

            // create a list to hold all childs under the point
            ArrayList WindowList = new ArrayList();
            while (Window != IntPtr.Zero)
            {
                Rectangle rect = Dialogs.Window.GetWindowRect(Window);
                if (rect.Contains(point))
                    WindowList.Add(Window);
                Window = Dialogs.Window.GetWindow(Window, (uint)Dialogs.Window.GetWindow_Cmd.GW_HWNDNEXT);
            }

            // search for the smallest window in the list
            int MinPixel = GetSystemMetrics((int)GetSystem_Metrics.SM_CXFULLSCREEN) * GetSystemMetrics((int)GetSystem_Metrics.SM_CYFULLSCREEN);
            for (int i = 0; i < WindowList.Count; ++i)
            {
                Rectangle rect = Dialogs.Window.GetWindowRect((IntPtr)WindowList[i]);
                int ChildPixel = rect.Width * rect.Height;
                if (ChildPixel < MinPixel)
                {
                    MinPixel = ChildPixel;
                    Window = (IntPtr)WindowList[i];
                }
            }
            return Window;
        }

        /// <summary>
		/// Show informations about the given window
		/// </summary>
		/// <param name="window"></param>
		private void DisplayWindowInfo(IntPtr window)
        {
            if (window == IntPtr.Zero)
            {
                // reset all edit box
                kblCaption.Text = "";
                kblRect.Text = "";
                kblPoint.Text = "";
                kblClass.Text = "";
            }
            else
            {
                // Caption
                /*
				StringBuilder WindowText = new StringBuilder(ApiWrapper.Window.GetWindowTextLength(window) + 1);
				ApiWrapper.Window.GetWindowText(window, WindowText, WindowText.Capacity);
				kblCaption.Text = WindowText.ToString();
				*/
                kblCaption.Text = Dialogs.Window.GetWindowText(window);
                // Class
                StringBuilder ClassName = new StringBuilder(256);
                int ret = Dialogs.Window.GetClassName(window, ClassName, ClassName.Capacity);
                kblClass.Text = ClassName.ToString();
                // Rect
                Rectangle WindowRect = Dialogs.Window.GetWindowRect(window);
                kblRect.Text = WindowRect.ToString();
                // Point
                Point point = System.Windows.Forms.Cursor.Position;
                Dialogs.Window.ScreenToClient(window, ref point);
                kblPoint.Text = point.ToString();
            }
        }
        #endregion

        #region Overrides
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }
        #endregion

        private void kbtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pbxHitTarget_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Cursor = new Cursor(GetType(), "Resources\\Target.cur");

                pbxHitTarget.Image = imageList.Images[0];
            }
        }

        private void pbxHitTarget_MouseMove(object sender, MouseEventArgs e)
        {
            if (Cursor != Cursors.Default)
            {
                IntPtr FoundWindow = ChildWindowFromPoint(Cursor.Position);

                // not this application
                if (Control.FromHandle(FoundWindow) == null)
                {
                    if (FoundWindow != _lastWindow)
                    {
                        // clear old window
                        ShowInvertRectTracker(_lastWindow);
                        // set new window
                        _lastWindow = FoundWindow;
                        // paint new window
                        ShowInvertRectTracker(_lastWindow);
                    }
                    DisplayWindowInfo(_lastWindow);
                }
                // show global mouse cursor
                klblCursor.Text = $"Cursor: { Cursor.Position }";
            }
        }

        private void pbxHitTarget_MouseUp(object sender, MouseEventArgs e)
        {
            if (Cursor != Cursors.Default)
            {
                // reset all done things from mouse_down and mouse_move ...
                ShowInvertRectTracker(_lastWindow);
                _lastWindow = IntPtr.Zero;

                Cursor = Cursors.Default;
                pbxHitTarget.Image = imageList.Images[1];
            }
        }
    }
}