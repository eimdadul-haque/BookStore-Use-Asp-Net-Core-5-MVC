using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_Use_Asp_Net_Core_5_MVC.ViewModels
{
    public class SignUp
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
   
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage ="Password dose not match")]
        public string Password { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
       
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}
