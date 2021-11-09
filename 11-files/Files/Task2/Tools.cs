using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Task2
{
    class Tools
    {
        private static PathConfigure _pathConfigure = new PathConfigure();
        public static string GetAccesTime(FileSystemEventArgs file)
        {
            string namePattern = "dd.MM.yyy HH-mm-ss";

            CultureInfo culture = CultureInfo.CreateSpecificCulture("ru-Ru");
            string time = File.GetLastAccessTime(file.FullPath).ToString(namePattern, culture);

            return time;
        }

        public static string GetAccesTime()
        {
            string namePattern = "dd.MM.yyy HH-mm-ss";

            CultureInfo culture = CultureInfo.CreateSpecificCulture("ru-Ru");
            string time = DateTime.Now.ToString(namePattern, culture);

            return time;
        }

        public static string CopyFolder(string fromPath, string toPath)
        {
            if (Directory.Exists(toPath))
            {
                Directory.Delete(toPath, true);
                CreateTempFolder(toPath);
            }


            string fileName = "";
            string destFile = "";

            if (Directory.Exists(fromPath))
            {
                string[] files = Directory.GetFiles(fromPath);

                foreach (string s in files)
                {
                    fileName = Path.GetFileName(s);
                    destFile = Path.Combine(toPath, fileName);
                    File.Copy(s, destFile, true);
                }
            }
            else
            {
                throw new Exception($"Не могу найти {fromPath}");
            }

            return toPath;
        }

        public static string CreateMainTempFolder(string path)
        {
            string temp = @"TempFolder\";
            string tempPath = CheckBackslash(path) + temp;

            DirectoryInfo dirInfo = new DirectoryInfo(tempPath);

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            return dirInfo.FullName;
        }

        public static string CreateWatchFolder(string path)
        {
            string watchFolder = @"WatchFolder\";
            string wathFolderPath = CheckBackslash(path) + watchFolder;

            DirectoryInfo dirInfo = new DirectoryInfo(wathFolderPath);

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            return dirInfo.FullName;
        }

        public static string CreateTempFolder(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            return dirInfo.FullName;
        }

        public static string CheckBackslash(string path)
        {
            string returnPath = path;

            if (!(returnPath[returnPath.Length - 1] == '\\'))
            {
                returnPath = path + @"\";
            }

            return returnPath;
        }

        public static PathConfigure InitializeFolders(string pathWhereCreateWatchFolder, PathConfigure pathConfigure)
        {
            _pathConfigure = pathConfigure;

            string watchFolderPath = Tools.CreateWatchFolder(Tools.CheckBackslash(pathWhereCreateWatchFolder));
            string mainTempFolderPath = Tools.CreateMainTempFolder(Tools.CheckBackslash(pathWhereCreateWatchFolder));

            _pathConfigure.MainFolderPath = pathWhereCreateWatchFolder;
            _pathConfigure.WatchFolderPath = watchFolderPath;
            _pathConfigure.TempFolderPath = mainTempFolderPath;

            return _pathConfigure;
        }

        public static void FinalizeFolders()
        {
            if (!(Directory.Exists(_pathConfigure.WatchFolderPath)))
            {
                throw new Exception($"Не могу найти {_pathConfigure.WatchFolderPath}");
            }

            if (!(Directory.Exists(_pathConfigure.TempFolderPath)))
            {
                throw new Exception($"Не могу найти {_pathConfigure.TempFolderPath}");
            }

            Directory.Delete(_pathConfigure.WatchFolderPath, true);
            Directory.Delete(_pathConfigure.TempFolderPath, true);
            _pathConfigure.Clear();
        }
    }
}
