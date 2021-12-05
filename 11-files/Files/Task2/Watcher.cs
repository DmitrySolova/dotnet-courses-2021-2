using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Task2
{
    class Watcher
    {
        private static PathConfigure _pathConfigure = new PathConfigure();

        public PathConfigure Watching(string pathWhereCreateWatchFolder, PathConfigure pathConfigure)
        {
            _pathConfigure = pathConfigure;

            using var watcher = new FileSystemWatcher(Tools.CheckBackslash(_pathConfigure.WatchFolderPath));

            watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

            watcher.Changed += OnChanged;
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
            watcher.Renamed += OnRenamed;
            watcher.Error += OnError;
            watcher.Filter = "*.txt";
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;

            Console.WriteLine();
            Console.WriteLine("Программа в режиме наблюдения");

            string exitFlag = "";

            if (Directory.GetFiles(_pathConfigure.WatchFolderPath).Length != 0)
            {
                _pathConfigure.AddTempName();
            }

            while (exitFlag != "stop-watch")
            {
                Console.WriteLine(@"Введите ""stop-watch"" для выхода из режима наблюдения");
                Console.WriteLine();
                exitFlag = Console.ReadLine().ToLower();
                Console.WriteLine();
            }

            return _pathConfigure;
        }

        private static void OnChanged(object sender, FileSystemEventArgs file)
        {
            if (file.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }

            Console.WriteLine($"Изменение элемента: {file.FullPath}");
            Console.WriteLine($"Время изменения: {File.GetLastAccessTime(file.FullPath)}");

            string tempFolderName = Tools.GetAccesTime(file);
            // можно сделать через path
            //string path = Tools.CheckBackslash(_pathConfigure.TempFolderPath) + tempFolderName;
            string path = Path.Combine(_pathConfigure.TempFolderPath, tempFolderName);

            //_pathConfigure.AddTempName();

            Tools.CopyFolder(_pathConfigure, _pathConfigure.WatchFolderPath, path);
        }
        private static void OnCreated(object sender, FileSystemEventArgs file)
        {
            string value = $"Создан элемент: {file.FullPath}";

            string tempFolderName = Tools.GetAccesTime(file);
            string path = Tools.CheckBackslash(_pathConfigure.TempFolderPath) + tempFolderName;

            //_pathConfigure.AddTempName();

            Console.WriteLine(value);

            Tools.CopyFolder(_pathConfigure, _pathConfigure.WatchFolderPath, path);
        }
        private static void OnDeleted(object sender, FileSystemEventArgs file)
        {
            Console.WriteLine($"Удален элемент: {file.FullPath}");

            string tempFolderName = Tools.GetAccesTime();
            string path = Tools.CheckBackslash(_pathConfigure.TempFolderPath) + tempFolderName;

            string[] watchFolderFiles = Directory.GetFiles(_pathConfigure.WatchFolderPath);

            if (watchFolderFiles.Length != 0)
            {
                //_pathConfigure.AddTempName();

                Tools.CopyFolder(_pathConfigure, _pathConfigure.WatchFolderPath, path);
            }

        }
        private static void OnRenamed(object sender, RenamedEventArgs renamedFile)
        {
            Console.WriteLine($"Элемент переименован:");
            Console.WriteLine($"    Старое имя: {renamedFile.OldFullPath}");
            Console.WriteLine($"    Новое имя: {renamedFile.FullPath}");

            string tempFolderName = Tools.GetAccesTime(renamedFile);
            string path = Tools.CheckBackslash(_pathConfigure.TempFolderPath) + tempFolderName;

            //_pathConfigure.AddTempName();

            Tools.CopyFolder(_pathConfigure, _pathConfigure.WatchFolderPath, path);
        }
        private static void OnError(object sender, ErrorEventArgs error) =>
            PrintException(error.GetException());
        private static void PrintException(Exception? exception)
        {
            if (exception != null)
            {
                Console.WriteLine($"Сообщение об ошибке: {exception.Message}");
                Console.WriteLine("Трассировка стека:");
                Console.WriteLine(exception.StackTrace);
                Console.WriteLine();
                PrintException(exception.InnerException);
            }
        }

    }
}
