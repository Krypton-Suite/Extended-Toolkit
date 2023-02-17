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

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    /// <summary>
    /// This class takes details about interactions and builds them into event objects which can 
    /// be passed into the event processor for processing/rendering when the render queue is free.
    /// </summary>
    public class UIEventFactory
    {
        public readonly Plot Plot;
        public readonly Configuration Configuration;
        public readonly Settings Settings;

        public UIEventFactory(Configuration config, Settings settings, Plot plt)
        {
            Configuration = config;
            Settings = settings;
            Plot = plt;
        }

        public IUIEvent CreateBenchmarkToggle() =>
            new BenchmarkToggleEvent(Plot, Configuration);

        public IUIEvent CreateApplyZoomRectangleEvent(float x, float y) =>
            new ApplyZoomRectangleEvent(x, y, Configuration, Settings, Plot);

        public IUIEvent CreateMouseAutoAxis() =>
            new MouseAxisAutoEvent(Configuration, Settings, Plot);

        public IUIEvent CreateMouseMovedToZoomRectangle(float x, float y) =>
             new MouseMovedToZoomRectangle(x, y, Settings, Configuration);

        public IUIEvent CreateMousePan(InputState input) =>
            new MousePanEvent(input, Configuration, Settings);

        public IUIEvent CreateMouseScroll(float x, float y, bool scroolUp) =>
            new MouseScrollEvent(x, y, scroolUp, Configuration, Settings);

        public IUIEvent CreateMouseUpClearRender() =>
            new MouseUpClearRenderEvent(Configuration);

        public IUIEvent CreateMouseZoom(InputState input) =>
            new MouseZoomEvent(input, Configuration, Settings, Plot);

        public IUIEvent CreatePlottableDrag(float x, float y, bool shiftDown, IDraggable? draggable) =>
             new PlottableDragEvent(x, y, shiftDown, draggable, Plot, Configuration);

        public IUIEvent CreateManualLowQualityRender() => new RenderLowQuality();

        public IUIEvent CreateManualHighQualityRender() => new RenderHighQuality();

        public IUIEvent CreateManualDelayedHighQualityRender() => new RenderDelayedHighQuality();
    }
}