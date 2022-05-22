#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public struct Tick
    {
        public readonly double Position;
        public readonly string Label;
        public readonly bool IsMajor;
        public readonly bool IsDateTime;
        public DateTime DateTime => DateTime.FromOADate(Position);

        public Tick(double position, string label, bool isMajor, bool isDateTime)
        {
            Position = position;
            Label = label;
            IsMajor = isMajor;
            IsDateTime = isDateTime;
        }

        public override string ToString()
        {
            string tickType = IsMajor ? "Major Tick" : "Minor Tick";
            string tickLabel = string.IsNullOrEmpty(Label) ? "(unlabeled)" : $"labeled '{Label}'";
            string tickPosition = IsDateTime ? DateTime.ToString() : Position.ToString();
            return $"{tickType} at {tickPosition} {tickLabel}";
        }
    }
}