using System.Drawing;

namespace Krypton.Toolkit.Extended.Base
{
    /// <summary>
    /// Represents a clickable element of <see cref="MonthView"/> control
    /// </summary>
    public interface ISelectableElement
    {

        /// <summary>
        /// Gets the bounds of the element
        /// </summary>
        Rectangle Bounds { get; }

        /// <summary>
        /// Gets if the element is currently selected
        /// </summary>
        bool Selected { get; }
    }
}