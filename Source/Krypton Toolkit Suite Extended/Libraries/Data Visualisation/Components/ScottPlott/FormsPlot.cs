using Krypton.Toolkit.Suite.Extended.Core;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public partial class FormsPlot : UserControl
    {
        #region Design Code
        private IContainer components = null;

        private PictureBox pbxPlot;

        private KryptonLabel klblTitle, klblVersion;

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbxPlot = new System.Windows.Forms.PictureBox();
            this.klblTitle = new KryptonLabel();
            this.klblVersion = new KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPlot)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxPlot
            // 
            this.pbxPlot.BackColor = System.Drawing.Color.Navy;
            this.pbxPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxPlot.Location = new System.Drawing.Point(0, 0);
            this.pbxPlot.Name = "pbxPlot";
            this.pbxPlot.Size = new System.Drawing.Size(500, 350);
            this.pbxPlot.TabIndex = 0;
            this.pbxPlot.TabStop = false;
            this.pbxPlot.SizeChanged += new System.EventHandler(this.pbxPlot_SizeChanged);
            this.pbxPlot.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pbxPlot_MouseDoubleClick);
            this.pbxPlot.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxPlot_MouseDown);
            this.pbxPlot.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbxPlot_MouseMove);
            pbxPlot.MouseWheel += new MouseEventHandler(pbxPlot_MouseWheel);
            this.pbxPlot.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbxPlot_MouseUp);
            // 
            // klblTitle
            // 
            this.klblTitle.AutoSize = true;
            this.klblTitle.BackColor = System.Drawing.Color.Navy;
            this.klblTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblTitle.ForeColor = System.Drawing.Color.White;
            this.klblTitle.Location = new System.Drawing.Point(3, 2);
            this.klblTitle.Name = "klblTitle";
            this.klblTitle.Size = new System.Drawing.Size(137, 37);
            this.klblTitle.TabIndex = 1;
            this.klblTitle.Text = "ScottPlot";
            // 
            // klblVersion
            // 
            this.klblVersion.BackColor = System.Drawing.Color.Navy;
            this.klblVersion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblVersion.ForeColor = System.Drawing.Color.White;
            this.klblVersion.Location = new System.Drawing.Point(10, 39);
            this.klblVersion.Name = "klblVersion";
            this.klblVersion.Size = new System.Drawing.Size(130, 37);
            this.klblVersion.TabIndex = 2;
            this.klblVersion.Text = "0.0.0.0";
            this.klblVersion.StateCommon.ShortText.TextH = PaletteRelativeAlign.Far;
            // 
            // FormsPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.klblVersion);
            this.Controls.Add(this.klblTitle);
            this.Controls.Add(this.pbxPlot);
            this.Name = "FormsPlot";
            this.Size = new System.Drawing.Size(500, 350);
            ((System.ComponentModel.ISupportInitialize)(this.pbxPlot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }
        #endregion

        #region Variables
        private Settings settings;

        private bool isDesignerMode;

        public System.Windows.Forms.Cursor cursor = Cursors.Arrow;
        #endregion

        #region Properties
        public Plot Plot { get; private set; }

        public override Color BackColor { get => base.BackColor; set { base.BackColor = value; pbxPlot.BackColor = value; } }
        #endregion

        #region Constructors
        public FormsPlot(Plot plot)
        {
            InitializeComponent();

            Reset(plot);
        }

        public FormsPlot()
        {
            InitializeComponent();

            Reset(null);
        }
        #endregion

        #region Methods
        public void Reset()
        {
            Reset(null);
        }

        public void Reset(Plot Plot)
        {
            if (Plot is null)
            {
                Plot = new Plot();
                InitializeScottPlot();
            }
            else
            {
                Plot = Plot;
                InitializeScottPlot(applyDefaultStyle: false);
            }
            Render();
        }

        private void InitializeScottPlot(bool applyDefaultStyle = true)
        {
            ContextMenuStrip = DefaultRightClickMenu();

            pbxPlot.MouseWheel += pbxPlot_MouseWheel;

            isDesignerMode = Process.GetCurrentProcess().ProcessName == "devenv";
            klblTitle.Visible = isDesignerMode;
            klblVersion.Visible = isDesignerMode;
            klblVersion.Text = Tools.GetVersionString();
            pbxPlot.BackColor = ColorTranslator.FromHtml("#003366");
            klblTitle.BackColor = ColorTranslator.FromHtml("#003366");
            klblVersion.BackColor = ColorTranslator.FromHtml("#003366");

            if (applyDefaultStyle)
                Plot.Style(Style.Control);

            settings = Plot.GetSettings(showWarning: false);

            pbxPlot_MouseUp(null, null);
            pbxPlot_SizeChanged(null, null);
        }

        private ContextMenuStrip DefaultRightClickMenu()
        {
            var cms = new ContextMenuStrip();
            cms.Items.Add(new ToolStripMenuItem("&Save Image", null, new EventHandler(SaveImage)));
            cms.Items.Add(new ToolStripMenuItem("Copy I&mage", null, new EventHandler(CopyImage)));
            cms.Items.Add(new ToolStripMenuItem("O&pen in New Window", null, new EventHandler(OpenNewWindow)));
            cms.Items.Add(new ToolStripMenuItem("&Settings", null, new EventHandler(OpenSettingsWindow)));
            //cms.Items.Add(new ToolStripMenuItem("&Help", null, new EventHandler(OpenHelpWindow)));
            return cms;
        }

        private bool currentlyRendering;
        public void Render(bool skipIfCurrentlyRendering = false, bool lowQuality = false, bool recalculateLayout = false, bool processEvents = false)
        {
            if (isDesignerMode)
                return;

            if (recalculateLayout)
                Plot.TightenLayout();

            if (equalAxes)
                Plot.AxisEqual();

            if (!(skipIfCurrentlyRendering && currentlyRendering))
            {
                currentlyRendering = true;
                pbxPlot.Image = Plot?.GetBitmap(true, lowQuality || lowQualityAlways);
                if (isPanningOrZooming || isMovingDraggable || processEvents)
                    Application.DoEvents();
                currentlyRendering = false;
                Rendered?.Invoke(this, EventArgs.Empty);
            }
        }
        #endregion

        private void pbxPlot_SizeChanged(object sender, EventArgs e)
        {
            if (Plot is null)
                return;

            Plot.Resize(Width, Height);
            Render(skipIfCurrentlyRendering: false);
        }

        #region user control Visualisationuration

        private bool plotContainsHeatmap => settings?.plottables.Where(p => p is PlottableHeatmap).Count() > 0;

        private bool enablePanning = true;
        private bool enableRightClickZoom = true;
        private bool enableScrollWheelZoom = true;
        private bool lowQualityWhileDragging = true;
        private bool lowQualityAlways = false;
        private bool doubleClickingTogglesBenchmark = true;
        private bool lockVerticalAxis = false;
        private bool lockHorizontalAxis = false;
        private bool equalAxes = false;
        private double middleClickMarginX = .1;
        private double middleClickMarginY = .1;
        private bool? recalculateLayoutOnMouseUp = null;
        private bool showCoordinatesTooltip = false;
        public void Visualisationure(
            bool? enablePanning = null,
            bool? enableZooming = null,
            bool? enableRightClickMenu = null,
            bool? enableScrollWheelZoom = null,
            bool? lowQualityWhileDragging = null,
            bool? lowQualityAlways = null,
            bool? enableDoubleClickBenchmark = null,
            bool? lockVerticalAxis = null,
            bool? lockHorizontalAxis = null,
            bool? equalAxes = null,
            double? middleClickMarginX = null,
            double? middleClickMarginY = null,
            bool? recalculateLayoutOnMouseUp = null,
            bool? showCoordinatesTooltip = null
            )
        {
            if (enablePanning != null) this.enablePanning = (bool)enablePanning;
            if (enableZooming != null) this.enableRightClickZoom = (bool)enableZooming;
            if (enableRightClickMenu != null) ContextMenuStrip = (enableRightClickMenu.Value) ? DefaultRightClickMenu() : null;
            if (enableScrollWheelZoom != null) this.enableScrollWheelZoom = (bool)enableScrollWheelZoom;
            if (lowQualityWhileDragging != null) this.lowQualityWhileDragging = (bool)lowQualityWhileDragging;
            if (lowQualityAlways != null) this.lowQualityAlways = (bool)lowQualityAlways;
            if (enableDoubleClickBenchmark != null) this.doubleClickingTogglesBenchmark = (bool)enableDoubleClickBenchmark;
            if (lockVerticalAxis != null) this.lockVerticalAxis = (bool)lockVerticalAxis;
            if (lockHorizontalAxis != null) this.lockHorizontalAxis = (bool)lockHorizontalAxis;
            if (equalAxes != null) this.equalAxes = (bool)equalAxes;
            this.middleClickMarginX = middleClickMarginX ?? this.middleClickMarginX;
            this.middleClickMarginY = middleClickMarginY ?? this.middleClickMarginY;
            this.recalculateLayoutOnMouseUp = recalculateLayoutOnMouseUp;
            this.showCoordinatesTooltip = showCoordinatesTooltip ?? this.showCoordinatesTooltip;
        }

        private bool isShiftPressed { get { return (ModifierKeys.HasFlag(Keys.Shift) || (lockHorizontalAxis)); } }
        private bool isCtrlPressed { get { return (ModifierKeys.HasFlag(Keys.Control) || (lockVerticalAxis)); } }
        private bool isAltPressed { get { return ModifierKeys.HasFlag(Keys.Alt); } }

        #endregion

        #region mouse tracking

        ToolTip tooltip = new ToolTip();
        private Point? mouseLeftDownLocation, mouseRightDownLocation, mouseMiddleDownLocation;
        double[] axisLimitsOnMouseDown;
        private bool isPanningOrZooming
        {
            get
            {
                if (axisLimitsOnMouseDown is null) return false;
                if (mouseLeftDownLocation != null) return true;
                else if (mouseRightDownLocation != null) return true;
                else if (mouseMiddleDownLocation != null) return true;
                return false;
            }
        }

        IDraggable plottableBeingDragged = null;
        private bool isMovingDraggable { get { return (plottableBeingDragged != null); } }

        private System.Windows.Forms.Cursor GetCursor(Visualisation.Cursor scottPlotCursor)
        {
            switch (scottPlotCursor)
            {
                case Visualisation.Cursor.ARROW: return Cursors.Arrow;
                case Visualisation.Cursor.WE: return Cursors.SizeWE;
                case Visualisation.Cursor.NS: return Cursors.SizeNS;
                case Visualisation.Cursor.ALL: return Cursors.SizeAll;
                default: return Cursors.Help;
            }
        }

        private void pbxPlot_MouseDown(object sender, MouseEventArgs e)
        {
            var mousePixel = e.Location;
            plottableBeingDragged = Plot.GetDraggableUnderMouse(mousePixel.X, mousePixel.Y);

            if (plottableBeingDragged is null)
            {
                // MouseDown event is to start a pan or zoom
                if (e.Button == MouseButtons.Left && ModifierKeys.HasFlag(Keys.Alt)) mouseMiddleDownLocation = e.Location;
                else if (e.Button == MouseButtons.Left && enablePanning) mouseLeftDownLocation = e.Location;
                else if (e.Button == MouseButtons.Right && enableRightClickZoom) mouseRightDownLocation = e.Location;
                else if (e.Button == MouseButtons.Middle && enableScrollWheelZoom) mouseMiddleDownLocation = e.Location;
                axisLimitsOnMouseDown = Plot.Axis();
            }
            else
            {
                // mouse is being used to drag a plottable
                OnMouseDownOnPlottable(EventArgs.Empty);
            }

            base.OnMouseDown(e);
        }

        [Obsolete("use Plot.CoordinateFromPixelX() and Plot.CoordinateFromPixelY()")]
        public PointF mouseCoordinates { get { return Plot.CoordinateFromPixel(mouseLocation); } }
        Point mouseLocation;

        private int dpiScale = 1; //Heres hoping that WinForms becomes DPI aware

        private void pbxPlot_MouseMove(object sender, MouseEventArgs e)
        {
            mouseLocation = e.Location;
            OnMouseMoved(e);

            tooltip.Hide(this);
            if (isPanningOrZooming)
                MouseMovedToPanOrZoom(e);
            else if (isMovingDraggable)
                MouseMovedToMoveDraggable(e);
            else
                MouseMovedWithoutInteraction(e);

            base.OnMouseMove(e);
        }


        private void MouseMovedToPanOrZoom(MouseEventArgs e)
        {
            Plot.Axis(axisLimitsOnMouseDown);

            if (mouseLeftDownLocation != null)
            {
                // left-click-drag panning
                int deltaX = ((Point)mouseLeftDownLocation).X - e.Location.X;
                int deltaY = e.Location.Y - ((Point)mouseLeftDownLocation).Y;

                if (isCtrlPressed) deltaY = 0;
                if (isShiftPressed) deltaX = 0;

                settings.AxesPanPx(deltaX, deltaY);
                OnAxisChanged();
            }
            else if (mouseRightDownLocation != null)
            {
                // right-click-drag zooming
                int deltaX = ((Point)mouseRightDownLocation).X - e.Location.X;
                int deltaY = e.Location.Y - ((Point)mouseRightDownLocation).Y;

                if (isCtrlPressed == true && isShiftPressed == false) deltaY = 0;
                if (isShiftPressed == true && isCtrlPressed == false) deltaX = 0;

                settings.AxesZoomPx(-deltaX, -deltaY, lockRatio: isCtrlPressed && isShiftPressed);
                OnAxisChanged();
            }
            else if (mouseMiddleDownLocation != null)
            {
                // middle-click-drag zooming to rectangle
                int x1 = Math.Min(e.Location.X, ((Point)mouseMiddleDownLocation).X);
                int x2 = Math.Max(e.Location.X, ((Point)mouseMiddleDownLocation).X);
                int y1 = Math.Min(e.Location.Y, ((Point)mouseMiddleDownLocation).Y);
                int y2 = Math.Max(e.Location.Y, ((Point)mouseMiddleDownLocation).Y);

                Point origin = new Point(x1 - settings.dataOrigin.X, y1 - settings.dataOrigin.Y);
                Size size = new Size(x2 - x1, y2 - y1);

                if (lockVerticalAxis)
                {
                    origin.Y = 0;
                    size.Height = settings.dataSize.Height - 1;
                }
                if (lockHorizontalAxis)
                {
                    origin.X = 0;
                    size.Width = settings.dataSize.Width - 1;
                }

                settings.mouseMiddleRect = new Rectangle(origin, size);
            }

            Render(true, lowQuality: lowQualityWhileDragging);
            return;
        }

        public (double x, double y) GetMouseCoordinates()
        {
            double x = Plot.CoordinateFromPixelX(mouseLocation.X / dpiScale);
            double y = Plot.CoordinateFromPixelY(mouseLocation.Y / dpiScale);
            return (x, y);
        }

        private void MouseMovedToMoveDraggable(MouseEventArgs e)
        {
            plottableBeingDragged.DragTo(
                Plot.CoordinateFromPixelX(e.Location.X),
                Plot.CoordinateFromPixelY(e.Location.Y),
                isShiftPressed, isAltPressed, isCtrlPressed);
            OnMouseDragPlottable(EventArgs.Empty);
            Render(true, lowQuality: lowQualityWhileDragging);
        }

        private void MouseMovedWithoutInteraction(MouseEventArgs e)
        {
            if (showCoordinatesTooltip)
            {
                double coordX = Plot.CoordinateFromPixelX(e.Location.X);
                double coordY = Plot.CoordinateFromPixelY(e.Location.Y);
                tooltip.Show($"{coordX:N2}, {coordY:N2}", this, e.Location.X + 15, e.Location.Y);
            }

            // set the cursor based on what's beneath it
            var draggableUnderCursor = Plot.GetDraggableUnderMouse(e.Location.X, e.Location.Y);
            var spCursor = (draggableUnderCursor is null) ? Visualisation.Cursor.ARROW : draggableUnderCursor.DragCursor;
            pbxPlot.Cursor = GetCursor(spCursor);
        }

        private void pbxPlot_MouseUp(object sender, MouseEventArgs e)
        {
            if (mouseMiddleDownLocation != null)
            {
                int x1 = Math.Min(e.Location.X, ((Point)mouseMiddleDownLocation).X);
                int x2 = Math.Max(e.Location.X, ((Point)mouseMiddleDownLocation).X);
                int y1 = Math.Min(e.Location.Y, ((Point)mouseMiddleDownLocation).Y);
                int y2 = Math.Max(e.Location.Y, ((Point)mouseMiddleDownLocation).Y);

                Point topLeft = new Point(x1, y1);
                Size size = new Size(x2 - x1, y2 - y1);
                Point botRight = new Point(topLeft.X + size.Width, topLeft.Y + size.Height);

                if ((size.Width > 2) && (size.Height > 2))
                {
                    // only change axes if suffeciently large square was drawn
                    if (!lockHorizontalAxis)
                        Plot.Axis(
                            x1: Plot.CoordinateFromPixelX(topLeft.X),
                            x2: Plot.CoordinateFromPixelX(botRight.X));
                    if (!lockVerticalAxis)
                        Plot.Axis(
                            y1: Plot.CoordinateFromPixelY(botRight.Y),
                            y2: Plot.CoordinateFromPixelY(topLeft.Y));
                    OnAxisChanged();
                }
                else
                {
                    bool shouldTighten = recalculateLayoutOnMouseUp ?? plotContainsHeatmap == false;
                    Plot.AxisAuto(middleClickMarginX, middleClickMarginY, tightenLayout: shouldTighten);
                    OnAxisChanged();
                }
            }

            if (mouseRightDownLocation != null)
            {
                int deltaX = Math.Abs(((Point)mouseRightDownLocation).X - e.Location.X);
                int deltaY = Math.Abs(((Point)mouseRightDownLocation).Y - e.Location.Y);
                bool mouseDraggedFar = (deltaX > 3 || deltaY > 3);

                if (mouseDraggedFar)
                    ContextMenuStrip?.Hide();
                else
                    OnMenuDeployed();
            }

            if (isPanningOrZooming)
            {
                OnMouseDragged(EventArgs.Empty);
            }

            if (plottableBeingDragged != null)
            {
                OnMouseDropPlottable(EventArgs.Empty);
            }

            OnMouseClicked(e);
            base.OnMouseUp(e);

            mouseLeftDownLocation = null;
            mouseRightDownLocation = null;
            mouseMiddleDownLocation = null;
            axisLimitsOnMouseDown = null;
            settings.mouseMiddleRect = null;
            plottableBeingDragged = null;

            bool shouldRecalculate = recalculateLayoutOnMouseUp ?? plotContainsHeatmap == false;
            Render(recalculateLayout: shouldRecalculate);
        }

        private void pbxPlot_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OnMouseDoubleClicked(e);
            base.OnMouseDoubleClick(e);
        }

        private void pbxPlot_MouseWheel(object sender, MouseEventArgs e)
        {
            if (enableScrollWheelZoom == false)
                return;

            double xFrac = (e.Delta > 0) ? 1.15 : 0.85;
            double yFrac = (e.Delta > 0) ? 1.15 : 0.85;

            if (isCtrlPressed) yFrac = 1;
            if (isShiftPressed) xFrac = 1;

            Plot.AxisZoom(xFrac, yFrac, Plot.CoordinateFromPixelX(e.Location.X), Plot.CoordinateFromPixelY(e.Location.Y));

            bool shouldRecalculate = recalculateLayoutOnMouseUp ?? plotContainsHeatmap == false;
            Render(recalculateLayout: shouldRecalculate);
            OnAxisChanged();

            base.OnMouseWheel(e);
        }

        #endregion

        #region menus and forms

        private void SaveImage(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "ScottPlot.png";
            savefile.Filter = "PNG Files (*.png)|*.png;*.png";
            savefile.Filter += "|JPG Files (*.jpg, *.jpeg)|*.jpg;*.jpeg";
            savefile.Filter += "|BMP Files (*.bmp)|*.bmp;*.bmp";
            savefile.Filter += "|TIF files (*.tif, *.tiff)|*.tif;*.tiff";
            savefile.Filter += "|All files (*.*)|*.*";
            if (savefile.ShowDialog() == DialogResult.OK)
                Plot.SaveFig(savefile.FileName);
        }

        private void CopyImage(object sender, EventArgs e)
        {
            Clipboard.SetImage(Plot.GetBitmap(true));
        }

        private void OpenSettingsWindow(object sender, EventArgs e)
        {
            new SettingsWindow(Plot).ShowDialog();

            Render();
        }

        private void OpenHelpWindow(object sender, EventArgs e)
        {
            GlobalUtilityMethods.NotImplementedYet();
            //new HelpWindow().ShowDialog();
        }

        private void OpenNewWindow(object sender, EventArgs e)
        {
            new PlotViewerWindow(Plot.Copy()).Show();
        }

        #endregion

        #region custom events

        public event EventHandler Rendered;
        public event EventHandler MouseDownOnPlottable;
        public event EventHandler MouseDragPlottable;
        public event MouseEventHandler MouseMoved;
        public event EventHandler MouseDragged;
        public event EventHandler MouseDropPlottable;
        public event EventHandler AxesChanged;
        public event MouseEventHandler MouseClicked;
        public event MouseEventHandler MouseDoubleClicked;
        public event MouseEventHandler MenuDeployed;
        protected virtual void OnMouseDownOnPlottable(EventArgs e) { MouseDownOnPlottable?.Invoke(this, e); }
        protected virtual void OnMouseDragPlottable(EventArgs e) { MouseDragPlottable?.Invoke(this, e); }
        protected virtual void OnMouseMoved(MouseEventArgs e) { MouseMoved?.Invoke(this, e); }
        protected virtual void OnMouseDragged(EventArgs e) { MouseDragged?.Invoke(this, e); }
        protected virtual void OnMouseDropPlottable(EventArgs e) { MouseDropPlottable?.Invoke(this, e); }
        protected virtual void OnMouseClicked(MouseEventArgs e) { MouseClicked?.Invoke(this, e); }
        protected virtual void OnAxisChanged() { AxesChanged?.Invoke(this, null); }

        protected virtual void OnMouseDoubleClicked(MouseEventArgs e)
        {
            MouseDoubleClicked?.Invoke(this, e);
            if (doubleClickingTogglesBenchmark)
            {
                Plot.Benchmark(toggle: true);
                Render();
            }
        }

        protected virtual void OnMenuDeployed()
        {
            MenuDeployed?.Invoke(this, null);
        }

        #endregion
    }
}