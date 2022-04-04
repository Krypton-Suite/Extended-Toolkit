namespace Krypton.Toolkit.Suite.Extended.Error.Reporting;

internal interface IFileService
{
    bool Exists(string file);
    string TempFile(string file);
    FileSaveResult Write(string file, string report);
}