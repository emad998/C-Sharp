using System;
using System.ComponentModel.DataAnnotations;

namespace LogReg.Models
{
    public class Participant
    {
         [Key]
        public int ParticipantId {get; set; }

        public int UserId {get; set; }

        public int PicnicId {get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // navigation properties
        public User User {get; set; }

        public Picnic Picnic {get; set; }
    }
}