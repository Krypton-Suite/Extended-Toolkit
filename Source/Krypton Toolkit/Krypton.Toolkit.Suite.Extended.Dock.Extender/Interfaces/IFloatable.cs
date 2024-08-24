namespace Krypton.Toolkit.Suite.Extended.Dock.Extender
{
    public interface IFloatable
    {
        /// <summary>
        /// show the floaty 
        /// </summary>
        void Show();

        /// <summary>
        /// hide the floaty
        /// </summary>
        void Hide();

        /// <summary>
        /// set a caption for the floaty
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// indicates if a floaty may dock only on the host docking control (e.g. the form)
        /// and not inside other floaties
        /// </summary>
        bool DockOnHostOnly { get; set; }

        /// <summary>
        /// indicates if a floaty may dock on the inside or on the outside of a form/control
        /// default is true
        /// </summary>
        bool DockOnInside { get; set; }

        event EventHandler Docking;
    }
}