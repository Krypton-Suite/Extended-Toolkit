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

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class FormsPlot : UserControl
    {
        #region Designer Code
        private PictureBox pictureBox1;
        private KryptonRichTextBox krtbErrorMessage;
        private ContextMenuStrip DefaultRightClickMenu;
        private IContainer components;
        private ToolStripMenuItem copyMenuItem;
        private ToolStripMenuItem saveImageMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem autoAxisMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem helpMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem openInNewWindowMenuItem;

        private void InitializeComponent()
        {
            components = new Container();
            pictureBox1 = new PictureBox();
            krtbErrorMessage = new KryptonRichTextBox();
            DefaultRightClickMenu = new ContextMenuStrip(components);
            copyMenuItem = new ToolStripMenuItem();
            saveImageMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            autoAxisMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            helpMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            openInNewWindowMenuItem = new ToolStripMenuItem();
            ((ISupportInitialize)(pictureBox1)).BeginInit();
            DefaultRightClickMenu.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Navy;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(400, 300);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // krtbErrorMessage
            // 
            krtbErrorMessage.Location = new Point(21, 24);
            krtbErrorMessage.Name = "krtbErrorMessage";
            krtbErrorMessage.Size = new Size(186, 84);
            krtbErrorMessage.StateCommon.Back.Color1 = Color.Maroon;
            krtbErrorMessage.StateCommon.Content.Color1 = Color.White;
            krtbErrorMessage.StateCommon.Content.Font = new System.Drawing.Font("Cascadia Code", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            krtbErrorMessage.TabIndex = 2;
            krtbErrorMessage.Text = "Error Message";
            // 
            // DefaultRightClickMenu
            // 
            DefaultRightClickMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            DefaultRightClickMenu.ImageScalingSize = new Size(20, 20);
            DefaultRightClickMenu.Items.AddRange(new ToolStripItem[] {
            copyMenuItem,
            saveImageMenuItem,
            toolStripSeparator1,
            autoAxisMenuItem,
            toolStripSeparator2,
            helpMenuItem,
            toolStripSeparator3,
            openInNewWindowMenuItem});
            DefaultRightClickMenu.Name = "contextMenuStrip1";
            DefaultRightClickMenu.Size = new Size(191, 132);
            // 
            // copyMenuItem
            // 
            copyMenuItem.Name = "copyMenuItem";
            copyMenuItem.Size = new Size(190, 22);
            copyMenuItem.Text = "Copy Image";
            copyMenuItem.Click += new EventHandler(copyMenuItem_Click);
            // 
            // saveImageMenuItem
            // 
            saveImageMenuItem.Name = "saveImageMenuItem";
            saveImageMenuItem.Size = new Size(190, 22);
            saveImageMenuItem.Text = "Save Image As...";
            saveImageMenuItem.Click += new EventHandler(saveImageMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(187, 6);
            // 
            // autoAxisMenuItem
            // 
            autoAxisMenuItem.Name = "autoAxisMenuItem";
            autoAxisMenuItem.Size = new Size(190, 22);
            autoAxisMenuItem.Text = "Zoom to Fit Data";
            autoAxisMenuItem.Click += new EventHandler(autoAxisMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(187, 6);
            // 
            // helpMenuItem
            // 
            helpMenuItem.Name = "helpMenuItem";
            helpMenuItem.Size = new Size(190, 22);
            helpMenuItem.Text = "Help";
            helpMenuItem.Click += new EventHandler(helpMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(187, 6);
            // 
            // openInNewWindowMenuItem
            // 
            openInNewWindowMenuItem.Name = "openInNewWindowMenuItem";
            openInNewWindowMenuItem.Size = new Size(190, 22);
            openInNewWindowMenuItem.Text = "Open in New Window";
            openInNewWindowMenuItem.Click += new EventHandler(openInNewWindowMenuItem_Click);
            // 
            // FormsPlot
            // 
            Controls.Add(krtbErrorMessage);
            Controls.Add(pictureBox1);
            Name = "FormsPlot";
            Size = new Size(400, 300);
            Load += new EventHandler(FormsPlot_Load);
            SizeChanged += new EventHandler(OnSizeChanged);
            ((ISupportInitialize)(pictureBox1)).EndInit();
            DefaultRightClickMenu.ResumeLayout(false);
            ResumeLayout(false);

        }
        #endregion

        #region Fields

        /// <summary>
        /// This is the plot displayed by the user control.
        /// After modifying it you may need to call Refresh() to request the plot be redrawn on the screen.
        /// </summary>
        public Plot Plot => Backend.Plot;

        /// <summary>
        /// This object can be used to modify advanced behaior and customization of this user control.
        /// </summary>
        public readonly Configuration Configuration;

        private readonly ControlBackEnd Backend;
        private readonly Dictionary<Cursor, System.Windows.Forms.Cursor> Cursors;
        private readonly bool IsDesignerMode = Process.GetCurrentProcess().ProcessName == "devenv";

        private bool _showContextMenu;

        #endregion

        #region Properties
        public bool ShowContextMenu
        {
            get => _showContextMenu;

            set
            {
                _showContextMenu = value;

                Invalidate();
            }
        }
        #endregion

        #region Events

        /// <summary>
        /// This event is invoked any time the axis limits are modified.
        /// </summary>
        public event EventHandler AxesChanged;

        /// <summary>
        /// This event is invoked any time the plot is right-clicked.
        /// By default it contains DefaultRightClickEvent(), but you can remove this and add your own method.
        /// </summary>
        public event EventHandler RightClicked;

        /// <summary>
        /// This event is invoked after the mouse moves while dragging a draggable plottable.
        /// The object passed is the plottable being dragged.
        /// </summary>
        public event EventHandler PlottableDragged;

        /// <summary>
        /// This event is invoked right after a draggable plottable was dropped.
        /// The object passed is the plottable that was just dropped.
        /// </summary>
        public event EventHandler PlottableDropped;
        #endregion

        #region Constructor

        public FormsPlot()
        {
            Backend = new ControlBackEnd(1, 1, "FormsPlot");

            Backend.Resize(Width, Height, false);

            Backend.BitmapChanged += Backend_BitmapChanged;

            Backend.BitmapUpdated += Backend_BitmapUpdated;

            Backend.CursorChanged += Backend_CursorChanged;

            Backend.RightClicked += Backend_RightClicked;

            Backend.AxesChanged += Backend_AxesChanged;

            Backend.PlottableDragged += Backend_PlottableDragged;

            Backend.PlottableDropped += Backend_PlottableDropped;

            Configuration = Backend.Configuration;

            if (IsDesignerMode)
            {
                try
                {
                    Configuration.WarnIfRenderNotCalledManually = false;

                    Plot.Title($"ScottPlot {Plot.Version}");

                    Plot.Render();
                }
                catch (Exception e)
                {
                    InitializeComponent();

                    pictureBox1.Visible = false;

                    krtbErrorMessage.Visible = true;

                    krtbErrorMessage.Dock = DockStyle.Fill;

                    krtbErrorMessage.Text =
                        $@"ERROR: ScottPlot failed to render in design mode.\n\nThis may be due to incompatible System.Drawing.Common versions or a 32-bit/64-bit mismatch.\n\nAlthough rendering failed at design time, it may still function normally at runtime.\n\nException details:\n{e}";

                    return;
                }
            }

            Cursors = new Dictionary<Cursor, System.Windows.Forms.Cursor>()
            {
                [ScottPlot.Cursor.Arrow] = System.Windows.Forms.Cursors.Arrow,
                [ScottPlot.Cursor.WE] = System.Windows.Forms.Cursors.SizeWE,
                [ScottPlot.Cursor.NS] = System.Windows.Forms.Cursors.SizeNS,
                [ScottPlot.Cursor.All] = System.Windows.Forms.Cursors.SizeAll,
                [ScottPlot.Cursor.CrossHair] = System.Windows.Forms.Cursors.Cross,
                [ScottPlot.Cursor.Hand] = System.Windows.Forms.Cursors.Hand,
                [ScottPlot.Cursor.Question] = System.Windows.Forms.Cursors.Help,
            };

            InitializeComponent();

            krtbErrorMessage.Visible = false;

            pictureBox1.BackColor = Color.Transparent;

            BackColor = Color.Transparent;

            Plot.Style(BackColor);

            pictureBox1.MouseWheel += PictureBox1_MouseWheel;

            pictureBox1.MouseDown += PictureBox1_MouseDown;

            pictureBox1.MouseUp += PictureBox1_MouseUp;

            pictureBox1.DoubleClick += PictureBox1_DoubleClick;

            pictureBox1.MouseMove += PictureBox1_MouseMove;

            pictureBox1.MouseEnter += PictureBox1_MouseEnter;

            pictureBox1.MouseLeave += PictureBox1_MouseLeave;

            RightClicked += DefaultRightClickedEvent;

            ShowContextMenu = true;

            Backend.StartProcessingEvents();
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Return the mouse position on the plot (in coordinate space) for the latest X and Y coordinates
        /// </summary>
        public (double x, double y) GetMouseCoordinates() => Backend.GetMouseCoordinates();

        /// <summary>
        /// Return the mouse position (in pixel space) for the last observed mouse position
        /// </summary>
        public (float x, float y) GetMousePixel() => Backend.GetMousePixel();

        /// <summary>
        /// Reset this control by replacing the current plot with a new empty plot
        /// </summary>
        public void Reset() => Backend.Reset(Width, Height);

        /// <summary>
        /// Reset this control by replacing the current plot with an existing plot
        /// </summary>
        public void Reset(Plot newPlot) => Backend.Reset(Width, Height, newPlot);

        /// <summary>
        /// Re-render the plot and update the image displayed by this control.
        /// </summary>
        /// <param name="lowQuality">disable anti-aliasing to produce faster (but lower quality) plots</param>
        /// <param name="skipIfCurrentlyRendering"></param>
        public void Refresh(bool lowQuality = false, bool skipIfCurrentlyRendering = false)
        {
            Application.DoEvents();
            Backend.WasManuallyRendered = true;
            Backend.Render(lowQuality, skipIfCurrentlyRendering);
        }

        /// <summary>
        /// Request the control to refresh the next time it is available.
        /// This method does not block the calling thread.
        /// </summary>
        public void RefreshRequest(RenderType renderType = RenderType.LowQualityThenHighQualityDelayed)
        {
            Backend.WasManuallyRendered = true;
            Backend.RenderRequest(renderType);
        }

        public void DefaultRightClickedEvent(object sender, EventArgs e)
        {
            DefaultRightClickMenu.Show(System.Windows.Forms.Cursor.Position);
        }

        private void PictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            Backend.MouseWheel(GetInputState(e));

            base.OnMouseWheel(e);
        }

        private void PictureBox1_MouseLeave(object sender, EventArgs e)
        {
            base.OnMouseLeave(e);
        }

        private void PictureBox1_MouseEnter(object sender, EventArgs e)
        {
            base.OnMouseEnter(e);
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Backend.MouseMove(GetInputState(e));

            base.OnMouseMove(e);
        }

        private void PictureBox1_DoubleClick(object sender, EventArgs e)
        {
            Backend.DoubleClick();

            base.OnDoubleClick(e);
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Backend.MouseUp(GetInputState(e));

            base.OnMouseUp(e);
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Backend.MouseMove(GetInputState(e));

            base.OnMouseMove(e);
        }

        private void Backend_PlottableDropped(object sender, EventArgs e)
        {
            PlottableDropped?.Invoke(sender, e);
        }

        private void Backend_PlottableDragged(object sender, EventArgs e)
        {
            PlottableDragged?.Invoke(sender, e);
        }

        private void Backend_AxesChanged(object sender, EventArgs e)
        {
            AxesChanged?.Invoke(this, e);
        }

        private void Backend_RightClicked(object sender, EventArgs e)
        {
            RightClicked?.Invoke(this, e);
        }

        private void Backend_CursorChanged(object sender, EventArgs e)
        {
            Cursor = Cursors[Backend.Cursor];
        }

        private void Backend_BitmapUpdated(object sender, EventArgs e)
        {
            Application.DoEvents();

            pictureBox1.Invalidate();
        }

        private void OnSizeChanged(object sender, EventArgs e) => Backend.Resize(Width, Height, true);

        private void Backend_BitmapChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Backend.GetLatestBitmap();
        }

        private void FormsPlot_Load(object sender, EventArgs e)
        {
            OnSizeChanged(null, null);
        }

        #endregion

        #region Methods

        private InputState GetInputState(MouseEventArgs mea) => new InputState()
        {
            X = mea.X,
            Y = mea.Y,
            LeftWasJustPressed = mea.Button == MouseButtons.Left,
            RightWasJustPressed = mea.Button == MouseButtons.Right,
            MiddleWasJustPressed = mea.Button == MouseButtons.Middle,
            ShiftDown = ModifierKeys.HasFlag(Keys.Shift),
            CtrlDown = ModifierKeys.HasFlag(Keys.Control),
            AltDown = ModifierKeys.HasFlag(Keys.Alt),
            WheelScrolledUp = mea.Delta > 0,
            WheelScrolledDown = mea.Delta < 0
        };

        #endregion

        private void copyMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(Plot.Render());
        }

        private void saveImageMenuItem_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                FileName = "ScottPlot.png",
                Filter = "PNG Files (*.png)|*.png;*.png" +
                         "|JPG Files (*.jpg, *.jpeg)|*.jpg;*.jpeg" +
                         "|BMP Files (*.bmp)|*.bmp;*.bmp" +
                         "|All files (*.*)|*.*"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Plot.SaveFig(sfd.FileName);
            }
        }

        private void autoAxisMenuItem_Click(object sender, EventArgs e)
        {
            Plot.AxisAuto();

            Refresh();
        }

        private void helpMenuItem_Click(object sender, EventArgs e)
        {
            ScottPlotHelp help = new ScottPlotHelp();

            help.ShowDialog();
        }

        private void openInNewWindowMenuItem_Click(object sender, EventArgs e)
        {
            new PlotViewer(Plot).Show();
        }

        #region Overrides

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_showContextMenu)
            {
                ContextMenuStrip = DefaultRightClickMenu;

                pictureBox1.ContextMenuStrip = DefaultRightClickMenu;
            }
            else
            {
                ContextMenuStrip = null;

                pictureBox1.ContextMenuStrip = null;
            }

            base.OnPaint(e);
        }

        #endregion
    }
}
