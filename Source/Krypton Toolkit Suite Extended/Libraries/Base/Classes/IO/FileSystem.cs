using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public static class FileSystem
    {
        #region Constants
        //https://stackoverflow.com/questions/5188527/how-to-deal-with-files-with-a-name-longer-than-259-characters
        public const string LONG_PATH_PREFIX = @"\\?\";
        #endregion

        #region Methods
        /// <summary>Adds the long path prefix.</summary>
        /// <param name="path">The path.</param>
        /// <returns>The long path prefix.</returns>
        public static string AddLongPathPrefix(this string path) => LONG_PATH_PREFIX + path;


        /// <summary>Withouts the long path prefix.</summary>
        /// <param name="path">The path.</param>
        /// <returns>The path.</returns>
        public static string WithoutLongPathPrefix(this string path) => path.Replace(LONG_PATH_PREFIX, "");

        /// <summary>Loads the file tree asynchronously.</summary>
        /// <param name="fileNode">The node.</param>
        public static void LoadFileTreeAsync(object fileNode)
        {
            TreeItem node = (TreeItem)fileNode;

            foreach (string entry in Directory.EnumerateFileSystemEntries(node.ItemData))
            {
                FileAttributes attr = File.GetAttributes(entry);
                if (attr.HasFlag(FileAttributes.System))
                    continue;

                try
                {
#if !NETCORE31 && !NET5
                    Directory.GetAccessControl(entry);
#endif 
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }


                TreeItem childNode;

                if (attr.HasFlag(FileAttributes.Directory))
                {
                    childNode = new TreeItem(entry, node);
                    node.AddChild(childNode);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(LoadFileTreeAsync), childNode);
                }
                else
                {
                    childNode = new TreeItem(entry, node);
                    node.AddChild(childNode);
                }
            }
        }

        /// <summary>Gets the file tree node by path.</summary>
        /// <param name="path">The path.</param>
        /// <param name="fileTree">The file tree.</param>
        /// <returns>The current file node.</returns>
        public static TreeItem GetFileTreeNodeByPath(string path, TreeItem fileTree)
        {
            if (path == fileTree.ItemData)
                return fileTree;

            string[] tokens = path
                .WithoutLongPathPrefix()
                .Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);

            TreeItem currentNode = null;

            void nextNode(TreeItem node, int step)
            {
                if (step >= tokens.Length) return;

                foreach (TreeItem childNode in node.Childs)
                {
                    string name = childNode.ItemData.WithoutLongPathPrefix()
                        .Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries)
                        .Last();
                    if (name == tokens[step])
                    {
                        currentNode = childNode;
                        nextNode(childNode, step + 1);
                    }
                }
            }

            nextNode(fileTree, 0);
            return currentNode;
        }


        /// <summary>Copies and paste the directory.</summary>
        /// <param name="sourceDir">The source directory.</param>
        /// <param name="destDir">The destination directory.</param>
        /// <exception cref="Exception">Target folder is a subdirectory of the source folder.</exception>
        public static void CopyAndPasteDirectory(DirectoryInfo sourceDir, DirectoryInfo destDir)
        {
            //Is the target folder a sub-directory of the original folder.
            for (DirectoryInfo dirInfo = destDir.Parent; dirInfo != null; dirInfo = dirInfo.Parent)
            {
                if (dirInfo.FullName == sourceDir.FullName)
                    throw new Exception("Target folder is a subdirectory of the source folder.");
            }

            //Create a destination folder.
            if (!Directory.Exists(destDir.FullName))
                Directory.CreateDirectory(destDir.FullName);

            //Copying files.
            foreach (FileInfo fileInfo in sourceDir.GetFiles())
            {
                fileInfo.CopyTo(Path.Combine(destDir.FullName, fileInfo.Name));
            }

            //Recursive copying of the directories.
            foreach (DirectoryInfo sourceSubDir in sourceDir.GetDirectories())
            {
                DirectoryInfo destSubDir = destDir.CreateSubdirectory(sourceSubDir.Name);
                CopyAndPasteDirectory(sourceSubDir, destSubDir);
            }
        }


        /// <summary>Files the size string.</summary>
        /// <param name="fileSize">Size of the file.</param>
        /// <returns>The file size as a string.</returns>
        public static string FileSizeString(long fileSize)
        {
            string fileSizeStr = string.Empty;

            //MidpointRounding.AwayFromZero - if on one side is zero, it is rounded to another number

            if (fileSize < 1024 * 1024)
            {
                fileSizeStr = Math.Round(fileSize * 1.0 / 1024, 2, MidpointRounding.AwayFromZero) + " KB";
            }
            else if (fileSize >= 1024 * 1024 && fileSize < 1024 * 1024 * 1024)
            {
                fileSizeStr = Math.Round(fileSize * 1.0 / (1024 * 1024), 2, MidpointRounding.AwayFromZero) + " MB";
            }
            else if (fileSize >= 1024 * 1024 * 1024)
            {
                fileSizeStr = Math.Round(fileSize * 1.0 / (1024 * 1024 * 1024), 2, MidpointRounding.AwayFromZero) + " GB";
            }

            return fileSizeStr;
        }


        /// <summary>Gets the size of the directory.</summary>
        /// <param name="dirPath">The directory path.</param>
        /// <returns>The size of the directory.</returns>
        /// <exception cref="ArgumentException">This is not a directory</exception>
        public static long GetDirectorySize(string dirPath)
        {
            if (!Directory.Exists(dirPath))
                throw new ArgumentException("This is not a directory");

            long getSize(string dir)
            {
                long size = 0;
                DirectoryInfo directoryInfo = new DirectoryInfo(dir);

                //Add the size of all the files to the current directory.
                FileInfo[] fileInfos = directoryInfo.GetFiles();
                if (fileInfos.Length > 0)
                {
                    size += fileInfos.Sum(fileInfo => fileInfo.Length);
                }

                //Recursively add the size of the sub-directories.
                DirectoryInfo[] directoryInfos = directoryInfo.GetDirectories();
                foreach (DirectoryInfo dirInfo in directoryInfos)
                {
                    size += getSize(dirInfo.FullName);
                }

                return size;
            }

            return getSize(dirPath);
        }


        /// <summary>Determines whether [is valid file name] [the specified file name].</summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>
        ///   <c>true</c> if [is valid file name] [the specified file name]; otherwise, <c>false</c>.</returns>
        public static bool IsValidFileName(string fileName)
        {
            const string errChar = "\\/:*?\"<>|";

            foreach (char ch in errChar)
            {
                if (fileName.Contains(ch.ToString()))
                    return false;
            }
            return true;
        }
        #endregion
    }
}