namespace Krypton.Toolkit.Suite.Extended.Error.Reporting;

internal interface IAssemblyDigger
{
    IEnumerable<AssemblyRef> GetAssemblyRefs();
}