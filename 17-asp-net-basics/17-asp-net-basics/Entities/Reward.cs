namespace Entities
{
    public class Reward
    {
        private int _id = 0;
        private string _title = "";
        private string _description = "";

        public Reward(int id = 0, string title = "")
        {
            _id = id;
            Title = title;
        }

        public Reward(int id, string title, string description)
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
            set => _title = value;
        }

        public string Description
        {
            get => _description;
            set => _description = value;
        }

    }
}
