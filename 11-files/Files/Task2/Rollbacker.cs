using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task2
{
    class Rollbacker
    {
        private static PathConfigure _pathConfigure = new PathConfigure();

        public PathConfigure Rollbacking(PathConfigure pathConfigure)
        {
            _pathConfigure = pathConfigure;

            Console.WriteLine("Программма в режиме отката изменений");

            string modeFlag = "";

            while (modeFlag != "stop-rollback")
            {
                Console.WriteLine();
                Console.WriteLine("Введи команду:");
                Console.WriteLine("show - для показа всех дат изменений");
                Console.WriteLine("input - для того чтобы ввести дату отката измемений");
                Console.WriteLine(@"Введите ""stop-rollback"" для выхода из режима отката изменений");
                Console.WriteLine();
                modeFlag = Console.ReadLine().ToLower();
                Console.WriteLine();
                var timeList = _pathConfigure.ReturnTempFoldersNames();

                if (modeFlag == "show")
                {

                    for (int i = 0; i < timeList.Length; i++)
                    {
                        Console.WriteLine($"[{i}] - {timeList[i]}");
                    }

                }

                if (modeFlag == "input")
                {
                    string inputTime = "";
                    
                    while (true)
                    {
                        Console.WriteLine("Введи время в формате dd.mm.yyyy hh-mm-ss");
                        Console.WriteLine("Например - 12.08.1990 17-08-24");
                        Console.WriteLine(@"Введите ""stop"" для выхода");

                        Console.WriteLine();
                        inputTime = Console.ReadLine();

                        foreach (string time in timeList)
                        {
                            if (inputTime == time)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Ввод корректен, начинаю процедуру отката");
                                Rollback(inputTime);
                                Console.WriteLine("Процедура отката закончена");
                                Console.WriteLine();

                                inputTime = "stop";

                                break;
                            }
                        }

                        if (inputTime == "stop")
                        {
                            break;
                        }

                        Console.WriteLine();
                        Console.WriteLine("Неккоректный ввод");
                        Console.WriteLine();
                    }

                }

            }

            return _pathConfigure;
        }

        private void Rollback(string time)
        {

            string fromPath = Tools.CheckBackslash(_pathConfigure.TempFolderPath) + Tools.CheckBackslash(time);
            string toPath = Tools.CheckBackslash(_pathConfigure.WatchFolderPath);

            System.IO.DirectoryInfo di = new DirectoryInfo(toPath);
            foreach (FileInfo file in di.EnumerateFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.EnumerateDirectories())
            {
                dir.Delete(true);
            }

            Tools.CopyFolder(fromPath, toPath);

        }

    }
}
