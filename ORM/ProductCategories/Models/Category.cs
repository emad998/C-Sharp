using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductCategories.Models
{
    public class Category
    {
        [Key]
        public int CategoryId {get; set;}

        [Required]
        [MinLength(2, ErrorMessage = "Must be 2 characters")]
        public string Name {get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<Association> Products {get; set;}


    }
}