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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.krtbErrorMessage = new Krypton.Toolkit.KryptonRichTextBox();
            this.DefaultRightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.autoAxisMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.openInNewWindowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.DefaultRightClickMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Navy;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 300);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // krtbErrorMessage
            // 
            this.krtbErrorMessage.Location = new System.Drawing.Point(21, 24);
            this.krtbErrorMessage.Name = "krtbErrorMessage";
            this.krtbErrorMessage.Size = new System.Drawing.Size(186, 84);
            this.krtbErrorMessage.StateCommon.Back.Color1 = System.Drawing.Color.Maroon;
            this.krtbErrorMessage.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.krtbErrorMessage.StateCommon.Content.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.krtbErrorMessage.TabIndex = 2;
            this.krtbErrorMessage.Text = "Error Message";
            // 
            // DefaultRightClickMenu
            // 
            this.DefaultRightClickMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DefaultRightClickMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.DefaultRightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyMenuItem,
            this.saveImageMenuItem,
            this.toolStripSeparator1,
            this.autoAxisMenuItem,
            this.toolStripSeparator2,
            this.helpMenuItem,
            this.toolStripSeparator3,
            this.openInNewWindowMenuItem});
            this.DefaultRightClickMenu.Name = "contextMenuStrip1";
            this.DefaultRightClickMenu.Size = new System.Drawing.Size(191, 132);
            // 
            // copyMenuItem
            // 
            this.copyMenuItem.Name = "copyMenuItem";
            this.copyMenuItem.Size = new System.Drawing.Size(190, 22);
            this.copyMenuItem.Text = "Copy Image";
            this.copyMenuItem.Click += new System.EventHandler(this.copyMenuItem_Click);
            // 
            // saveImageMenuItem
            // 
            this.saveImageMenuItem.Name = "saveImageMenuItem";
            this.saveImageMenuItem.Size = new System.Drawing.Size(190, 22);
            this.saveImageMenuItem.Text = "Save Image As...";
            this.saveImageMenuItem.Click += new System.EventHandler(this.saveImageMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(187, 6);
            // 
            // autoAxisMenuItem
            // 
            this.autoAxisMenuItem.Name = "autoAxisMenuItem";
            this.autoAxisMenuItem.Size = new System.Drawing.Size(190, 22);
            this.autoAxisMenuItem.Text = "Zoom to Fit Data";
            this.autoAxisMenuItem.Click += new System.EventHandler(this.autoAxisMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(187, 6);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(190, 22);
            this.helpMenuItem.Text = "Help";
            this.helpMenuItem.Click += new System.EventHandler(this.helpMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(187, 6);
            // 
            // openInNewWindowMenuItem
            // 
            this.openInNewWindowMenuItem.Name = "openInNewWindowMenuItem";
            this.openInNewWindowMenuItem.Size = new System.Drawing.Size(190, 22);
            this.openInNewWindowMenuItem.Text = "Open in New Window";
            this.openInNewWindowMenuItem.Click += new System.EventHandler(this.openInNewWindowMenuItem_Click);
            // 
            // FormsPlot
            // 
            this.Controls.Add(this.krtbErrorMessage);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FormsPlot";
            this.Size = new System.Drawing.Size(400, 300);
            this.Load += new System.EventHandler(this.FormsPlot_Load);
            this.SizeChanged += new System.EventHandler(this.OnSizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.DefaultRightClickMenu.ResumeLayout(false);
            this.ResumeLayout(false);

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

                    krtbErrorMessage.Text = "ERROR: ScottPlot failed to render in design mode.\n\n" +
                                            "This may be due to incompatible System.Drawing.Common versions or a 32-bit/64-bit mismatch.\n\n" +
                                            "Although rendering failed at design time, it may still function normally at runtime.\n\n" +
                                            $"Exception details:\n{e}";
                    
                    return;
                }
            }

            Cursors = new Dictionary<Cursor, System.Windows.Forms.Cursor>()
            {
                [ScottPlot.Cursor.Arrow] = System.Windows.Forms.Cursors.Arrow,
                [ScottPlot.Cursor.WE] = System.Windows.Forms.Cursors.SizeWE,
                [ScottPlot.Cursor.NS] = System.Windows.Forms.Cursors.SizeNS,
                [ScottPlot.Cursor.All] = System.Windows.Forms.Cursors.SizeAll,
                [ScottPlot.Cursor.Crosshair] = System.Windows.Forms.Cursors.Cross,
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
                Plot.SaveFig(sfd.FileName);
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
