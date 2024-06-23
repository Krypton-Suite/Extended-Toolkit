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
namespace Examples
{
    partial class CalendarItems
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Krypton.Toolkit.Suite.Extended.Calendar.CalendarHighlightRange calendarHighlightRange1 = new Krypton.Toolkit.Suite.Extended.Calendar.CalendarHighlightRange();
            Krypton.Toolkit.Suite.Extended.Calendar.CalendarHighlightRange calendarHighlightRange2 = new Krypton.Toolkit.Suite.Extended.Calendar.CalendarHighlightRange();
            Krypton.Toolkit.Suite.Extended.Calendar.CalendarHighlightRange calendarHighlightRange3 = new Krypton.Toolkit.Suite.Extended.Calendar.CalendarHighlightRange();
            Krypton.Toolkit.Suite.Extended.Calendar.CalendarHighlightRange calendarHighlightRange4 = new Krypton.Toolkit.Suite.Extended.Calendar.CalendarHighlightRange();
            Krypton.Toolkit.Suite.Extended.Calendar.CalendarHighlightRange calendarHighlightRange5 = new Krypton.Toolkit.Suite.Extended.Calendar.CalendarHighlightRange();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalendarItems));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.monthView1 = new Krypton.Toolkit.Suite.Extended.Calendar.MonthView();
            this.kryptonCalendar1 = new Krypton.Toolkit.Suite.Extended.Calendar.KryptonCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.monthView1);
            this.kryptonPanel1.Controls.Add(this.kryptonCalendar1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(857, 390);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // monthView1
            // 
            this.monthView1.ArrowsColour = System.Drawing.SystemColors.Window;
            this.monthView1.ArrowsSelectedColour = System.Drawing.Color.Gold;
            this.monthView1.DayBackgroundColour = System.Drawing.Color.Empty;
            this.monthView1.DayGrayedText = System.Drawing.SystemColors.GrayText;
            this.monthView1.DaySelectedBackgroundColour = System.Drawing.SystemColors.Highlight;
            this.monthView1.DaySelectedColour = System.Drawing.SystemColors.WindowText;
            this.monthView1.DaySelectedTextColour = System.Drawing.SystemColors.HighlightText;
            this.monthView1.ItemPadding = new System.Windows.Forms.Padding(2);
            this.monthView1.Location = new System.Drawing.Point(502, 12);
            this.monthView1.MonthTitleColour = System.Drawing.SystemColors.ActiveCaption;
            this.monthView1.MonthTitleColourInactive = System.Drawing.SystemColors.InactiveCaption;
            this.monthView1.MonthTitleTextColour = System.Drawing.SystemColors.ActiveCaptionText;
            this.monthView1.MonthTitleTextColourInactive = System.Drawing.SystemColors.InactiveCaptionText;
            this.monthView1.Name = "monthView1";
            this.monthView1.Size = new System.Drawing.Size(266, 218);
            this.monthView1.TabIndex = 1;
            this.monthView1.Text = "monthView1";
            this.monthView1.TodayBorderColour = System.Drawing.Color.Maroon;
            // 
            // kryptonCalendar1
            // 
            this.kryptonCalendar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            calendarHighlightRange1.DayOfWeek = System.DayOfWeek.Monday;
            calendarHighlightRange1.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange1.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange2.DayOfWeek = System.DayOfWeek.Tuesday;
            calendarHighlightRange2.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange2.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange3.DayOfWeek = System.DayOfWeek.Wednesday;
            calendarHighlightRange3.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange3.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange4.DayOfWeek = System.DayOfWeek.Thursday;
            calendarHighlightRange4.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange4.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange5.DayOfWeek = System.DayOfWeek.Friday;
            calendarHighlightRange5.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange5.StartTime = System.TimeSpan.Parse("08:00:00");
            this.kryptonCalendar1.HighlightRanges = new Krypton.Toolkit.Suite.Extended.Calendar.CalendarHighlightRange[] {
        calendarHighlightRange1,
        calendarHighlightRange2,
        calendarHighlightRange3,
        calendarHighlightRange4,
        calendarHighlightRange5};
            this.kryptonCalendar1.Location = new System.Drawing.Point(12, 12);
            this.kryptonCalendar1.Name = "kryptonCalendar1";
            this.kryptonCalendar1.Size = new System.Drawing.Size(483, 352);
            this.kryptonCalendar1.TabIndex = 0;
            this.kryptonCalendar1.Text = "kryptonCalendar1";
            // 
            // CalendarItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 390);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CalendarItems";
            this.Text = "CalendarItems";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.Suite.Extended.Calendar.MonthView monthView1;
        private Krypton.Toolkit.Suite.Extended.Calendar.KryptonCalendar kryptonCalendar1;
    }
}