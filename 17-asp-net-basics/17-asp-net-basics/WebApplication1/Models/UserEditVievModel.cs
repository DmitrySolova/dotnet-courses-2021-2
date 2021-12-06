using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.Models
{
    public class UserEditVievModel
    {

        [Range(0, 150)]
        public int Age
        {
            get
            {
                return CalculateAge(Birthdate);
            }
        }

        public static int CalculateAge(DateTime birthDate)
        {
            DateTime now = DateTime.Now;

            int age = now.Year - birthDate.Year;

            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                age--;

            return age;
        }


        [Required]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        public List<SelectListItem> userSelectRewards { get; set; }
    }
}
