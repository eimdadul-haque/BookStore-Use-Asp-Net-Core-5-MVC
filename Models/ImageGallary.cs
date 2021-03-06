using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_Use_Asp_Net_Core_5_MVC.Models
{
    public class ImageGallary
    {
        public int Id { get; set; }

        public string ImageName { get; set; }

        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book book { get; set; }

    }
}
