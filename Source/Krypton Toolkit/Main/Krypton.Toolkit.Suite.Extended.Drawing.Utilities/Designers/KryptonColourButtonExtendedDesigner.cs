namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    internal class KryptonColourButtonExtendedDesigner : ControlDesigner
    {
        #region Constructor
        public KryptonColourButtonExtendedDesigner()
        {
            AutoResizeHandles = true;
        }
        #endregion

        #region Overrides
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                DesignerActionListCollection listCollection = new DesignerActionListCollection
                {
                    new KryptonColourButtonExtendedActionList(this)
                };

                return listCollection;
            }
        }
        #endregion
    }
}