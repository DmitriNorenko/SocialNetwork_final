using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork_final.DB.Model
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public string About { get; set; }
        public string GetFullName()
        {
            return LastName + " " + FirstName + " " + MiddleName;
        }
        public User()
        {
            Image = "https://via.placeholder.com/500";
            Status = "Привет,Я в соцсети.";
            About = "Информация обо мне.";
        }
    }
}
