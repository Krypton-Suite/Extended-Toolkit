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
    public class DefaultBottomAxis : Axis
    {
        public DefaultBottomAxis()
        {
            Edge = Edge.Bottom;
            Grid(true);
        }
    }

    public class DefaultTopAxis : Axis
    {
        public DefaultTopAxis()
        {
            Edge = Edge.Top;
            AxisIndex = 1;
            Grid(false);
            Ticks(false);
        }
    }

    public class DefaultLeftAxis : Axis
    {
        public DefaultLeftAxis()
        {
            Edge = Edge.Left;
            Grid(true);
        }
    }

    public class DefaultRightAxis : Axis
    {
        public DefaultRightAxis()
        {
            Edge = Edge.Right;
            AxisIndex = 1;
            Grid(false);
            Ticks(false);
        }
    }

    public class AdditionalRightAxis : Axis
    {
        public AdditionalRightAxis(int yAxisIndex, string title)
        {
            Edge = Edge.Right;
            AxisIndex = yAxisIndex;
            Grid(false);
            Ticks(true);
            Label(title);
        }
    }

    public class AdditionalLeftAxis : Axis
    {
        public AdditionalLeftAxis(int yAxisIndex, string title)
        {
            Edge = Edge.Left;
            AxisIndex = yAxisIndex;
            Grid(false);
            Ticks(true);
            Label(title);
        }
    }

    public class AdditionalTopAxis : Axis
    {
        public AdditionalTopAxis(int xAxisIndex, string title)
        {
            Edge = Edge.Top;
            AxisIndex = xAxisIndex;
            Grid(false);
            Ticks(true);
            Label(title);
        }
    }

    public class AdditionalBottomAxis : Axis
    {
        public AdditionalBottomAxis(int xAxisIndex, string title)
        {
            Edge = Edge.Bottom;
            AxisIndex = xAxisIndex;
            Grid(false);
            Ticks(true);
            Label(title);
        }
    }
}
