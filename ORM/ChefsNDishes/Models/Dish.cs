using System;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models
{
    public class Dish
    {
        [Key] // the below prop is the primary key, [Key] is not needed if named with pattern: ModelNameId
        public int DishId { get; set; }

        [Required]
        [MinLength (2, ErrorMessage = "Must be 2 characters")]
        public string Name {get; set; }

        [Required]
        [Range(1, Double.PositiveInfinity, ErrorMessage = "Must be more than 0")]
        public int Calories {get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Must be 2 characters")]
        public string Description {get; set;}

        [Required]
        [Range(1, 5, ErrorMessage = "Must be between 1 and 5")]
        public int Tastiness {get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        
        [Required]
        public int ChefId {get; set; }

        public Chef ChefOwner {get; set; }

    }
}