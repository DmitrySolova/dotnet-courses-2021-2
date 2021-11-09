using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task1
{
    class Program
    {
        public static void ProcessFile(string filePath)
        {
            
            FileInfo fileInfo = new FileInfo(filePath);
            if (fileInfo.Exists)
            {
                string[] inputStrings = File.ReadAllLines(filePath);
                var outputStrings = new List<string>();

                foreach (string readString in inputStrings)
                {
                    double number = 0;

                    number = Int32.Parse(readString);
                    number = Math.Pow(number, 2);

                    outputStrings.Add(number.ToString());
                }

                File.WriteAllLines(filePath, outputStrings);
            }
        }
        static void Main(string[] args)
        {
            ProcessFile(@"C:\Users\SoloPC\Desktop\dotnet-courses-2021-2\11-files\Files\Task1\disposable_task_file.txt");
        }
    }
}
