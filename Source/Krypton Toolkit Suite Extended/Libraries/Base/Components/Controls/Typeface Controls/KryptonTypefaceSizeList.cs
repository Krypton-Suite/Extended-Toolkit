using System.Collections;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class KryptonTypefaceSizeList : UserControl
    {
        #region Designer Code
        private Krypton.Toolkit.KryptonListBox klstSizes;
        private Krypton.Toolkit.KryptonNumericUpDown knumSizes;

        private void InitializeComponent()
        {
            this.knumSizes = new Krypton.Toolkit.KryptonNumericUpDown();
            this.klstSizes = new Krypton.Toolkit.KryptonListBox();
            this.SuspendLayout();
            // 
            // knumSizes
            // 
            this.knumSizes.Dock = System.Windows.Forms.DockStyle.Top;
            this.knumSizes.Location = new System.Drawing.Point(0, 0);
            this.knumSizes.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.knumSizes.Name = "knumSizes";
            this.knumSizes.Size = new System.Drawing.Size(74, 28);
            this.knumSizes.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumSizes.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumSizes.TabIndex = 2;
            this.knumSizes.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // klstSizes
            // 
            this.klstSizes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klstSizes.Location = new System.Drawing.Point(0, 28);
            this.klstSizes.Name = "klstSizes";
            this.klstSizes.Size = new System.Drawing.Size(74, 459);
            this.klstSizes.TabIndex = 3;
            // 
            // KryptonTypefaceSizeList
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.klstSizes);
            this.Controls.Add(this.knumSizes);
            this.Name = "KryptonTypefaceSizeList";
            this.Size = new System.Drawing.Size(74, 487);
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private ArrayList _textSizeList = new ArrayList(16);

        private int _currentTextSize, _minimumTextSize, _maximumTextSize;
        #endregion

        #region Properties
        public int CurrentTextSize { get => _currentTextSize; set { _currentTextSize = value; Invalidate(); } }

        public int MinimumTextSize { get => _minimumTextSize; set { _minimumTextSize = value; Invalidate(); } }

        private int MaximumTextSize { get => _maximumTextSize; set { _maximumTextSize = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonTypefaceSizeList()
        {
            InitializeComponent();

            SetupControl();
        }
        #endregion

        #region Methods
        private void PropagateTextSizeList()
        {
            _textSizeList.Add("8");

            _textSizeList.Add("9");

            _textSizeList.Add("10");

            _textSizeList.Add("11");

            _textSizeList.Add("12");

            _textSizeList.Add("14");

            _textSizeList.Add("16");

            _textSizeList.Add("18");

            _textSizeList.Add("20");

            _textSizeList.Add("22");

            _textSizeList.Add("24");

            _textSizeList.Add("26");

            _textSizeList.Add("28");

            _textSizeList.Add("36");

            _textSizeList.Add("48");

            _textSizeList.Add("72");
        }

        private void SetupControl()
        {
            PropagateTextSizeList();

            foreach (string item in _textSizeList)
            {
                klstSizes.Items.Add(item);
            }

            SetMinimumTextSize(8);

            SetMaximumTextSize(72);
        }
        #endregion

        #region Setters and Getters
        /// <summary>
        /// Sets the CurrentTextSize.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetCurrentTextSize(int value) => CurrentTextSize = value;

        /// <summary>
        /// Gets the CurrentTextSize.
        /// </summary>
        /// <returns>The value of CurrentTextSize.</returns>
        public int GetCurrentTextSize() => CurrentTextSize;

        /// <summary>
        /// Sets the MinimumTextSize.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetMinimumTextSize(int value) => MinimumTextSize = value;

        /// <summary>
        /// Gets the MinimumTextSize.
        /// </summary>
        /// <returns>The value of MinimumTextSize.</returns>
        public int GetMinimumTextSize() => MinimumTextSize;

        /// <summary>
        /// Sets the MaximumTextSize.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetMaximumTextSize(int value) => MaximumTextSize = value;

        /// <summary>
        /// Gets the MaximumTextSize.
        /// </summary>
        /// <returns>The value of MaximumTextSize.</returns>
        public int GetMaximumTextSize() => MaximumTextSize;
        #endregion
    }
}