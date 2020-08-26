using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models
{
    public class Chef
    {
        [Key] // the below prop is the primary key, [Key] is not needed if named with pattern: ModelNameId
        public int ChefId { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Must be at least 3 characters")]
        public string FirstName {get; set;}

        [Required]
        [MinLength(3, ErrorMessage = "Must be at least 3 characters")]
        public string LastName {get; set;}

        [Required]
        public DateTime DateOfBirth {get; set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<Dish> Dishes {get; set; }

        


    }
}