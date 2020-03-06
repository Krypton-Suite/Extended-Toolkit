using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Colour.Controls
{
    public class KryptonRGBColourKnobControlVertical : UserControl
    {
        private Base.KryptonKnobControl kryptonKnobControl3;
        private Base.KryptonKnobControl kryptonKnobControl2;
        private KryptonBlueValueLabel kryptonBlueValueLabel1;
        private KryptonGreenValueLabel kryptonGreenValueLabel1;
        private KryptonRedValueLabel kryptonRedValueLabel1;
        private Base.KryptonKnobControl kryptonKnobControl1;

        private void InitializeComponent()
        {
            this.kryptonKnobControl3 = new Krypton.Toolkit.Extended.Base.KryptonKnobControl();
            this.kryptonKnobControl2 = new Krypton.Toolkit.Extended.Base.KryptonKnobControl();
            this.kryptonKnobControl1 = new Krypton.Toolkit.Extended.Base.KryptonKnobControl();
            this.kryptonBlueValueLabel1 = new Krypton.Toolkit.Extended.Colour.Controls.KryptonBlueValueLabel();
            this.kryptonGreenValueLabel1 = new Krypton.Toolkit.Extended.Colour.Controls.KryptonGreenValueLabel();
            this.kryptonRedValueLabel1 = new Krypton.Toolkit.Extended.Colour.Controls.KryptonRedValueLabel();
            this.SuspendLayout();
            // 
            // kryptonKnobControl3
            // 
            this.kryptonKnobControl3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonKnobControl3.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kryptonKnobControl3.LargeChange = 20;
            this.kryptonKnobControl3.Location = new System.Drawing.Point(31, 311);
            this.kryptonKnobControl3.Maximum = 255;
            this.kryptonKnobControl3.Minimum = 0;
            this.kryptonKnobControl3.Name = "kryptonKnobControl3";
            this.kryptonKnobControl3.ShowLargeScale = true;
            this.kryptonKnobControl3.ShowSmallScale = false;
            this.kryptonKnobControl3.Size = new System.Drawing.Size(96, 91);
            this.kryptonKnobControl3.SizeLargeScaleMarker = 6;
            this.kryptonKnobControl3.SizeSmallScaleMarker = 3;
            this.kryptonKnobControl3.SmallChange = 5;
            this.kryptonKnobControl3.TabIndex = 5;
            this.kryptonKnobControl3.Value = 0;
            // 
            // kryptonKnobControl2
            // 
            this.kryptonKnobControl2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonKnobControl2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kryptonKnobControl2.LargeChange = 20;
            this.kryptonKnobControl2.Location = new System.Drawing.Point(31, 167);
            this.kryptonKnobControl2.Maximum = 255;
            this.kryptonKnobControl2.Minimum = 0;
            this.kryptonKnobControl2.Name = "kryptonKnobControl2";
            this.kryptonKnobControl2.ShowLargeScale = true;
            this.kryptonKnobControl2.ShowSmallScale = false;
            this.kryptonKnobControl2.Size = new System.Drawing.Size(96, 91);
            this.kryptonKnobControl2.SizeLargeScaleMarker = 6;
            this.kryptonKnobControl2.SizeSmallScaleMarker = 3;
            this.kryptonKnobControl2.SmallChange = 5;
            this.kryptonKnobControl2.TabIndex = 4;
            this.kryptonKnobControl2.Value = 0;
            // 
            // kryptonKnobControl1
            // 
            this.kryptonKnobControl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonKnobControl1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kryptonKnobControl1.LargeChange = 20;
            this.kryptonKnobControl1.Location = new System.Drawing.Point(31, 23);
            this.kryptonKnobControl1.Maximum = 255;
            this.kryptonKnobControl1.Minimum = 0;
            this.kryptonKnobControl1.Name = "kryptonKnobControl1";
            this.kryptonKnobControl1.ShowLargeScale = true;
            this.kryptonKnobControl1.ShowSmallScale = false;
            this.kryptonKnobControl1.Size = new System.Drawing.Size(96, 91);
            this.kryptonKnobControl1.SizeLargeScaleMarker = 6;
            this.kryptonKnobControl1.SizeSmallScaleMarker = 3;
            this.kryptonKnobControl1.SmallChange = 5;
            this.kryptonKnobControl1.TabIndex = 3;
            this.kryptonKnobControl1.Value = 0;
            // 
            // kryptonBlueValueLabel1
            // 
            this.kryptonBlueValueLabel1.BlueValue = 255;
            this.kryptonBlueValueLabel1.ExtraText = "Blue Value";
            this.kryptonBlueValueLabel1.Location = new System.Drawing.Point(19, 421);
            this.kryptonBlueValueLabel1.Name = "kryptonBlueValueLabel1";
            this.kryptonBlueValueLabel1.ShowColon = false;
            this.kryptonBlueValueLabel1.ShowCurrentColourValue = true;
            this.kryptonBlueValueLabel1.Size = new System.Drawing.Size(124, 21);
            this.kryptonBlueValueLabel1.StateCommon.LongText.Color1 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.LongText.Color2 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonBlueValueLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonBlueValueLabel1.TabIndex = 8;
            this.kryptonBlueValueLabel1.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonBlueValueLabel1.UseAccessibleUI = false;
            this.kryptonBlueValueLabel1.Values.Text = "Blue Value: 255";
            // 
            // kryptonGreenValueLabel1
            // 
            this.kryptonGreenValueLabel1.ExtraText = "Green Value";
            this.kryptonGreenValueLabel1.GreenValue = 255;
            this.kryptonGreenValueLabel1.Location = new System.Drawing.Point(16, 273);
            this.kryptonGreenValueLabel1.Name = "kryptonGreenValueLabel1";
            this.kryptonGreenValueLabel1.ShowColon = false;
            this.kryptonGreenValueLabel1.ShowCurrentColourValue = true;
            this.kryptonGreenValueLabel1.Size = new System.Drawing.Size(137, 21);
            this.kryptonGreenValueLabel1.StateCommon.LongText.Color1 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.LongText.Color2 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGreenValueLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGreenValueLabel1.TabIndex = 7;
            this.kryptonGreenValueLabel1.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGreenValueLabel1.UseAccessibleUI = false;
            this.kryptonGreenValueLabel1.Values.Text = "Green Value: 255";
            // 
            // kryptonRedValueLabel1
            // 
            this.kryptonRedValueLabel1.ExtraText = "Red Value";
            this.kryptonRedValueLabel1.Location = new System.Drawing.Point(21, 130);
            this.kryptonRedValueLabel1.Name = "kryptonRedValueLabel1";
            this.kryptonRedValueLabel1.RedValue = 255;
            this.kryptonRedValueLabel1.ShowColon = false;
            this.kryptonRedValueLabel1.ShowCurrentColourValue = true;
            this.kryptonRedValueLabel1.Size = new System.Drawing.Size(121, 21);
            this.kryptonRedValueLabel1.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.LongText.Color2 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonRedValueLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonRedValueLabel1.TabIndex = 6;
            this.kryptonRedValueLabel1.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonRedValueLabel1.UseAccessibleUI = false;
            this.kryptonRedValueLabel1.Values.Text = "Red Value: 255";
            // 
            // KryptonRGBColourKnobControlVertical
            // 
            this.Controls.Add(this.kryptonBlueValueLabel1);
            this.Controls.Add(this.kryptonGreenValueLabel1);
            this.Controls.Add(this.kryptonRedValueLabel1);
            this.Controls.Add(this.kryptonKnobControl3);
            this.Controls.Add(this.kryptonKnobControl2);
            this.Controls.Add(this.kryptonKnobControl1);
            this.Name = "KryptonRGBColourKnobControlVertical";
            this.Size = new System.Drawing.Size(169, 460);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}