using System;
using System.Text;

namespace Entities
{
    public class User
    {
        private int _id = 0;
        private string _firstName = "";
        private string _lastName = "";
        private DateTime _birthdate;
        private int _age = 0;
        private string[] _rewards = new string[0];
        private string _rewardsString = "";

        public User()
        {

        }
        public User(int id)
        {
            ID = id;
        }
        public User(int id, string firstName, string lastName, DateTime birthdate)
        {
            _id = id;
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
        }

        public User(int id, string firstName, string lastName, DateTime birthdate, string[] rewards)
        {
            _id = id;
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
            Rewards = rewards;
        }

        public int ID
        {
            get => _id;
            set => _id = value;
        }

        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }

        public DateTime Birthdate
        {
            get => _birthdate.Date;
            set => _birthdate = value;
        }

        public string[] Rewards
        {
            get => _rewards;
            set => _rewards = value;
        }

        public string RewardsString
        {
            get => RewardsToString(_rewards);
        }

        public int Age
        {
            get
            {
                _age = CalculateAge(Birthdate);
                return _age;
            }
        }

        private static string RewardsToString(string[] rewardsArr)
        {
            var sb = new StringBuilder();

            foreach (var reward in rewardsArr)
            {
                sb.Append(reward);
                sb.Append(" ");
            }

            return sb.ToString();
        }

        public static int CalculateAge(DateTime birthDate)
        {
            DateTime now = DateTime.Now;

            int age = now.Year - birthDate.Year;

            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                age--;

            return age;
        }

    }
}
