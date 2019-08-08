using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(250,ErrorMessage = "The maximum length of the title is 250 characters.")]
        public string Title { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public Author Author;

    }
}
