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
        public static string AddLongPathPrefix(this string path)
        {
            return LONG_PATH_PREFIX + path;
        }


        public static string WithoutLongPathPrefix(this string path)
        {
            return path.Replace(LONG_PATH_PREFIX, "");
        }

        public static void LoadFileTreeAsync(object _node)
        {
            TreeItem node = (TreeItem)_node;

            foreach (string entry in Directory.EnumerateFileSystemEntries(node.ItemData))
            {
                FileAttributes attr = File.GetAttributes(entry);
                if (attr.HasFlag(FileAttributes.System))
                    continue;

                try
                {
                    Directory.GetAccessControl(entry);
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


        public static string FileSizeStr(long fileSize)
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
                fileSizeStr = Math.Round(fileSize * 1.0 / (1024 * 1024 * 1024), 2, MidpointRounding.AwayFromZero) +
                              " GB";
            }

            return fileSizeStr;
        }


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