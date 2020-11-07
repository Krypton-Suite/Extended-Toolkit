using System;
using System.ComponentModel;

namespace Krypton.Toolkit.Suite.Extended.Palette.Selectors
{
    public partial class KryptonPaletteDropButton : KryptonDropButton
    {
        public KryptonPaletteDropButton()
        {
            InitializeComponent();
        }

        private KryptonPaletteContextMenu _contextMenu = new KryptonPaletteContextMenu();

        [Category("Appearance")]
        [DefaultValue("Palette")]
        [Description("Controls the text of the drop down button.")]
        public string ButtonText
        {
            get { return Values.Text; }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                Values.Text = value;
            }
        }

        [Category("Behavior")]
        [DefaultValue(null)]
        [Description("The context menu to show when the user clicks the drop down.")]
        public override KryptonContextMenu KryptonContextMenu
        {
            get { return _contextMenu; }
            set
            {
                if (value == null)
                {
                    _contextMenu = new KryptonPaletteContextMenu();
                    return;
                }
                if (typeof(KryptonPaletteContextMenu) != value.GetType())
                {
                    throw new ArgumentException("Only instances of KryptonPaletteContextMenu can be assigned.");
                }
                _contextMenu = (KryptonPaletteContextMenu)value;
            }
        }

        [Category("Behavior")]
        [Description("Connects the palette selector to the KryptonManager of the parent form.")]
        [DefaultValue(null)]
        public KryptonManager KryptonManager
        {
            get
            {
                return KryptonContextMenu == null ? null : _contextMenu.KryptonManager;
            }
            set
            {
                if (KryptonContextMenu == null) KryptonContextMenu = new KryptonPaletteContextMenu();
                _contextMenu.KryptonManager = value;
            }
        }

        [Browsable(false)]
        public new string Text
        {
            get { return Values.Text; }
            set { Values.Text = value; }
        }
    }
}