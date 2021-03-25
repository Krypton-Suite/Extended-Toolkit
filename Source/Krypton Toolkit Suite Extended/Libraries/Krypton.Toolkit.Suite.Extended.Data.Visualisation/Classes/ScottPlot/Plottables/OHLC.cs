﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public class OHLC
    {
        public double open;
        public double high;
        public double low;
        public double close;
        public double time;
        public double timeSpan = 1;

        public double highestOpenClose;
        public double lowestOpenClose;
        public bool closedHigher;

        public OHLC(double open, double high, double low, double close, DateTime dateTime, double timeSpan = 1)
        {
            this.open = open;
            this.high = high;
            this.low = low;
            this.close = close;
            time = dateTime.ToOADate();
            this.timeSpan = timeSpan;

            highestOpenClose = Math.Max(open, close);
            lowestOpenClose = Math.Min(open, close);
            closedHigher = (close > open) ? true : false;
        }

        public OHLC(double open, double high, double low, double close, double time, double timeSpan = 1)
        {
            this.open = open;
            this.high = high;
            this.low = low;
            this.close = close;
            this.time = time;
            this.timeSpan = timeSpan;

            highestOpenClose = Math.Max(open, close);
            lowestOpenClose = Math.Min(open, close);
            closedHigher = (close > open) ? true : false;
        }

        public override string ToString()
        {
            return $"OHLC: open={open}, high={high}, low={low}, close={close}, timestamp={time}";
        }
    }
}
