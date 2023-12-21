#region MIT License
/*
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

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    /// <summary>
    /// Describes how a render should be performed with respect to quality.
    /// High quality enables anti-aliasing but is slower.
    /// Some options describe multiple renders, with or without a delay between them.
    /// </summary>
    public enum RenderType

    {
        /// <summary>
        /// Only render using low quality (anti-aliasing off)
        /// </summary>
        LowQuality,

        /// <summary>
        /// Only render using high quality (anti-aliasing on)
        /// </summary>
        HighQuality,

        /// <summary>
        /// Perform a high quality render after a delay.
        /// This is the best render type to use when resizing windows.
        /// </summary>
        HighQualityDelayed,

        /// <summary>
        /// Render low quality and display it, then if no new render requests
        /// have been received immediately render a high quality version and display it.
        /// This is the best render option to use when requesting renders programmatically
        /// </summary>
        LowQualityThenHighQuality,

        /// <summary>
        /// Render low quality and display it, wait a small period of time for new render requests to arrive,
        /// and if no new requests have been received render a high quality version and display it.
        /// This is the best render option to use for mouse interaction.
        /// </summary>
        LowQualityThenHighQualityDelayed,

        /// <summary>
        /// Process mouse events only (pan, zoom, etc) and do not render graphics on a Bitmap,
        /// then if no new requests have been received render using the last-used render type.
        /// </summary>
        ProcessMouseEventsOnly,
    }
}