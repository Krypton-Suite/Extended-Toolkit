namespace Krypton.Toolkit.Suite.Extended.Dock.Extender;

public class Flotables : List<IFloatable>
{
    #region Implementation

    public IFloatable FindFloatables(Control control)
    {
        foreach (KryptonFloatableForm floatable in this)
        {
            if (floatable.DockState.Container.Equals(control))
            {
                return floatable;
            }
        }

        return null;
    }

    #endregion
}