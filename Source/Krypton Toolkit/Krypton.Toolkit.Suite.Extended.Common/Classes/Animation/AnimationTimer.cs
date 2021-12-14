#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Collections.Generic;
using System.Linq;

namespace Krypton.Toolkit.Suite.Extended.Common
{
    /// <summary>
    ///     The timer class, will execute your code in specific time frames
    /// </summary>
    public class AnimationTimer
    {
        private static Thread _timerThread;

        private static readonly object LockHandle = new object();

        private static readonly long StartTimeAsMs = DateTime.Now.Ticks;

        private static readonly List<AnimationTimer> Subscribers = new List<AnimationTimer>();

        private readonly Action<ulong> _callback;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AnimationTimer" /> class.
        /// </summary>
        /// <param name="callback">
        ///     The callback to be executed at each tick
        /// </param>
        /// <param name="fpsKnownLimit">
        ///     The max ticks per second
        /// </param>
        public AnimationTimer(Action<ulong> callback, FPSLimiterKnownValues fpsKnownLimit = FPSLimiterKnownValues.LimitThirty)
            : this(callback, (int)fpsKnownLimit)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AnimationTimer" /> class.
        /// </summary>
        /// <param name="callback">
        ///     The callback to be executed at each tick
        /// </param>
        /// <param name="fpsLimit">
        ///     The max ticks per second
        /// </param>
        public AnimationTimer(Action<ulong> callback, int fpsLimit)
        {
            if (callback == null)
            {
                throw new ArgumentNullException(nameof(callback));
            }

            _callback = callback;
            FrameLimiter = fpsLimit;
            lock (LockHandle)
            {
                if (_timerThread == null)
                {
                    (_timerThread = new Thread(ThreadCycle) { IsBackground = true }).Start();
                }
            }
        }

        /// <summary>
        ///     Gets the time of the last frame/tick related to the global-timer start reference
        /// </summary>
        public long LastTick { get; private set; }

        /// <summary>
        ///     Gets or sets the maximum frames/ticks per second
        /// </summary>
        public int FrameLimiter { get; set; }

        /// <summary>
        ///     Gets the time of the first frame/tick related to the global-timer start reference
        /// </summary>
        public long FirstTick { get; private set; }


        private void Tick()
        {
            if ((1000 / FrameLimiter) < (GetTimeDifferenceAsMs() - LastTick))
            {
                LastTick = GetTimeDifferenceAsMs();
                _callback((ulong)(LastTick - FirstTick));
            }
        }

        private static long GetTimeDifferenceAsMs()
        {
            return (DateTime.Now.Ticks - StartTimeAsMs) / 10000;
        }

        private static void ThreadCycle()
        {
            while (true)
            {
                try
                {
                    bool hibernate;
                    lock (Subscribers)
                    {
                        hibernate = Subscribers.Count == 0;
                        if (!hibernate)
                        {
                            foreach (var t in Subscribers.ToList())
                            {
                                t.Tick();
                            }
                        }
                    }

                    Thread.Sleep(hibernate ? 50 : 1);
                }
                catch
                {
                    // ignored
                }
            }
            // ReSharper disable once FunctionNeverReturns
        }

        /// <summary>
        ///     The method to reset the time of the starting frame/tick
        /// </summary>
        public void ResetClock()
        {
            FirstTick = GetTimeDifferenceAsMs();
        }

        /// <summary>
        ///     The method to resume the timer after stopping it
        /// </summary>
        public void Resume()
        {
            lock (Subscribers)
                if (!Subscribers.Contains(this))
                {
                    FirstTick += GetTimeDifferenceAsMs() - LastTick;
                    Subscribers.Add(this);
                }
        }

        /// <summary>
        ///     The method to start the timer from the beginning
        /// </summary>
        public void Start()
        {
            lock (Subscribers)
                if (!Subscribers.Contains(this))
                {
                    FirstTick = GetTimeDifferenceAsMs();
                    Subscribers.Add(this);
                }
        }

        /// <summary>
        ///     The method to stop the timer from generating any new ticks/frames
        /// </summary>
        public void Stop()
        {
            lock (Subscribers)
                if (Subscribers.Contains(this))
                {
                    Subscribers.Remove(this);
                }
        }
    }
}