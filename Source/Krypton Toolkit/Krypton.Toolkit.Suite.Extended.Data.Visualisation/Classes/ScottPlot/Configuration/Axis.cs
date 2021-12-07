namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public class Axis
    {
        public bool hasBeenSet = false;
        public double boundMin = double.NegativeInfinity;
        public double boundMax = double.PositiveInfinity;

        private double _min;
        public double Min
        {
            get
            {
                return _min;
            }
            set
            {
                _min = value;
                hasBeenSet = true;
            }
        }

        private double _max;
        public double Max
        {
            get
            {
                return _max;
            }
            set
            {
                _max = value;
                hasBeenSet = true;
            }
        }

        public double Span
        {
            get
            {
                return Max - Min;
            }
        }

        public double Center
        {
            get
            {
                return (Max + Min) / 2;
            }
        }

        public void Pan(double delta)
        {
            if (delta == 0)
                return;

            if ((delta < 0) && (Min + delta < boundMin))
            {
                var originalSpan = Span;
                Min = boundMin;
                Max = Min + originalSpan;
                return;
            }

            if ((delta > 0) && (Max + delta > boundMax))
            {
                var originalSpan = Span;
                Max = boundMax;
                Min = Max - originalSpan;
                return;
            }

            Min += delta;
            Max += delta;
        }

        public void Zoom(double frac = 1, double? zoomTo = null)
        {
            zoomTo = zoomTo ?? Center;
            double spanLeft = (double)zoomTo - Min;
            double spanRight = Max - (double)zoomTo;
            Min = (double)zoomTo - spanLeft / frac;
            Max = (double)zoomTo + spanRight / frac;
            ApplyBounds();
        }

        public override string ToString()
        {
            return $"axis [{Min} to {Max}]";
        }

        public void ApplyBounds()
        {
            Min = Math.Max(Min, boundMin);
            Max = Math.Min(Max, boundMax);
        }
    }
}