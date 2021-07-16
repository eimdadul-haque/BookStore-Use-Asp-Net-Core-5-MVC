using Microsoft.AspNetCore.Identity;
using System;

namespace BookStore_Use_Asp_Net_Core_5_MVC.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
