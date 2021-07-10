using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_Use_Asp_Net_Core_5_MVC.Models
{
    public class Book
    {
        public int Id { get; set; }
        
        [Required]
        public string Author { get; set; }
        
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public int categoryId { get; set; }
        [ForeignKey("categoryId")]
        public Category category { get; set; }

        [Required]
        public int languageId { get; set; }
        [ForeignKey("languageId")]
        public Language language { get; set; }

        [Display(Name ="Total Page")]
        public int TotalPage { get; set; }

        public DateTime LastUpdate { get; set; } = DateTime.Now;

        public string PdfName { get; set; }
        [NotMapped]
        [Required]
        public IFormFile BookPDF { get; set; }

        public List<ImageGallary> ImgeUrl { get; set; }
        [NotMapped]
        public IFormFileCollection ImageFile { get; set; }
    }
}
