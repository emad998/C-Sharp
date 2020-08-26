using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductCategoriesTwo.Models
{
    public class Category
    {
        [Key]
        public int CategoryId {get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Minimum 2 characters required")]
        public string Name {get; set; }

        public List<Association> Associations {get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}