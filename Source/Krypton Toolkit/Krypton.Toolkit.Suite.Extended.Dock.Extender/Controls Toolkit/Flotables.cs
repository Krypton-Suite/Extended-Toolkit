namespace Krypton.Toolkit.Suite.Extended.Dock.Extender
{
    public class Flotables : List<IFloatable>
    {
        #region Implementation

        public IFloatable? FindFloatables(Control control)
        {
            foreach (var floatable1 in this)
            {
                var floatable = (KryptonFloatableForm?)floatable1;
                if (floatable!.DockState.Container != null && floatable.DockState.Container.Equals(control))
                {
                    return floatable;
                }
            }

            return null;
        }

        #endregion
    }
}