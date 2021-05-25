#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Calendar
{
    public class AddAppointment : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnAddAppointment;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel2;
        private KryptonNumericUpDown knudEndMinute;
        private KryptonNumericUpDown knudEndHour;
        private KryptonLabel kryptonLabel3;
        private KryptonNumericUpDown knudStartMinute;
        private KryptonNumericUpDown knudStartHour;
        private KryptonLabel kryptonLabel2;
        private KryptonDateTimePicker kdtSelectedDate;
        private KryptonTextBox ktxtAppointmentDescription;
        private KryptonLabel kryptonLabel4;
        private KryptonCheckBox kchkTentative;
        private KryptonTextBox ktxtKey;
        private KryptonLabel kryptonLabel6;
        private KryptonTextBox ktxtColour;
        private KryptonLabel kryptonLabel5;
        private KryptonLabel kryptonLabel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kchkTentative = new Krypton.Toolkit.KryptonCheckBox();
            this.kbtnAddAppointment = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.ktxtKey = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtColour = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtAppointmentDescription = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.knudEndMinute = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knudEndHour = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.knudStartMinute = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knudStartHour = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kdtSelectedDate = new Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kchkTentative);
            this.kryptonPanel1.Controls.Add(this.kbtnAddAppointment);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 115);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(635, 44);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kchkTentative
            // 
            this.kchkTentative.Location = new System.Drawing.Point(13, 11);
            this.kchkTentative.Name = "kchkTentative";
            this.kchkTentative.Size = new System.Drawing.Size(79, 20);
            this.kchkTentative.TabIndex = 2;
            this.kchkTentative.Values.Text = "&Tentative?";
            // 
            // kbtnAddAppointment
            // 
            this.kbtnAddAppointment.Location = new System.Drawing.Point(504, 7);
            this.kbtnAddAppointment.Name = "kbtnAddAppointment";
            this.kbtnAddAppointment.Size = new System.Drawing.Size(120, 25);
            this.kbtnAddAppointment.TabIndex = 1;
            this.kbtnAddAppointment.Values.Text = "Add &Appontment";
            this.kbtnAddAppointment.Click += new System.EventHandler(this.kbtnAddAppointment_Click);
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(635, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.ktxtKey);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel6);
            this.kryptonPanel2.Controls.Add(this.ktxtColour);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel5);
            this.kryptonPanel2.Controls.Add(this.ktxtAppointmentDescription);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel2.Controls.Add(this.knudEndMinute);
            this.kryptonPanel2.Controls.Add(this.knudEndHour);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel2.Controls.Add(this.knudStartMinute);
            this.kryptonPanel2.Controls.Add(this.knudStartHour);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel2.Controls.Add(this.kdtSelectedDate);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(635, 115);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // ktxtKey
            // 
            this.ktxtKey.Location = new System.Drawing.Point(230, 82);
            this.ktxtKey.Name = "ktxtKey";
            this.ktxtKey.Size = new System.Drawing.Size(394, 23);
            this.ktxtKey.TabIndex = 13;
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel6.Location = new System.Drawing.Point(189, 82);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(35, 20);
            this.kryptonLabel6.TabIndex = 12;
            this.kryptonLabel6.Values.Text = "Key:";
            // 
            // ktxtColour
            // 
            this.ktxtColour.Hint = "#000000";
            this.ktxtColour.Location = new System.Drawing.Point(73, 82);
            this.ktxtColour.MaxLength = 10;
            this.ktxtColour.Name = "ktxtColour";
            this.ktxtColour.Size = new System.Drawing.Size(110, 23);
            this.ktxtColour.TabIndex = 11;
            this.ktxtColour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel5.Location = new System.Drawing.Point(13, 82);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(53, 20);
            this.kryptonLabel5.TabIndex = 10;
            this.kryptonLabel5.Values.Text = "Colour:";
            // 
            // ktxtAppointmentDescription
            // 
            this.ktxtAppointmentDescription.Hint = "Enter a apopointment desciption...";
            this.ktxtAppointmentDescription.Location = new System.Drawing.Point(100, 49);
            this.ktxtAppointmentDescription.Name = "ktxtAppointmentDescription";
            this.ktxtAppointmentDescription.Size = new System.Drawing.Size(524, 23);
            this.ktxtAppointmentDescription.TabIndex = 9;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel4.Location = new System.Drawing.Point(13, 49);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(80, 20);
            this.kryptonLabel4.TabIndex = 8;
            this.kryptonLabel4.Values.Text = "Description:";
            // 
            // knudEndMinute
            // 
            this.knudEndMinute.Location = new System.Drawing.Point(565, 13);
            this.knudEndMinute.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.knudEndMinute.Name = "knudEndMinute";
            this.knudEndMinute.Size = new System.Drawing.Size(59, 22);
            this.knudEndMinute.TabIndex = 7;
            // 
            // knudEndHour
            // 
            this.knudEndHour.Location = new System.Drawing.Point(500, 13);
            this.knudEndHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.knudEndHour.Name = "knudEndHour";
            this.knudEndHour.Size = new System.Drawing.Size(59, 22);
            this.knudEndHour.TabIndex = 6;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel3.Location = new System.Drawing.Point(426, 13);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(68, 20);
            this.kryptonLabel3.TabIndex = 5;
            this.kryptonLabel3.Values.Text = "End Time:";
            // 
            // knudStartMinute
            // 
            this.knudStartMinute.Location = new System.Drawing.Point(361, 13);
            this.knudStartMinute.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.knudStartMinute.Name = "knudStartMinute";
            this.knudStartMinute.Size = new System.Drawing.Size(59, 22);
            this.knudStartMinute.TabIndex = 4;
            this.knudStartMinute.ValueChanged += new System.EventHandler(this.knudStartMinute_ValueChanged);
            // 
            // knudStartHour
            // 
            this.knudStartHour.Location = new System.Drawing.Point(296, 13);
            this.knudStartHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.knudStartHour.Name = "knudStartHour";
            this.knudStartHour.Size = new System.Drawing.Size(59, 22);
            this.knudStartHour.TabIndex = 3;
            this.knudStartHour.ValueChanged += new System.EventHandler(this.knudStartHour_ValueChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(215, 13);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(74, 20);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Start Time:";
            // 
            // kdtSelectedDate
            // 
            this.kdtSelectedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.kdtSelectedDate.Location = new System.Drawing.Point(61, 13);
            this.kdtSelectedDate.Name = "kdtSelectedDate";
            this.kdtSelectedDate.Size = new System.Drawing.Size(148, 21);
            this.kdtSelectedDate.TabIndex = 1;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(13, 13);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(41, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Date:";
            // 
            // AddAppointment
            // 
            this.ClientSize = new System.Drawing.Size(635, 159);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddAppointment";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Add Appointment";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private CalendarControl _calendar;
        #endregion

        #region Constructors
        public AddAppointment(ref CalendarControl calendar)
        {
            InitializeComponent();

            _calendar = calendar;

            kdtSelectedDate.Value = DateTime.Now;

            knudStartHour.Value = DateTime.Now.Hour;

            knudStartMinute.Value = DateTime.Now.Minute;
        }
        #endregion

        private void kbtnAddAppointment_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startTime = new DateTime(kdtSelectedDate.Value.Year, kdtSelectedDate.Value.Month, kdtSelectedDate.Value.Day, (int)knudStartHour.Value, (int)knudStartMinute.Value, 0);

                DateTime endTime = new DateTime(kdtSelectedDate.Value.Year, kdtSelectedDate.Value.Month, kdtSelectedDate.Value.Day, (int)knudEndHour.Value, (int)knudEndMinute.Value, 0);

                if (endTime.CompareTo(startTime) <= 0)
                {
                    KryptonMessageBox.Show("End time is either same as or before the start time. Please check the times");

                    return;
                }

                if (ktxtAppointmentDescription.Text == null || ktxtAppointmentDescription.Text.Trim() == string.Empty)
                {
                    KryptonMessageBox.Show("Please enter some description of this item");

                    return;
                }

                _calendar.CalendarItems.Add(new CalendarItem(startTime, endTime, ktxtAppointmentDescription.Text, kchkTentative.Checked, ktxtKey.Text, ktxtColour.Text));

                _calendar.InitialiseDisplay();
            }
            catch (Exception exc)
            {
                Trace.WriteLine(exc.ToString());
            }
        }

        private void knudStartHour_ValueChanged(object sender, EventArgs e)
        {
            knudEndHour.Value = (knudStartHour.Value == 23) ? 23 : knudStartHour.Value + 1;
        }

        private void knudStartMinute_ValueChanged(object sender, EventArgs e)
        {
            knudEndMinute.Value = knudStartMinute.Value + 30;
        }
    }
}