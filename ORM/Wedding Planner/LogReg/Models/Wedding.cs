using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LogReg.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId {get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Minimum 2 characters required")]
        public string WedderOne {get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Minimum 2 characters required")]
        public string WedderTwo {get; set; }

        [Required]
        public DateTime Date {get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Minimum 2 characters required")]
        public string Address {get; set; }

        
        public int UserId {get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        
        // navigation
        public User Creator {get; set; }

        public List<Guest> Guests {get; set; }
    }
}