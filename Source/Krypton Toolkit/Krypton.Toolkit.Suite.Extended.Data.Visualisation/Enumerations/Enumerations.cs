namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
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
}