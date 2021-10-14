using System;
using System.Text.RegularExpressions;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var dateOfBirdth = new DateTime(2008, 10, 6);
            User user = new User(dateOfBirdth, "Дмитрий", "Пешков", "Александрович");
            Console.WriteLine(user.Age);
            Console.WriteLine(user.LastName);
            Console.WriteLine(user.Name);
            Console.WriteLine(user.Patronymic);

        }
    }

}
