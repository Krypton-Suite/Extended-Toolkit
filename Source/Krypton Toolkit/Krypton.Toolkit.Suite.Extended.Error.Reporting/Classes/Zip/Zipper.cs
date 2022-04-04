namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    internal class Zipper : IZipper
    {
        public void Zip(string zipFile, IEnumerable<string> files)
        {
            using (var zip = new ZipFile(zipFile))
            {
                zip.AddFiles(files, directoryPathInArchive: "");
                zip.Save();
            }
        }
    }
}