namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public static class Marker
    {
        // TODO: refactor this in the next major version of ScottPlot to add support for LineWidth, etc
        public static MarkerShape None => MarkerShape.NONE;
        public static MarkerShape FILLEDCIRCLE => MarkerShape.FILLEDCIRCLE;
        public static MarkerShape OPENCIRCLE => MarkerShape.OPENCIRCLE;
        public static MarkerShape FilledSquare => MarkerShape.FILLEDSQUARE;
        public static MarkerShape OpenSquare => MarkerShape.OPENSQUARE;
        public static MarkerShape FilledDiamond => MarkerShape.FILLEDDIAMOND;
        public static MarkerShape OpenDiamond => MarkerShape.OPENDIAMOND;
        public static MarkerShape Asterisk => MarkerShape.ASTERISK;
        public static MarkerShape HashTag => MarkerShape.HASHTAG;
        public static MarkerShape Cross => MarkerShape.CROSS;
        public static MarkerShape Eks => MarkerShape.EKS;
        public static MarkerShape VerticalBar => MarkerShape.VERTICALBAR;
        public static MarkerShape TriangleUp => MarkerShape.TRIUP;
        public static MarkerShape TriangleDown => MarkerShape.TRIDOWN;

        public static MarkerShape Random() => Random(new Random());

        public static MarkerShape Random(Random rand)
        {
            Array members = Enum.GetValues(typeof(MarkerShape));
            object randomMember = members.GetValue(rand.Next(members.Length));
            return (MarkerShape)randomMember;
        }
    }
}