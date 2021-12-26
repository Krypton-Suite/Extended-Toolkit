using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.DataGridView;

namespace DataGridViewExt
{
    public partial class ListExample : KryptonForm
    {
        public ListExample()
        {
            InitializeComponent();
        }

        public class MasterStruct
        {
            public DateTime Dt { get; }
            public string Title { get; }
            public string Name { get; }
            public string Phone { get; }
            public string Status { get; }
            public int Age { get; }
            public string Press { get; }
            public bool State { get; }
            public int Index { get; }

            public MasterStruct(int index, DateTime dt, string title, string name, string phone, string status, int age, string press, bool state)
            {
                Dt = dt;
                Title = title;
                Name = name;
                Phone = phone;
                Status = status;
                Age = age;
                Press = press;
                State = state;
                Index = index;
            }
        }

        public class DetailStruct
        {
            public string Title { get; }
            public string Name { get; }
            public int Rating { get; }
            public int Index { get; }

            public DetailStruct(int index, string title, string name, int rating)
            {
                Index = index;
                Title = title;
                Name = name;
                Rating = rating;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create some simple test data for display
            var dt = DateTime.Now.Date;
            var masterList = new List<MasterStruct>
            {
                new (1, dt, "Mr", "Mark", "(55) 5555-5555", "Single", 36, "Press!", true),
                new (2, dt, "Mrs", "Mary", "(01) 2345-6789", "Married", 21, "Press!", false),
                new (3, dt, "Miss", "Mandy", "(03) 5555-1111", "Single", 44, "Press!", false),
                new (4, dt, "Ms", "Mercy", "(99) 2211-2211", "Single", 25, "Press!", true),
                new (5, dt, "Mr", "Micheal", "(07) 0070-0700", "Divorced", 35, "Press!", false),
                new (6, dt, "Mrs", "Marge", "(10) 2311-2311", "Married", 80, "Press!", true)
            };
            masterSingleDetailView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Index", Name = "Index", Visible = false});
            masterSingleDetailView1.SetMasterSource(new BindingSource { DataSource = masterList }, "Index");
            var detailList = new SimpleFilteredList<DetailStruct>
            {
                new (3, "Miss", "Mandy", 5),
                new (1, "Mr", "Mark", 1),
                new (1, "Mr", "Mark", 2),
                new (1, "Mr", "Mark", 3),
                new (1, "Mr", "Mark", 4),
            };
            var title = new KryptonDataGridViewComboBoxColumn
            {
                DataPropertyName = "Title", DropDownWidth = 121, HeaderText = "ComboBox",
                MinimumWidth = 6,
                Name = "colComboBox",
                Width = 75
            };
            title.Items.Add("Mr");
            title.Items.Add("Mrs");
            title.Items.Add("Miss");
            title.Items.Add("Ms");

            var name = new KryptonDataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Name",
                MinimumWidth = 6,
                Name = "colTextBox",
                Width = 100
            };

            var rating = new KryptonDataGridViewRatingColumn
            {
                DataPropertyName = "Rating",
                HeaderText = "Rating",
                MinimumWidth = 6,
                Name = "colRating",
                Width = 100
            };

            masterSingleDetailView1.AddSingleDetail(new BindingSource { DataSource = detailList}, @"Index",
                new DataGridViewColumn[]
                {
                    new DataGridViewTextBoxColumn { DataPropertyName = "Index", Name = "Index", Visible = false },
                    title,
                    name,
                    rating
                }
            );
        }

        private void rbOffice2010Blue_CheckedChanged(object sender, EventArgs e)
        {
            kryptonPalette.BasePaletteMode = PaletteMode.Office2010Blue;
        }

        private void rbOffice2007Blue_CheckedChanged(object sender, EventArgs e)
        {
            kryptonPalette.BasePaletteMode = PaletteMode.Office2007Blue;
        }

        private void rbOffice2007Black_CheckedChanged(object sender, EventArgs e)
        {
            kryptonPalette.BasePaletteMode = PaletteMode.Office2007Black;
        }

        private void rbOffice2003_CheckedChanged(object sender, EventArgs e)
        {
            kryptonPalette.BasePaletteMode = PaletteMode.ProfessionalOffice2003;
        }

        private void rbSystem_CheckedChanged(object sender, EventArgs e)
        {
            kryptonPalette.BasePaletteMode = PaletteMode.ProfessionalSystem;
        }

        private void rbSparkle_CheckedChanged(object sender, EventArgs e)
        {
            kryptonPalette.BasePaletteMode = PaletteMode.SparkleBlue;
        }

        private void rbStyleList_CheckedChanged(object sender, EventArgs e)
        {
            masterSingleDetailView1.GridStyles.Style = DataGridViewStyle.List;
        }

        private void rbStyleSheet_CheckedChanged(object sender, EventArgs e)
        {
            masterSingleDetailView1.GridStyles.Style = DataGridViewStyle.Sheet;
        }

        private void rbStyleCustom_CheckedChanged(object sender, EventArgs e)
        {
            masterSingleDetailView1.GridStyles.Style = DataGridViewStyle.Custom1;
        }

        private void buttonRandomCellColors_Click(object sender, EventArgs e)
        {
            Random rand = new();
            for (int i = 0; i < masterSingleDetailView1.Rows.Count; i++)
            {
                for (int j = 0; j < masterSingleDetailView1.ColumnCount; j++)
                {
                    Color foreColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                    Color backColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));

                    masterSingleDetailView1.Rows[i].Cells[j].Style.BackColor = foreColor;
                    masterSingleDetailView1.Rows[i].Cells[j].Style.ForeColor = backColor;
                }
            }
        }

        private void buttonClearCellColors_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < masterSingleDetailView1.Rows.Count; i++)
            {
                for (int j = 0; j < masterSingleDetailView1.ColumnCount; j++)
                {
                    masterSingleDetailView1.Rows[i].Cells[j].Style.BackColor = Color.Empty;
                    masterSingleDetailView1.Rows[i].Cells[j].Style.ForeColor = Color.Empty;
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

}
