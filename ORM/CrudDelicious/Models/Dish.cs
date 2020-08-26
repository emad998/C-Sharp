using System;
using System.ComponentModel.DataAnnotations;

namespace CrudDelicious.Models
{
    public class Dish
    {
        [Key]
        public int DishId {get; set;}

        [Required]
        [MinLength(3, ErrorMessage = "Must be more than 3 characters. ")]
        public string Name {get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Must be more than 3 characters. ")]
        public string Chef {get; set;}

        public int Tastiness {get; set;}

        public int Calories {get; set;}

        public string Description {get; set;}

        public DateTime CreatedAt {get; set; } = DateTime.Now;
        public DateTime UpdatedAt {get; set; } = DateTime.Now;
    }
}