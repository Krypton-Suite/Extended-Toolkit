using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Colour.Controls
{
    public class KryptonRGBColourKnobControlVertical : UserControl
    {
        #region Design Time Code
        private Base.KryptonKnobControl knbBlue;
        private Base.KryptonKnobControl knbGreen;
        private KryptonBlueValueLabel kryptonBlueValueLabel1;
        private KryptonGreenValueLabel klblGreen;
        private KryptonRedValueLabel klblRed;
        private Base.KryptonKnobControl knbRed;

        private void InitializeComponent()
        {
            this.kryptonBlueValueLabel1 = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonBlueValueLabel();
            this.klblGreen = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonGreenValueLabel();
            this.klblRed = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonRedValueLabel();
            this.knbBlue = new Krypton.Toolkit.Suite.Extended.Base.KryptonKnobControl();
            this.knbGreen = new Krypton.Toolkit.Suite.Extended.Base.KryptonKnobControl();
            this.knbRed = new Krypton.Toolkit.Suite.Extended.Base.KryptonKnobControl();
            this.SuspendLayout();
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
            // klblGreen
            // 
            this.klblGreen.ExtraText = "Green Value";
            this.klblGreen.GreenValue = 255;
            this.klblGreen.Location = new System.Drawing.Point(16, 273);
            this.klblGreen.Name = "klblGreen";
            this.klblGreen.ShowColon = false;
            this.klblGreen.ShowCurrentColourValue = true;
            this.klblGreen.Size = new System.Drawing.Size(137, 21);
            this.klblGreen.StateCommon.LongText.Color1 = System.Drawing.Color.Green;
            this.klblGreen.StateCommon.LongText.Color2 = System.Drawing.Color.Green;
            this.klblGreen.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblGreen.StateCommon.ShortText.Color1 = System.Drawing.Color.Green;
            this.klblGreen.StateCommon.ShortText.Color2 = System.Drawing.Color.Green;
            this.klblGreen.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblGreen.TabIndex = 7;
            this.klblGreen.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblGreen.UseAccessibleUI = false;
            this.klblGreen.Values.Text = "Green Value: 255";
            // 
            // klblRed
            // 
            this.klblRed.ExtraText = "Red Value";
            this.klblRed.Location = new System.Drawing.Point(21, 130);
            this.klblRed.Name = "klblRed";
            this.klblRed.RedValue = 255;
            this.klblRed.ShowColon = false;
            this.klblRed.ShowCurrentColourValue = true;
            this.klblRed.Size = new System.Drawing.Size(121, 21);
            this.klblRed.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.klblRed.StateCommon.LongText.Color2 = System.Drawing.Color.Red;
            this.klblRed.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblRed.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.klblRed.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.klblRed.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblRed.TabIndex = 6;
            this.klblRed.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblRed.UseAccessibleUI = false;
            this.klblRed.Values.Text = "Red Value: 255";
            // 
            // knbBlue
            // 
            this.knbBlue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.knbBlue.ImeMode = System.Windows.Forms.ImeMode.On;
            this.knbBlue.LargeChange = 20;
            this.knbBlue.Location = new System.Drawing.Point(31, 311);
            this.knbBlue.Maximum = 255;
            this.knbBlue.Minimum = 0;
            this.knbBlue.Name = "knbBlue";
            this.knbBlue.ShowLargeScale = false;
            this.knbBlue.ShowSmallScale = true;
            this.knbBlue.Size = new System.Drawing.Size(91, 91);
            this.knbBlue.SizeLargeScaleMarker = 6;
            this.knbBlue.SizeSmallScaleMarker = 3;
            this.knbBlue.SmallChange = 5;
            this.knbBlue.TabIndex = 5;
            this.knbBlue.Value = 0;
            this.knbBlue.ValueChanged += new Krypton.Toolkit.Suite.Extended.Base.ValueChangedEventHandler(this.knbBlue_ValueChanged);
            // 
            // knbGreen
            // 
            this.knbGreen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.knbGreen.ImeMode = System.Windows.Forms.ImeMode.On;
            this.knbGreen.LargeChange = 20;
            this.knbGreen.Location = new System.Drawing.Point(31, 167);
            this.knbGreen.Maximum = 255;
            this.knbGreen.Minimum = 0;
            this.knbGreen.Name = "knbGreen";
            this.knbGreen.ShowLargeScale = false;
            this.knbGreen.ShowSmallScale = true;
            this.knbGreen.Size = new System.Drawing.Size(91, 91);
            this.knbGreen.SizeLargeScaleMarker = 6;
            this.knbGreen.SizeSmallScaleMarker = 3;
            this.knbGreen.SmallChange = 5;
            this.knbGreen.TabIndex = 4;
            this.knbGreen.Value = 0;
            this.knbGreen.ValueChanged += new Krypton.Toolkit.Suite.Extended.Base.ValueChangedEventHandler(this.knbGreen_ValueChanged);
            // 
            // knbRed
            // 
            this.knbRed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.knbRed.ImeMode = System.Windows.Forms.ImeMode.On;
            this.knbRed.LargeChange = 20;
            this.knbRed.Location = new System.Drawing.Point(31, 23);
            this.knbRed.Maximum = 255;
            this.knbRed.Minimum = 0;
            this.knbRed.Name = "knbRed";
            this.knbRed.ShowLargeScale = false;
            this.knbRed.ShowSmallScale = true;
            this.knbRed.Size = new System.Drawing.Size(91, 91);
            this.knbRed.SizeLargeScaleMarker = 6;
            this.knbRed.SizeSmallScaleMarker = 3;
            this.knbRed.SmallChange = 5;
            this.knbRed.TabIndex = 3;
            this.knbRed.Value = 0;
            this.knbRed.ValueChanged += new Krypton.Toolkit.Suite.Extended.Base.ValueChangedEventHandler(this.knbRed_ValueChanged);
            // 
            // KryptonRGBColourKnobControlVertical
            // 
            this.Controls.Add(this.kryptonBlueValueLabel1);
            this.Controls.Add(this.klblGreen);
            this.Controls.Add(this.klblRed);
            this.Controls.Add(this.knbBlue);
            this.Controls.Add(this.knbGreen);
            this.Controls.Add(this.knbRed);
            this.Name = "KryptonRGBColourKnobControlVertical";
            this.Size = new System.Drawing.Size(169, 460);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void knbRed_ValueChanged(object Sender)
        {

        }

        private void knbGreen_ValueChanged(object Sender)
        {

        }

        private void knbBlue_ValueChanged(object Sender)
        {

        }
    }
}