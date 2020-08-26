using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductCategoriesTwo.Models
{
    public class Product
    {
        [Key]
        public int ProductId {get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Minimum 2 characters required")]
        public string Name {get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Minimum 2 characters required")]
        public string Description {get; set; }

        [Required]
        public double Price {get; set; }

        public List<Association> Associations {get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}