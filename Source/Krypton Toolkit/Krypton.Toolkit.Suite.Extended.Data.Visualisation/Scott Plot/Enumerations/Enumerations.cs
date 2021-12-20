#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public enum MarkerShape
    {
        // TODO: replace this with ScottPlot.Marker in the next major version of ScottPlot
        NONE,
        FILLEDCIRCLE,
        FILLEDSQUARE,
        OPENCIRCLE,
        OPENSQUARE,
        FILLEDDIAMOND,
        OPENDIAMOND,
        ASTERISK,
        HASHTAG,
        CROSS,
        EKS,
        VERTICALBAR,
        TRIUP,
        TRIDOWN,
    }

    public enum QualityMode
    {
        /// <summary>
        /// Anti-aliasing always off
        /// </summary>
        LOW,


        /// <summary>
        /// Anti-aliasing off while dragging (more responsive) but on otherwise
        /// </summary>
        LOWWHILEDRAGGING,

        /// <summary>
        /// Anti-aliasing always on
        /// </summary>
        HIGH,
    }

    public enum HatchStyle
    {
        None,
        StripedUpwardDiagonal,
        StripedDownwardDiagonal,
        StripedWideUpwardDiagonal,
        StripedWideDownwardDiagonal,
        LargeCheckerBoard,
        SmallCheckerBoard,
        LargeGrid,
        SmallGrid,
        DottedDiamond
    }

    /// <summary>
    /// Vertical (upper/middle/lower) and Horizontal (left/center/right) alignment
    /// </summary>
    public enum Alignment
    {
        UpperLeft,
        UpperRight,
        UpperCenter,
        MiddleLeft,
        MiddleCenter,
        MiddleRight,
        LowerLeft,
        LowerRight,
        LowerCenter
    }

    public enum ArrowAnchor
    {
        /// <summary>
        /// X/Y coordinates define the base of the arrow
        /// </summary>
        Base,

        /// <summary>
        /// X/Y coordinates define the center of the arrow
        /// </summary>
        Center,

        /// <summary>
        /// X/Y coordinates define the tip of the arrow
        /// </summary>
        Tip,
    }

    public enum Cursor
    {
        Arrow,
        Crosshair,
        Hand,
        WE,
        NS,
        All,
        Question
    }

    /// <summary>
    /// Defines if/how axis scales (units per pixel) are matched between horizontal and vertical axes.
    /// </summary>
    public enum EqualScaleMode
    {
        /// <summary>
        /// Horizontal and vertical axes can be scaled independently. 
        /// Squares and circles may stretch to rectangles and ovals.
        /// </summary>
        Disabled,

        /// <summary>
        /// Axis scales are locked so geometry of squares and circles is preserved.
        /// After axes are set, the vertical scale (units per pixel) is applied to the horizontal axis.
        /// </summary>
        PreserveY,

        /// <summary>
        /// Axis scales are locked so geometry of squares and circles is preserved.
        /// After axes are set, the horizontal scale (units per pixel) is applied to the vertical axis.
        /// </summary>
        PreserveX,

        /// <summary>
        /// Axis scales are locked so geometry of squares and circles is preserved.
        /// After axes are set, the largest scale (most units per pixel) is applied to both axes.
        /// Apply the most zoomed-out scale to both axes.
        /// </summary>
        ZoomOut,


        /// <summary>
        /// Apply the scale of the larger axis to both axes.
        /// </summary>
        PreserveLargest,


        /// <summary>
        /// Apply the scale of the smaller axis to both axes.
        /// </summary>
        PreserveSmallest
    }

    public enum FillType
    {
        NoFill,
        FillAbove,
        FillBelow,
        FillAboveAndBelow
    }

    public enum HorizontalAlignment
    {
        Left,
        Right,
        Center
    }

    /// <summary>
    /// Defines how an image will be placed in Radar and CoxComb charts
    /// </summary>
    public enum ImagePlacement
    {
        /// <summary>
        /// Images will be aligned at the arms of the chart
        /// </summary>
        Outside,
        /// <summary>
        /// Images will be aligned halfway in the space between arms of the chart
        /// </summary>
        Inside
    }

    public enum IntensityMode
    {
        Gaussian,
        Density
    }

    public enum LineStyle
    {
        None,
        Solid,
        Dash,
        DashDot,
        DashDotDot,
        Dot
    }

    public enum PlotOrientation
    {
        Horizontal,
        Vertical
    }

    public enum RadarAxis
    {
        Circle,
        Polygon,
        None
    }

    public enum RadialGaugeMode
    {
        /// <summary>
        /// Successive gauges start outward from the center but start at the same angle
        /// </summary>
        Stacked,

        /// <summary>
        /// Successive gauges start outward from the center and start at sequential angles
        /// </summary>
        Sequential,

        /// <summary>
        /// Gauges are all the same distance from the center but start at sequential angles
        /// </summary>
        SingleGauge
    }

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

    public enum VerticalAlignment
    {
        Upper,
        Lower,
        Middle
    }

    public enum DateTimeUnit
    {
        ThousandYear,
        HundredYear, 
        TenYear, 
        Year,
        Month, 
        Day, 
        Hour, 
        Minute,
        Second, 
        Decisecond, 
        Centisecond,
        Millisecond
    }

    public enum TickLabelFormatOptions
    {
        Numeric, 
        DateTime
    } // TODO: add hex, binary, scientific notation, etc?

    public enum AxisOrientation
    {
        Vertical, 
        Horizontal
    }

    public enum MinorTickDistribution
    {
        even, 
        log
    };
}