using System;
using System.Xml;

namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    /// <summary>
    /// Parameter class for Conditionnal Formatting
    /// </summary>
    /// <seealso cref="ICloneable" />
    public interface IFormatParams : ICloneable
    {
        /// <summary>
        /// Persists the parameters.
        /// </summary>
        /// <param name="writer">The XML writer.</param>
        void Persist(XmlWriter writer);
    }
}