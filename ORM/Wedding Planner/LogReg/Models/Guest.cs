using System;
using System.ComponentModel.DataAnnotations;

namespace LogReg.Models
{
    public class Guest
    {
        [Key]
        public int GuestId {get; set; }

        public int UserId {get; set; }

        public int WeddingId {get; set; }

        // navigation
        public User User {get; set; }

        public Wedding Wedding {get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}