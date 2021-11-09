using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task2
{
    class PathConfigure
    {
        private string _mainFolderPath = "";
        private string _watchFolderPath = "";
        private string _mainTempFolderPath = "";

        private string[] _tempFoldersNames = new string[0];

        public string MainFolderPath
        {
            get => _mainFolderPath;
            set => _mainFolderPath = value;
        }

        public string WatchFolderPath
        {
            get => _watchFolderPath;
            set => _watchFolderPath = value;
        }

        public string TempFolderPath
        {
            get => _mainTempFolderPath;
            set => _mainTempFolderPath = value;
        }

        public void AddTempName()
        {
            _tempFoldersNames = Directory
                .GetDirectories(_mainTempFolderPath)
                .Select(f => Path.GetFileName(f)).ToArray();
        }

        public string[] ReturnTempFoldersNames()
        {
            return _tempFoldersNames;
        }

        public void Clear()
        {
            _tempFoldersNames = new string[0];
            _mainFolderPath = "";
            _watchFolderPath = "";
            _mainTempFolderPath = "";
        }

    }
}
