using System;
using System.Diagnostics;

namespace Krypton.Toolkit.Suite.Extended.Calendar.Library
{
    public partial class AddAppointment : KryptonForm
    {
        #region System
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kdtpDate = new Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.knudStartHour = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knudStartMinute = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knudEndMinute = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knudEndHour = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtDescription = new Krypton.Toolkit.KryptonTextBox();
            this.kchkTentative = new Krypton.Toolkit.KryptonCheckBox();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtColour = new Krypton.Toolkit.KryptonTextBox();
            this.ktxtKey = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            this.kbtnAddItem = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnAddItem);
            this.kryptonPanel1.Controls.Add(this.ktxtKey);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel6);
            this.kryptonPanel1.Controls.Add(this.ktxtColour);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel5);
            this.kryptonPanel1.Controls.Add(this.kchkTentative);
            this.kryptonPanel1.Controls.Add(this.ktxtDescription);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel1.Controls.Add(this.knudEndMinute);
            this.kryptonPanel1.Controls.Add(this.knudEndHour);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel1.Controls.Add(this.knudStartMinute);
            this.kryptonPanel1.Controls.Add(this.knudStartHour);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Controls.Add(this.kdtpDate);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(556, 137);
            this.kryptonPanel1.TabIndex = 0;
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
            // kdtpDate
            // 
            this.kdtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.kdtpDate.Location = new System.Drawing.Point(61, 13);
            this.kdtpDate.Name = "kdtpDate";
            this.kdtpDate.Size = new System.Drawing.Size(121, 21);
            this.kdtpDate.TabIndex = 1;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(188, 13);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(42, 20);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Start:";
            // 
            // knudStartHour
            // 
            this.knudStartHour.Location = new System.Drawing.Point(237, 13);
            this.knudStartHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.knudStartHour.Name = "knudStartHour";
            this.knudStartHour.Size = new System.Drawing.Size(63, 22);
            this.knudStartHour.TabIndex = 3;
            this.knudStartHour.ValueChanged += new System.EventHandler(this.knudStartHour_ValueChanged);
            // 
            // knudStartMinute
            // 
            this.knudStartMinute.Location = new System.Drawing.Point(306, 13);
            this.knudStartMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.knudStartMinute.Name = "knudStartMinute";
            this.knudStartMinute.Size = new System.Drawing.Size(63, 22);
            this.knudStartMinute.TabIndex = 4;
            this.knudStartMinute.ValueChanged += new System.EventHandler(this.knudStartMinute_ValueChanged);
            // 
            // knudEndMinute
            // 
            this.knudEndMinute.Location = new System.Drawing.Point(486, 13);
            this.knudEndMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.knudEndMinute.Name = "knudEndMinute";
            this.knudEndMinute.Size = new System.Drawing.Size(63, 22);
            this.knudEndMinute.TabIndex = 7;
            // 
            // knudEndHour
            // 
            this.knudEndHour.Location = new System.Drawing.Point(417, 13);
            this.knudEndHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.knudEndHour.Name = "knudEndHour";
            this.knudEndHour.Size = new System.Drawing.Size(63, 22);
            this.knudEndHour.TabIndex = 6;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel3.Location = new System.Drawing.Point(375, 13);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(36, 20);
            this.kryptonLabel3.TabIndex = 5;
            this.kryptonLabel3.Values.Text = "End:";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel4.Location = new System.Drawing.Point(13, 40);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(80, 20);
            this.kryptonLabel4.TabIndex = 8;
            this.kryptonLabel4.Values.Text = "Description:";
            // 
            // ktxtDescription
            // 
            this.ktxtDescription.Location = new System.Drawing.Point(100, 41);
            this.ktxtDescription.Name = "ktxtDescription";
            this.ktxtDescription.Size = new System.Drawing.Size(449, 23);
            this.ktxtDescription.TabIndex = 9;
            // 
            // kchkTentative
            // 
            this.kchkTentative.Location = new System.Drawing.Point(13, 70);
            this.kchkTentative.Name = "kchkTentative";
            this.kchkTentative.Size = new System.Drawing.Size(79, 20);
            this.kchkTentative.TabIndex = 10;
            this.kchkTentative.Values.Text = "&Tentative?";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel5.Location = new System.Drawing.Point(100, 70);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(53, 20);
            this.kryptonLabel5.TabIndex = 11;
            this.kryptonLabel5.Values.Text = "Colour:";
            // 
            // ktxtColour
            // 
            this.ktxtColour.Hint = "#000000";
            this.ktxtColour.Location = new System.Drawing.Point(160, 70);
            this.ktxtColour.MaxLength = 7;
            this.ktxtColour.Name = "ktxtColour";
            this.ktxtColour.Size = new System.Drawing.Size(154, 23);
            this.ktxtColour.TabIndex = 12;
            // 
            // ktxtKey
            // 
            this.ktxtKey.Location = new System.Drawing.Point(396, 70);
            this.ktxtKey.Name = "ktxtKey";
            this.ktxtKey.Size = new System.Drawing.Size(148, 23);
            this.ktxtKey.TabIndex = 14;
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel6.Location = new System.Drawing.Point(355, 70);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(35, 20);
            this.kryptonLabel6.TabIndex = 13;
            this.kryptonLabel6.Values.Text = "Key:";
            // 
            // kbtnAddItem
            // 
            this.kbtnAddItem.Location = new System.Drawing.Point(459, 100);
            this.kbtnAddItem.Name = "kbtnAddItem";
            this.kbtnAddItem.Size = new System.Drawing.Size(90, 25);
            this.kbtnAddItem.TabIndex = 15;
            this.kbtnAddItem.Values.Text = "Add &Item";
            this.kbtnAddItem.Click += new System.EventHandler(this.kbtnAddItem_Click);
            // 
            // AddAppointment
            // 
            this.ClientSize = new System.Drawing.Size(556, 137);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddAppointment";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Appointment";
            this.Load += new System.EventHandler(this.AddAppointment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private KryptonTextBox ktxtKey;
        private KryptonLabel kryptonLabel6;
        private KryptonTextBox ktxtColour;
        private KryptonLabel kryptonLabel5;
        private KryptonCheckBox kchkTentative;
        private KryptonTextBox ktxtDescription;
        private KryptonLabel kryptonLabel4;
        private KryptonNumericUpDown knudEndMinute;
        private KryptonNumericUpDown knudEndHour;
        private KryptonLabel kryptonLabel3;
        private KryptonNumericUpDown knudStartMinute;
        private KryptonNumericUpDown knudStartHour;
        private KryptonLabel kryptonLabel2;
        private KryptonDateTimePicker kdtpDate;
        private KryptonLabel kryptonLabel1;
        private KryptonButton kbtnAddItem;
        #endregion

        #region Variables
        private Calendar _calendar;
        #endregion

        #region Constructors
        public AddAppointment(ref Calendar calendar)
        {
            InitializeComponent();

            _calendar = calendar;

            kdtpDate.Value = DateTime.Now;

            knudStartHour.Value = DateTime.Now.Hour;

            knudStartMinute.Value = DateTime.Now.Minute;
        }
        #endregion

        private void AddAppointment_Load(object sender, EventArgs e)
        {

        }

        private void kbtnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startTime = new DateTime(kdtpDate.Value.Year, kdtpDate.Value.Month, kdtpDate.Value.Day, (int)knudStartHour.Value, (int)knudStartMinute.Value, 0);

                DateTime endTime = new DateTime(kdtpDate.Value.Year, kdtpDate.Value.Month, kdtpDate.Value.Day, (int)knudEndHour.Value, (int)knudEndMinute.Value, 0);

                if (endTime.CompareTo(startTime) <= 0)
                {
                    KryptonMessageBox.Show("End time is either same as or before the start time. Please check the times");

                    return;
                }

                if (ktxtDescription.Text == null || ktxtDescription.Text.Trim() == string.Empty)
                {
                    KryptonMessageBox.Show("Please enter some description of this item");

                    return;
                }

                _calendar.CalendarItems.Add(new CalendarItem(startTime, endTime, ktxtDescription.Text, kchkTentative.Checked, ktxtKey.Text, ktxtColour.Text));

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
            //if (knudStartMinute.Value == 0)
            //{
            //    knudEndMinute.Value = 30;
            //}
            //else
            //{
            //    knudEndMinute.Value = 0;
            //}

            knudEndMinute.Value = knudStartMinute.Value + 30;
        }
    }
}