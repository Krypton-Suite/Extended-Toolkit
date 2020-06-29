#region License
/*
 * MIT License
 *
 * Copyright (c) 2017 ENTech Solutions
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
*/
#endregion

using System;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public enum Status
    {
        Processing,
        Completed,
        Cancelled
    }

    public class Stats
    {
        public class StatsFiles
        {
            public int Total { get; set; }

            public int Processed { get; set; }

            public int Binary { get; set; }

            public int WithMatches { get; set; }

            public int WithoutMatches { get; set; }

            public int FailedToRead { get; set; }

            public int FailedToWrite { get; set; }
        }

        public class StatsMatches
        {
            public int Found { get; set; }

            public int Replaced { get; set; }
        }

        public class StatsTime
        {
            public TimeSpan Passed { get; set; }

            public TimeSpan Remaining { get; set; }
        }

        public StatsFiles Files { get; set; }

        public StatsMatches Matches { get; set; }

        public StatsTime Time { get; set; }

        public Stats()
        {
            Files = new StatsFiles();

            Matches = new StatsMatches();

            Time = new StatsTime();
        }

        public void UpdateTime(DateTime startTime, DateTime startTimeProcessingFiles)
        {
            DateTime now = DateTime.Now;
            Time.Passed = now.Subtract(startTime);

            //Use startTimeProcessingFiles to figure out remaining time
            TimeSpan passedProcessingFiles = now.Subtract(startTimeProcessingFiles);

            double passedSeconds = passedProcessingFiles.TotalSeconds;

            int remainingFiles = Files.Total - Files.Processed;
            var remainingSeconds = (passedSeconds / Files.Processed) * remainingFiles;

            Time.Remaining = TimeSpan.FromSeconds(remainingSeconds);
        }
    }
}