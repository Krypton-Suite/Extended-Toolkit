namespace Krypton.Toolkit.Suite.Extended.Software.Updater.NetSparkle
{
    interface IAssemblyAccessor
    {
        string AssemblyCompany { get; }
        string AssemblyCopyright { get; }
        string AssemblyDescription { get; }
        string AssemblyProduct { get; }
        string AssemblyTitle { get; }
        string AssemblyVersion { get; }
    }
}