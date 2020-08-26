using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductCategories.Models
{
    public class Product
    {
        private List<Association> categories;

        [Key]
        public int ProductId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Must be 2 characters")]
        public string Name { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Must be 5 characters")]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<Association> Associations { get; set; }




    }
}