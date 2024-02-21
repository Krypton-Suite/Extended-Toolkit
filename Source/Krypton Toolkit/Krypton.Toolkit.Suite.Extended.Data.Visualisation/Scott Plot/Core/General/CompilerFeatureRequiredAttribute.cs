namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// Allows required members in older .NET versions
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class CompilerFeatureRequiredAttribute : Attribute
    {
        public CompilerFeatureRequiredAttribute(string _)
        {
        }
    }
}