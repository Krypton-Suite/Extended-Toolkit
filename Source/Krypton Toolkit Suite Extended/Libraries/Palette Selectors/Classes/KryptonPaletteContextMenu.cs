using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Text;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Palette.Selectors
{
    public partial class KryptonPaletteContextMenu : KryptonContextMenu
    {
        public KryptonPaletteContextMenu()
        {
            InitializeComponent();
            DefaultContextMenu();
        }

        #region Fields

        private CustomPaletteCollection _customPalettes = new CustomPaletteCollection();
        private bool _ignoreDuplicates = true;
        private bool _initialized;
        private PaletteSortOrder _sortOrder = PaletteSortOrder.Alphabetical;
        private Collection<PaletteModeManager> _standardPalettes = new Collection<PaletteModeManager>();
        private static readonly List<string> _replacements = new List<string> { "2003", "2007", "2010" };

        #endregion

        #region Properties

        [Category("Behavior")]
        [Description("Controls which custom palettes are available.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(CustomPaletteCollectionEditor), typeof(UITypeEditor))]
        public CustomPaletteCollection CustomPalettes
        {
            get { return _customPalettes; }
            set { _customPalettes = value; }
        }

        [Category("Behavior")]
        [DefaultValue(true)]
        [Description("If set to true duplicate palette names will be ignored, otherwise a DuplicatePaletteNameException will be thrown.")]
        public bool IgnoreDuplicates
        {
            get { return _ignoreDuplicates; }
            set { _ignoreDuplicates = value; }
        }

        [Category("Behavior")]
        [Description("Connects the palette selector to the KryptonManager of the parent form.")]
        [DefaultValue(null)]
        public KryptonManager KryptonManager { get; set; }

        [Category("Appearance")]
        [DefaultValue("Available Palettes")]
        [Description("Controls the context menu heading of the drop down button.")]
        public string MenuHeadingText
        {
            get
            {
                return ((KryptonContextMenuHeading)MenuItems.Items[0]).Text;
            }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                ((KryptonContextMenuHeading)MenuItems.Items[0]).Text = value;
            }
        }

        private KryptonContextMenuItems MenuItems
        {
            get { return (KryptonContextMenuItems)Items[0]; }
        }

        [Category("Behavior")]
        [DefaultValue(PaletteSortOrder.Alphabetical)]
        [Description("Controls how the palettes are sorted in the comntext menu.")]
        public PaletteSortOrder SortPalettes
        {
            get { return _sortOrder; }
            set { _sortOrder = value; }
        }

        [Category("Behavior")]
        [Description("Controls which of the standard palettes are available.")]
        public Collection<PaletteModeManager> StandardPalettes
        {
            get { return _standardPalettes; }
            set { _standardPalettes = value; }
        }

        [Category("Behavior")]
        [Description("Connects the palette selector to the StatusStrip of the parent form.")]
        [DefaultValue(null)]
        public StatusStrip StatusStrip { get; set; }

        #endregion

        #region Methods

        private void AddPalette(CustomPalette customPalette)
        {
            if (MenuItems.Items.Contains(customPalette.DisplayName)) return;
            var item = new KryptonContextMenuItem(customPalette.DisplayName) { Tag = customPalette };
            item.Click += OnCustomPaletteSelected;
            MenuItems.Items.Add(item);
        }

        private void AddPalette(PaletteModeManager mode)
        {
            AddPalette(mode, false);
        }

        private void AddPalette(PaletteModeManager mode, bool isChecked)
        {
            if (mode == PaletteModeManager.Custom) return;
            var name = FormatPaletteName(mode);
            if (MenuItems.Items.Contains(name)) return;
            var item = new KryptonContextMenuItem(name) { Tag = mode, Checked = isChecked };
            item.Click += OnStandardPalatteSelected;
            MenuItems.Items.Add(item);
        }

        private void AddPalettes()
        {
            IDictionary<string, object> palettes = new Dictionary<string, object>();
            switch (_sortOrder)
            {
                case PaletteSortOrder.CustomFirst:
                    palettes = LoadCustomPalettes(palettes);
                    palettes = LoadStandardPalettes(palettes);
                    break;
                default:
                    palettes = LoadStandardPalettes(palettes);
                    palettes = LoadCustomPalettes(palettes);
                    break;
            }
            if (_sortOrder == PaletteSortOrder.Alphabetical) palettes = new SortedDictionary<string, object>(palettes);
            foreach (var item in palettes)
            {
                if (item.Value.GetType() == typeof(PaletteModeManager))
                {
                    AddPalette((PaletteModeManager)item.Value);
                    continue;
                }
                AddPalette((CustomPalette)item.Value);
            }
        }

        private void CheckCurrentPalette()
        {
            if (KryptonManager == null) return;
            var exists = false;
            var mode = KryptonManager.GlobalPaletteMode;
            foreach (var item in MenuItems.Items)
            {
                if (item.GetType() != typeof(KryptonContextMenuItem)) continue;
                if (item.Tag.GetType() == typeof(PaletteModeManager))
                {
                    ((KryptonContextMenuItem)item).Checked = mode == (PaletteModeManager)item.Tag ? true : false;
                    if (((KryptonContextMenuItem)item).Checked) exists = true;
                    continue;
                }
                var palette = KryptonManager.GlobalPalette;
                var customPalette = (CustomPalette)item.Tag;
                ((KryptonContextMenuItem)item).Checked = palette == customPalette.Palette ? true : false;
                if (!((KryptonContextMenuItem)item).Checked) exists = true;
            }
            //probably not worth adding custom palettes on the fly, but we can easily add standard ones
            if (exists || mode == PaletteModeManager.Custom) return;
            AddPalette(mode, true);
        }

        private void DefaultContextMenu()
        {
            KryptonContextMenuItems menuItems = new KryptonContextMenuItems();
            KryptonContextMenuHeading heading = new KryptonContextMenuHeading("Available Palettes");
            menuItems.Items.Add(heading);
            Items.Add(menuItems);
        }

        private static Collection<PaletteModeManager> DefaultPalettes()
        {
            var modes = new Collection<PaletteModeManager>();
            foreach (var mode in Enum.GetValues(typeof(PaletteModeManager)))
            {
                if ((PaletteModeManager)mode != PaletteModeManager.Custom)
                    modes.Add((PaletteModeManager)mode);
            }
            return modes;
        }

        private static string FormatPaletteName(PaletteModeManager mode)
        {
            var characters = mode.ToString().ToCharArray();
            var sb = new StringBuilder();
            foreach (var c in characters)
            {
                if (char.IsUpper(c)) sb.Append(" ");
                sb.Append(c);
            }
            foreach (var replacement in _replacements)
                sb.Replace(replacement, " " + replacement);
            return sb.ToString().TrimStart();
        }

        private void InitializeMenu()
        {
            if (_initialized) return;
            AddPalettes();
            CheckCurrentPalette();
            _initialized = true;
        }

        private static bool IsInDesignMode()
        {
            var designMode = false;
#if DEBUG
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                designMode = true;
            }
            else if (Process.GetCurrentProcess().ProcessName.ToUpper().Equals("DEVENV"))
            {
                designMode = true;
            }
#endif
            return designMode;
        }

        private IDictionary<string, object> LoadCustomPalettes(IDictionary<string, object> palettes)
        {
            foreach (CustomPalette palette in _customPalettes)
            {
                if (!palettes.ContainsKey(palette.DisplayName)) palettes.Add(palette.DisplayName, palette);
                if (IsInDesignMode() || _ignoreDuplicates) continue;
                throw new DuplicatePaletteNameException(string.Format("A palette with the name '{0}' already exists.", palette.DisplayName));
            }
            return palettes;
        }

        private IDictionary<string, object> LoadStandardPalettes(IDictionary<string, object> palettes)
        {
            foreach (var pallete in _standardPalettes)
            {
                var displayName = FormatPaletteName(pallete);
                if (!palettes.ContainsKey(displayName)) palettes.Add(displayName, pallete);
                if (IsInDesignMode() || _ignoreDuplicates) continue;
                throw new DuplicatePaletteNameException(string.Format("A palette with the name '{0}' already exists.", displayName));
            }
            return palettes;
        }

        private void SetPalette(CustomPalette customPalette)
        {
            if (KryptonManager == null) return;
            if (StatusStrip != null) StatusStrip.RenderMode = customPalette.RenderMode;
            KryptonManager.GlobalPalette = customPalette.Palette;
            KryptonManager.GlobalPaletteMode = PaletteModeManager.Custom;
        }

        private void SetPalette(PaletteModeManager mode)
        {
            if (KryptonManager == null) return;
            if (StatusStrip != null) StatusStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            KryptonManager.GlobalPalette = null;
            KryptonManager.GlobalPaletteMode = mode;
        }

        #endregion

        #region Events

        private void OnCustomPaletteSelected(object sender, EventArgs e)
        {
            var item = (KryptonContextMenuItem)sender;
            var customPalette = (CustomPalette)item.Tag;
            SetPalette(customPalette);
            OnPaletteSelected(sender, new PaletteSelectedEventArgs(customPalette));
        }

        private void OnGlobalPaletteChanged(object sender, EventArgs e)
        {
            InitializeMenu();
            CheckCurrentPalette();
        }

        protected override void OnOpening(CancelEventArgs e)
        {
            InitializeMenu();
            base.OnOpening(e);
        }

        protected virtual void OnPaletteSelected(object sender, PaletteSelectedEventArgs e)
        {
            var handler = PaletteSelected;
            if (handler == null) return;
            handler(this, e);
        }

        private void OnStandardPalatteSelected(object sender, EventArgs e)
        {
            var item = (KryptonContextMenuItem)sender;
            var mode = (PaletteModeManager)item.Tag;
            SetPalette(mode);
            OnPaletteSelected(sender, new PaletteSelectedEventArgs(FormatPaletteName(mode), mode));
        }

        public event EventHandler<PaletteSelectedEventArgs> PaletteSelected;

        #endregion

    }
}