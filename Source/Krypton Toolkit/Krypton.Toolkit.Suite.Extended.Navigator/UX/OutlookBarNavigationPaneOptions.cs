namespace Krypton.Toolkit.Suite.Extended.Navigator
{
    public partial class OutlookBarNavigationPaneOptions : KryptonForm
    {
        #region Fields

        private Collection _originalItemCollection = new Collection();

        private OutlookBarButtonCollection _items;

        #endregion

        #region Constructor

        
        public OutlookBarNavigationPaneOptions(OutlookBarButtonCollection items)
        {
            InitializeComponent();

            _items = items;

            foreach (OutlookBarButton button in _items)
            {
                _originalItemCollection.Add(button);
            }

            FillList();

            kclbItems.SelectedIndex = 0;
        }


        #endregion

        #region Event Handlers

        private void kbtnMoveUp_Click(object sender, EventArgs e)
        {
            int newIndex = clbItems.SelectedIndex - 1;

            _items.Insert(newIndex, (OutlookBarButton)clbItems.SelectedItem);

            _items.RemoveAt(newIndex + 2);

            FillList();

            clbItems.SelectedIndex = newIndex;
        }

        private void kbtnMoveDown_Click(object sender, EventArgs e)
        {
            OutlookBarButton button = (OutlookBarButton)clbItems.SelectedItem;

            int newIndex = clbItems.SelectedIndex + 2;

            _items.Insert(newIndex, (OutlookBarButton)clbItems.SelectedItem);

            _items.Remove(button);

            FillList();

            clbItems.SelectedIndex = newIndex - 1;
        }

        private void kbtnReset_Click(object sender, EventArgs e)
        {
            kbtnCancel_Click(sender, e);
        }

        private void kbtnOk_Click(object sender, EventArgs e)
        {
            foreach (OutlookBarButton button in _items)
            {
                button.Visible = false;
            }

            for (int b = 0; b <= clbItems.CheckedItems.Count - 1; b++)
            {
                ((OutlookBarButton)clbItems.CheckedItems[b]).Visible = true;
            }

            Close();
        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {
            _items.Clear();

            foreach (OutlookBarButton button in _originalItemCollection)
            {
                _items.Add(button);
            }
        }

        private void kclbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clbItems.SelectedIndex == 0)
            {
                kbtnMoveUp.Enabled = false;
            }
            else
            {
                kbtnMoveUp.Enabled = true;
            }

            if (clbItems.SelectedIndex == clbItems.Items.Count - 1)
            {
                kbtnMoveDown.Enabled = false;
            }
            else
            {
                kbtnMoveDown.Enabled = true;
            }

            if (clbItems.Items.Count == 1)
            {
                kbtnMoveUp.Enabled = false;

                kbtnMoveDown.Enabled = false;
            }
        }

        private void OutlookBarNavigationPaneOptions_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Methods

        private void FillList()
        {
            kclbItems.Items.Clear();

            foreach (OutlookBarButton button in _items)
            {
                if (button.Allowed)
                {
                    // kclbItems.Items.Add(button, button.Visible);

                    clbItems.Items.Add(button, button.Visible);
                }
            }
        }

        #endregion
    }
}
