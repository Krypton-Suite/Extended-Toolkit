namespace Examples
{
    public partial class RadialMenuExample : KryptonForm
    {
        public RadialMenuExample()
        {
            InitializeComponent();

            InitializeRadialMenu();
        }

        private void InitializeRadialMenu()
        {
            kryptonRadialMenu1.MenuItems.Clear();

            // ✅ Define main menu items
            kryptonRadialMenu1.MenuItems.Add("File");
            kryptonRadialMenu1.MenuItems.Add("Edit");
            kryptonRadialMenu1.MenuItems.Add("View");

            kryptonRadialMenu1.SegmentColors.Add(Color.Red);
            kryptonRadialMenu1.SegmentColors.Add(Color.Green);
            kryptonRadialMenu1.SegmentColors.Add(Color.Blue);

            // ✅ Add a submenu under "File"
            kryptonRadialMenu1.AddSubMenu("File", new List<string> { "New", "Open", "Save" },
                new List<Image> { null, null, null },
                new List<Color> { Color.DarkRed, Color.DarkOrange, Color.DarkCyan });
        }

        private void kryptonRadialMenu1_MenuItemClicked(object sender, string e)
        {
            KryptonMessageBox.Show($"You clicked on {e}");
        }

        private void kryptonRadialMenu1_SubMenuItemClicked(object sender, string e)
        {
            KryptonMessageBox.Show($"You clicked on {e}");
        }
    }
}
