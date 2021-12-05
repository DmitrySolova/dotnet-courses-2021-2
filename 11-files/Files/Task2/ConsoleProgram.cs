using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class ConsoleProgram
    {
        public static void Start(string path)
        {
            PathConfigure pathConfigure = new PathConfigure();
            Watcher watcher = new Watcher();
            Rollbacker rollbacker = new Rollbacker();

            bool fistTime = true;
            string systemFlag = "start";
            string modeFlag = "";

            while (systemFlag == "start")
            {
                Console.WriteLine();
                Console.WriteLine("Привет, это программа слежения за файлами");
                Console.WriteLine("В каком режиме будем работать?");
                Console.WriteLine("Внимание! Первый режим работы обязательно должен быть watch, иначе программа будет работать некорректно!");
                Console.WriteLine("watch - в режиме слежения");
                Console.WriteLine("rollback - в режиме отката изменений");
                Console.WriteLine("exit - выйди из программы (удалит временную папку и папку отслеживания файлов)");

                Console.WriteLine();
                modeFlag = Console.ReadLine().ToLower();
                Console.WriteLine();

                if (modeFlag == "watch")
                {
                    fistTime = false;
                    pathConfigure = watcher.Watching(path, Tools.InitializeFolders(path, pathConfigure));
                }

                if (modeFlag == "rollback" && !fistTime)
                {
                    pathConfigure = rollbacker.Rollbacking(pathConfigure);
                }

                if (modeFlag == "exit")
                {
                    systemFlag = "stop";
                }

            }

            if (systemFlag == "stop")
            {
                Stop();
            }

        }

        public static void Stop()
        {
            //Tools.FinalizeFolders();
        }

    }
}
