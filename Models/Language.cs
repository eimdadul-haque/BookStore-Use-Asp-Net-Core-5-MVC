using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_Use_Asp_Net_Core_5_MVC.Models
{
    public class Language
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Language")]
        public string language { get; set; }
    }
}

