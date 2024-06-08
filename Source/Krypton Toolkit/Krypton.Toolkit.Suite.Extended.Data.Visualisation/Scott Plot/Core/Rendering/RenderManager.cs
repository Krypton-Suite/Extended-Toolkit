﻿namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class RenderManager(Plot plot)
    {
        /// <summary>
        /// This list of actions is performed in sequence to render a plot.
        /// It may be modified externally to inject custom functionality.
        /// </summary>
        public List<IRenderAction> RenderActions { get; } = DefaultRenderActions;

        /// <summary>
        /// Information about the previous render
        /// </summary>
        public RenderDetails LastRender { get; private set; }

        /// <summary>
        /// These events are invoked before any render action.
        /// Users can add blocking code to this event to ensure processes
        /// that modify plottables are complete before rendering begins.
        /// </summary>
        public EventHandler PreRenderLock { get; set; } = delegate { };

        /// <summary>
        /// This event is invoked just before each render, 
        /// after axis limits are determined and axis limits are set
        /// </summary>
        public EventHandler<RenderPack> RenderStarting { get; set; } = delegate { };

        /// <summary>
        /// This event is invoked after each render
        /// </summary>
        public EventHandler<RenderDetails> RenderFinished { get; set; } = delegate { };

        /// <summary>
        /// This event a render where the figure size (in pixels) changed from the previous render
        /// </summary>
        public EventHandler<RenderDetails> SizeChanged { get; set; } = delegate { };

        /// <summary>
        /// This event a render where the axis limits (in coordinate units) changed from the previous render
        /// </summary>
        public EventHandler<RenderDetails> AxisLimitsChanged { get; set; } = delegate { };

        /// <summary>
        /// Indicates whether this plot is in the process of executing a render
        /// </summary>
        public bool IsRendering { get; private set; } = false;

        /// <summary>
        /// Disable this in multiplot environments
        /// </summary>
        public bool ClearCanvasBeforeRendering { get; set; } = true;


        /// <summary>
        /// If false, any calls to Render() return immediately
        /// </summary>
        public bool EnableRendering { get; set; } = true;

        public bool EnableEvents { get; set; } = true;

        private Plot Plot { get; } = plot;

        /// <summary>
        /// Total number of renders completed
        /// </summary>
        public int RenderCount { get; private set; } = 0;

        public static List<IRenderAction> DefaultRenderActions => new()
    {
        new PreRenderLock(),
        new ClearCanvas(),
        new ReplaceNullAxesWithDefaults(),
        new AutoScaleUnsetAxes(),
        new ExecutePlottableAxisManagers(),
        new ApplyAxisRulesBeforeLayout(),
        new CalculateLayout(),
        new ApplyAxisRulesAfterLayout(),
        new RegenerateTicks(),
        new InvokePreRenderEvent(),
        new RenderBackground(),
        new RenderGridsBelowPlotables(),
        new RenderPlotables(),
        new RenderGridsAbovePlotables(),
        new RenderLegends(),
        new RenderPanels(),
        new RenderZoomRectangle(),
        new SyncGlPlotables(),
        new RenderPlotablesLast(),
        new RenderBenchmark(),
    };

        public void Render(SKCanvas canvas, PixelRect rect)
        {
            if (EnableRendering == false)
            {
                return;
            }

            IsRendering = true;
            canvas.Scale(Plot.ScaleFactor);

            List<(string, TimeSpan)> actionTimes = new();

            RenderPack rp = new(Plot, rect, canvas);

            Stopwatch sw = new();
            foreach (IRenderAction action in RenderActions)
            {
                if (action is ClearCanvas && !ClearCanvasBeforeRendering)
                {
                    continue;
                }

                sw.Restart();
                rp.Canvas.Save();
                action.Render(rp);
                rp.Canvas.Restore();
                actionTimes.Add((action.ToString() ?? string.Empty, sw.Elapsed));
            }

            LastRender = new(rp, actionTimes.ToArray(), LastRender);

            if (EnableEvents)
            {
                RenderFinished.Invoke(Plot, LastRender);

                if (LastRender.SizeChanged)
                {
                    SizeChanged.Invoke(Plot, LastRender);
                }

                if (LastRender.AxisLimitsChanged)
                {
                    AxisLimitsChanged.Invoke(Plot, LastRender);
                }
            }

            // TODO: event for when layout changes

            RenderCount += 1;

            IsRendering = false;
        }
    }
}