using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.Models
{
    public class Book
    {
        [Key]
        public string ID { get; set; }
        [Required]
        [StringLength(100)]
        public string BookName { get; set; }
        [Required]
        [StringLength(100)]
        public string AuthorName { get; set; }
    }
}
