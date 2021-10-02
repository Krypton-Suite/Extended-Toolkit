namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    /// <summary>
    /// Conditional Formatting type
    /// </summary>
    public enum EnumConditionalFormatType
    {
        /// <summary>
        /// Two scale color
        /// </summary>
        TwoColoursRange,
        /// <summary>
        /// Three scale color
        /// </summary>
        ThreeColoursRange,
        /// <summary>
        /// Bar
        /// </summary>
        Bar
    }

    /// <summary>
    /// Grid filling mode
    /// </summary>
    public enum FillMode
    {
        /// <summary>
        /// The grid contains only groups (faster).
        /// </summary>
        GroupsOnly,
        /// <summary>
        /// The grid contains groups and nodes (no choice, choose this one !)
        /// </summary>
        GroupsAndNodes
    }
}