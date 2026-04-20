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
    partial class GanttChartExample
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.kryptonPanelMain = new Krypton.Toolkit.KryptonPanel();
            this.kryptonGanttChart1 = new Krypton.Toolkit.Suite.Extended.GanttChart.KryptonGanttChart();
            this.kryptonPanelToolbar = new Krypton.Toolkit.KryptonPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.kryptonWrapLabelStatus = new Krypton.Toolkit.KryptonWrapLabel();
            this.kbtnReload = new Krypton.Toolkit.KryptonButton();
            this.kbtnAddTask = new Krypton.Toolkit.KryptonButton();
            this.kbtnRemoveSelected = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kbtnTimelinePrev = new Krypton.Toolkit.KryptonButton();
            this.kbtnTimelineNext = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kbtnZoomOut = new Krypton.Toolkit.KryptonButton();
            this.kbtnZoomIn = new Krypton.Toolkit.KryptonButton();
            this.kryptonCheckBoxShowDeps = new Krypton.Toolkit.KryptonCheckBox();
            this.kryptonCheckBoxWeekends = new Krypton.Toolkit.KryptonCheckBox();
            this.kryptonCheckBoxAllowDrag = new Krypton.Toolkit.KryptonCheckBox();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonNumericPixelsPerDay = new Krypton.Toolkit.KryptonNumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanelMain)).BeginInit();
            this.kryptonPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanelToolbar)).BeginInit();
            this.kryptonPanelToolbar.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNumericPixelsPerDay)).BeginInit();
            this.SuspendLayout();
            //
            // kryptonPanelMain
            //
            this.kryptonPanelMain.Controls.Add(this.kryptonGanttChart1);
            this.kryptonPanelMain.Controls.Add(this.kryptonPanelToolbar);
            this.kryptonPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanelMain.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanelMain.Name = "kryptonPanelMain";
            this.kryptonPanelMain.Size = new System.Drawing.Size(1004, 641);
            this.kryptonPanelMain.TabIndex = 0;
            //
            // kryptonGanttChart1
            //
            this.kryptonGanttChart1.AllowTaskDrag = true;
            this.kryptonGanttChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonGanttChart1.HeaderHeight = 32;
            this.kryptonGanttChart1.Location = new System.Drawing.Point(0, 136);
            this.kryptonGanttChart1.MinChartDaySpan = 21;
            this.kryptonGanttChart1.Name = "kryptonGanttChart1";
            this.kryptonGanttChart1.PixelsPerDay = 32F;
            this.kryptonGanttChart1.ShowDependencies = true;
            this.kryptonGanttChart1.ShowWeekendShading = true;
            this.kryptonGanttChart1.TaskListWidth = 220;
            this.kryptonGanttChart1.Size = new System.Drawing.Size(1004, 505);
            this.kryptonGanttChart1.TabIndex = 1;
            //
            // kryptonPanelToolbar
            //
            this.kryptonPanelToolbar.Controls.Add(this.flowLayoutPanel1);
            this.kryptonPanelToolbar.Controls.Add(this.kryptonWrapLabelStatus);
            this.kryptonPanelToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanelToolbar.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanelToolbar.Name = "kryptonPanelToolbar";
            this.kryptonPanelToolbar.Size = new System.Drawing.Size(1004, 136);
            this.kryptonPanelToolbar.TabIndex = 0;
            //
            // kryptonWrapLabelStatus
            //
            this.kryptonWrapLabelStatus.AutoSize = false;
            this.kryptonWrapLabelStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonWrapLabelStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabelStatus.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.kryptonWrapLabelStatus.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.kryptonWrapLabelStatus.Location = new System.Drawing.Point(0, 88);
            this.kryptonWrapLabelStatus.Name = "kryptonWrapLabelStatus";
            this.kryptonWrapLabelStatus.Size = new System.Drawing.Size(1004, 48);
            this.kryptonWrapLabelStatus.Text = "Status";
            //
            // flowLayoutPanel1
            //
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.kbtnReload);
            this.flowLayoutPanel1.Controls.Add(this.kbtnAddTask);
            this.flowLayoutPanel1.Controls.Add(this.kbtnRemoveSelected);
            this.flowLayoutPanel1.Controls.Add(this.kryptonLabel1);
            this.flowLayoutPanel1.Controls.Add(this.kbtnTimelinePrev);
            this.flowLayoutPanel1.Controls.Add(this.kbtnTimelineNext);
            this.flowLayoutPanel1.Controls.Add(this.kryptonLabel2);
            this.flowLayoutPanel1.Controls.Add(this.kbtnZoomOut);
            this.flowLayoutPanel1.Controls.Add(this.kbtnZoomIn);
            this.flowLayoutPanel1.Controls.Add(this.kryptonCheckBoxShowDeps);
            this.flowLayoutPanel1.Controls.Add(this.kryptonCheckBoxWeekends);
            this.flowLayoutPanel1.Controls.Add(this.kryptonCheckBoxAllowDrag);
            this.flowLayoutPanel1.Controls.Add(this.kryptonLabel3);
            this.flowLayoutPanel1.Controls.Add(this.kryptonNumericPixelsPerDay);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(4, 6, 4, 4);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1004, 88);
            this.flowLayoutPanel1.TabIndex = 0;
            //
            // kbtnReload
            //
            this.kbtnReload.Location = new System.Drawing.Point(7, 9);
            this.kbtnReload.Name = "kbtnReload";
            this.kbtnReload.Size = new System.Drawing.Size(110, 25);
            this.kbtnReload.TabIndex = 0;
            this.kbtnReload.Values.Text = "Reset demo";
            this.kbtnReload.Click += new System.EventHandler(this.kbtnReload_Click);
            //
            // kbtnAddTask
            //
            this.kbtnAddTask.Location = new System.Drawing.Point(123, 9);
            this.kbtnAddTask.Name = "kbtnAddTask";
            this.kbtnAddTask.Size = new System.Drawing.Size(104, 25);
            this.kbtnAddTask.TabIndex = 1;
            this.kbtnAddTask.Values.Text = "Add task";
            this.kbtnAddTask.Click += new System.EventHandler(this.kbtnAddTask_Click);
            //
            // kbtnRemoveSelected
            //
            this.kbtnRemoveSelected.Location = new System.Drawing.Point(233, 9);
            this.kbtnRemoveSelected.Name = "kbtnRemoveSelected";
            this.kbtnRemoveSelected.Size = new System.Drawing.Size(124, 25);
            this.kbtnRemoveSelected.TabIndex = 2;
            this.kbtnRemoveSelected.Values.Text = "Remove selected";
            this.kbtnRemoveSelected.Click += new System.EventHandler(this.kbtnRemoveSelected_Click);
            //
            // kryptonLabel1
            //
            this.kryptonLabel1.Location = new System.Drawing.Point(363, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(78, 20);
            this.kryptonLabel1.TabIndex = 3;
            this.kryptonLabel1.Values.Text = "Timeline ±";
            //
            // kbtnTimelinePrev
            //
            this.kbtnTimelinePrev.Location = new System.Drawing.Point(447, 9);
            this.kbtnTimelinePrev.Name = "kbtnTimelinePrev";
            this.kbtnTimelinePrev.Size = new System.Drawing.Size(36, 25);
            this.kbtnTimelinePrev.TabIndex = 4;
            this.kbtnTimelinePrev.Values.Text = "◄";
            this.kbtnTimelinePrev.Click += new System.EventHandler(this.kbtnTimelinePrev_Click);
            //
            // kbtnTimelineNext
            //
            this.kbtnTimelineNext.Location = new System.Drawing.Point(489, 9);
            this.kbtnTimelineNext.Name = "kbtnTimelineNext";
            this.kbtnTimelineNext.Size = new System.Drawing.Size(36, 25);
            this.kbtnTimelineNext.TabIndex = 5;
            this.kbtnTimelineNext.Values.Text = "►";
            this.kbtnTimelineNext.Click += new System.EventHandler(this.kbtnTimelineNext_Click);
            //
            // kryptonLabel2
            //
            this.kryptonLabel2.Location = new System.Drawing.Point(531, 12);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(44, 20);
            this.kryptonLabel2.TabIndex = 6;
            this.kryptonLabel2.Values.Text = "Zoom";
            //
            // kbtnZoomOut
            //
            this.kbtnZoomOut.Location = new System.Drawing.Point(581, 9);
            this.kbtnZoomOut.Name = "kbtnZoomOut";
            this.kbtnZoomOut.Size = new System.Drawing.Size(34, 25);
            this.kbtnZoomOut.TabIndex = 7;
            this.kbtnZoomOut.Values.Text = "−";
            this.kbtnZoomOut.Click += new System.EventHandler(this.kbtnZoomOut_Click);
            //
            // kbtnZoomIn
            //
            this.kbtnZoomIn.Location = new System.Drawing.Point(621, 9);
            this.kbtnZoomIn.Name = "kbtnZoomIn";
            this.kbtnZoomIn.Size = new System.Drawing.Size(34, 25);
            this.kbtnZoomIn.TabIndex = 8;
            this.kbtnZoomIn.Values.Text = "+";
            this.kbtnZoomIn.Click += new System.EventHandler(this.kbtnZoomIn_Click);
            //
            // kryptonCheckBoxShowDeps
            //
            this.kryptonCheckBoxShowDeps.Location = new System.Drawing.Point(661, 11);
            this.kryptonCheckBoxShowDeps.Name = "kryptonCheckBoxShowDeps";
            this.kryptonCheckBoxShowDeps.Size = new System.Drawing.Size(112, 20);
            this.kryptonCheckBoxShowDeps.TabIndex = 9;
            this.kryptonCheckBoxShowDeps.Values.Text = "Dependencies";
            this.kryptonCheckBoxShowDeps.CheckedChanged += new System.EventHandler(this.kryptonCheckBoxShowDeps_CheckedChanged);
            //
            // kryptonCheckBoxWeekends
            //
            this.kryptonCheckBoxWeekends.Location = new System.Drawing.Point(779, 11);
            this.kryptonCheckBoxWeekends.Name = "kryptonCheckBoxWeekends";
            this.kryptonCheckBoxWeekends.Size = new System.Drawing.Size(130, 20);
            this.kryptonCheckBoxWeekends.TabIndex = 10;
            this.kryptonCheckBoxWeekends.Values.Text = "Weekend shading";
            this.kryptonCheckBoxWeekends.CheckedChanged += new System.EventHandler(this.kryptonCheckBoxWeekends_CheckedChanged);
            //
            // kryptonCheckBoxAllowDrag
            //
            this.kryptonCheckBoxAllowDrag.Location = new System.Drawing.Point(7, 40);
            this.kryptonCheckBoxAllowDrag.Name = "kryptonCheckBoxAllowDrag";
            this.kryptonCheckBoxAllowDrag.Size = new System.Drawing.Size(156, 20);
            this.kryptonCheckBoxAllowDrag.TabIndex = 11;
            this.kryptonCheckBoxAllowDrag.Values.Text = "Allow bar drag (dates)";
            this.kryptonCheckBoxAllowDrag.CheckedChanged += new System.EventHandler(this.kryptonCheckBoxAllowDrag_CheckedChanged);
            //
            // kryptonLabel3
            //
            this.kryptonLabel3.Location = new System.Drawing.Point(169, 40);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(96, 20);
            this.kryptonLabel3.TabIndex = 12;
            this.kryptonLabel3.Values.Text = "Pixels / day";
            //
            // kryptonNumericPixelsPerDay
            //
            this.kryptonNumericPixelsPerDay.Location = new System.Drawing.Point(271, 37);
            this.kryptonNumericPixelsPerDay.Maximum = new decimal(new int[] { 96, 0, 0, 0 });
            this.kryptonNumericPixelsPerDay.Minimum = new decimal(new int[] { 8, 0, 0, 0 });
            this.kryptonNumericPixelsPerDay.Name = "kryptonNumericPixelsPerDay";
            this.kryptonNumericPixelsPerDay.Size = new System.Drawing.Size(64, 23);
            this.kryptonNumericPixelsPerDay.TabIndex = 13;
            this.kryptonNumericPixelsPerDay.Value = new decimal(new int[] { 32, 0, 0, 0 });
            this.kryptonNumericPixelsPerDay.ValueChanged += new System.EventHandler(this.kryptonNumericPixelsPerDay_ValueChanged);
            //
            // GanttChartExample
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 641);
            this.Controls.Add(this.kryptonPanelMain);
            this.Name = "GanttChartExample";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gantt chart (Extended Toolkit)";
            this.Load += new System.EventHandler(this.GanttChartExample_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanelMain)).EndInit();
            this.kryptonPanelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanelToolbar)).EndInit();
            this.kryptonPanelToolbar.ResumeLayout(false);
            this.kryptonPanelToolbar.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNumericPixelsPerDay)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanelMain;
        private Krypton.Toolkit.KryptonPanel kryptonPanelToolbar;
        private KryptonGanttChart kryptonGanttChart1;
        private Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabelStatus;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Krypton.Toolkit.KryptonButton kbtnReload;
        private Krypton.Toolkit.KryptonButton kbtnAddTask;
        private Krypton.Toolkit.KryptonButton kbtnRemoveSelected;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonButton kbtnTimelinePrev;
        private Krypton.Toolkit.KryptonButton kbtnTimelineNext;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonButton kbtnZoomOut;
        private Krypton.Toolkit.KryptonButton kbtnZoomIn;
        private Krypton.Toolkit.KryptonCheckBox kryptonCheckBoxShowDeps;
        private Krypton.Toolkit.KryptonCheckBox kryptonCheckBoxWeekends;
        private Krypton.Toolkit.KryptonCheckBox kryptonCheckBoxAllowDrag;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonNumericUpDown kryptonNumericPixelsPerDay;
    }
}
