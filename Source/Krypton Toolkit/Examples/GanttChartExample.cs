#region MIT License

/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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

namespace Examples
{
    /// <summary>
    /// Demonstrates <see cref="KryptonGanttChart"/>: tasks, dependencies, palette theming, scrolling,
    /// and interactive options (drag, toggles, zoom, timeline).
    /// </summary>
    public partial class GanttChartExample : KryptonForm
    {
        private int _demoCounter;

        public GanttChartExample()
        {
            InitializeComponent();
            kryptonGanttChart1.TaskSelected += Gantt_TaskSelected;
            kryptonGanttChart1.TaskDatesChanged += Gantt_TaskDatesChanged;
        }

        private void GanttChartExample_Load(object sender, EventArgs e) => ReloadDemo();

        private void Gantt_TaskSelected(object? sender, GanttTaskEventArgs e) =>
            kryptonWrapLabelStatus.Text =
                $"Selected: {e.Task.Name} ({e.Task.Start:yyyy-MM-dd} → {e.Task.End:yyyy-MM-dd}, {e.Task.PercentComplete}%)";

        private void Gantt_TaskDatesChanged(object? sender, GanttTaskEventArgs e) =>
            kryptonWrapLabelStatus.Text =
                $"Dates changed: {e.Task.Name} → {e.Task.Start:yyyy-MM-dd} … {e.Task.End:yyyy-MM-dd}";

        private static DateTime StartOfWeekMonday(DateTime d)
        {
            int offset = d.DayOfWeek - DayOfWeek.Monday;
            if (offset < 0)
            {
                offset += 7;
            }

            return d.Date.AddDays(-offset);
        }

        private void ReloadDemo()
        {
            _demoCounter = 0;
            var g = kryptonGanttChart1;
            g.Tasks.Clear();
            g.Dependencies.Clear();

            DateTime w0 = StartOfWeekMonday(DateTime.Today);
            g.TimelineStart = w0;

            var requirements = new GanttTask
            {
                Name = "Requirements & scope",
                Start = w0,
                End = w0.AddDays(2),
                PercentComplete = 45,
            };
            var design = new GanttTask
            {
                Name = "UX / technical design",
                Start = w0.AddDays(3),
                End = w0.AddDays(7),
                PercentComplete = 72,
                BarColor = Color.FromArgb(46, 125, 50),
            };
            var development = new GanttTask
            {
                Name = "Implementation",
                Start = w0.AddDays(8),
                End = w0.AddDays(19),
                PercentComplete = 28,
            };
            var qa = new GanttTask
            {
                Name = "QA & bugfix window",
                Start = w0.AddDays(18),
                End = w0.AddDays(24),
                PercentComplete = 10,
                BarColor = Color.FromArgb(183, 28, 28),
            };
            var deploy = new GanttTask
            {
                Name = "Release to production",
                Start = w0.AddDays(25),
                End = w0.AddDays(25),
                PercentComplete = 0,
            };
            var buffer = new GanttTask
            {
                Name = "Contingency / slack",
                Start = w0.AddDays(26),
                End = w0.AddDays(28),
                PercentComplete = 0,
            };

            g.Tasks.Add(requirements);
            g.Tasks.Add(design);
            g.Tasks.Add(development);
            g.Tasks.Add(qa);
            g.Tasks.Add(deploy);
            g.Tasks.Add(buffer);

            g.Dependencies.AddRange(new[]
            {
                new GanttDependency { PredecessorId = requirements.Id, SuccessorId = design.Id },
                new GanttDependency { PredecessorId = design.Id, SuccessorId = development.Id },
                new GanttDependency { PredecessorId = development.Id, SuccessorId = qa.Id },
                new GanttDependency { PredecessorId = qa.Id, SuccessorId = deploy.Id },
            });

            kryptonCheckBoxShowDeps.Checked = g.ShowDependencies;
            kryptonCheckBoxWeekends.Checked = g.ShowWeekendShading;
            kryptonCheckBoxAllowDrag.Checked = g.AllowTaskDrag;
            kryptonNumericPixelsPerDay.Value = (decimal)g.PixelsPerDay;

            kryptonWrapLabelStatus.Text =
                "Tip: click a row or bar to select; drag a bar horizontally to shift dates (when enabled). Shift+mouse wheel scrolls the timeline.";
        }

        private void kbtnReload_Click(object sender, EventArgs e) => ReloadDemo();

        private void kbtnAddTask_Click(object sender, EventArgs e)
        {
            _demoCounter++;
            var g = kryptonGanttChart1;
            DateTime start = g.TimelineStart.AddDays(5 + _demoCounter);
            var t = new GanttTask
            {
                Name = $"Ad-hoc task {_demoCounter}",
                Start = start,
                End = start.AddDays(2 + _demoCounter % 3),
                PercentComplete = 15 * (_demoCounter % 5),
            };
            g.Tasks.Add(t);
            kryptonWrapLabelStatus.Text = $"Added: {t.Name}";
        }

        private void kbtnRemoveSelected_Click(object sender, EventArgs e)
        {
            var t = kryptonGanttChart1.SelectedTask;
            if (t == null)
            {
                kryptonWrapLabelStatus.Text = "Nothing selected to remove.";
                return;
            }

            kryptonGanttChart1.Tasks.Remove(t);
            kryptonGanttChart1.Dependencies.RemoveAll(d =>
                d.PredecessorId == t.Id || d.SuccessorId == t.Id);
            kryptonGanttChart1.SelectedTask = null;
            kryptonWrapLabelStatus.Text = "Removed task.";
        }

        private void kbtnTimelinePrev_Click(object sender, EventArgs e) =>
            kryptonGanttChart1.TimelineStart = kryptonGanttChart1.TimelineStart.AddDays(-7);

        private void kbtnTimelineNext_Click(object sender, EventArgs e) =>
            kryptonGanttChart1.TimelineStart = kryptonGanttChart1.TimelineStart.AddDays(7);

        private void kbtnZoomOut_Click(object sender, EventArgs e) =>
            kryptonGanttChart1.PixelsPerDay = Math.Max(8f, kryptonGanttChart1.PixelsPerDay - 4f);

        private void kbtnZoomIn_Click(object sender, EventArgs e) =>
            kryptonGanttChart1.PixelsPerDay = Math.Min(96f, kryptonGanttChart1.PixelsPerDay + 4f);

        private void kryptonCheckBoxShowDeps_CheckedChanged(object sender, EventArgs e) =>
            kryptonGanttChart1.ShowDependencies = kryptonCheckBoxShowDeps.Checked;

        private void kryptonCheckBoxWeekends_CheckedChanged(object sender, EventArgs e) =>
            kryptonGanttChart1.ShowWeekendShading = kryptonCheckBoxWeekends.Checked;

        private void kryptonCheckBoxAllowDrag_CheckedChanged(object sender, EventArgs e) =>
            kryptonGanttChart1.AllowTaskDrag = kryptonCheckBoxAllowDrag.Checked;

        private void kryptonNumericPixelsPerDay_ValueChanged(object sender, EventArgs e) =>
            kryptonGanttChart1.PixelsPerDay = (float)kryptonNumericPixelsPerDay.Value;
    }
}
