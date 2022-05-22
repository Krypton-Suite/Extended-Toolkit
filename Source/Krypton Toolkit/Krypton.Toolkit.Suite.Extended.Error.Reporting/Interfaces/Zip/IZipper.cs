namespace Krypton.Toolkit.Suite.Extended.Error.Reporting;

internal interface IZipper
{
    void Zip(string zipFile, IEnumerable<string> files);
}