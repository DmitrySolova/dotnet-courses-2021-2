using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    class Reward
    {
        private int _id = 0;
        private string _title = "";
        private string _description = "";

        public Reward(int id = 0, string title = "")
        {
            _id = id;
            Title = title;
        }

        public Reward (int id, string title, string description)
        {
            _id = id;
            Title = title;
            Description = description;
        }

        public int ID
        {
            get => _id;
            set => _id = value;
        }

        public string Title
        {
            get => _title;
            set
            {
                if (value.Length > 50)
                {
                    throw new Exception("Наименование не может быть > 50 символов");
                }

                _title = value;
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if (value.Length > 250)
                {
                    throw new Exception("Наименование не может быть > 50 символов");
                }

                _description = value;
            }
        }

    }
}
