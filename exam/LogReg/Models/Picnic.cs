using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LogReg.Extensions;

namespace LogReg.Models
{
    public class Picnic
    {
        [Key]
        public int PicnicId {get; set; }

        [Required(ErrorMessage = "is required.")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        public string Title {get; set; }

        [Required(ErrorMessage = "is required.")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        public string Time { get; set; }


        [Required(ErrorMessage = "is required.")]
        [FutureDate]
        public DateTime PicnicDate {get; set;}

        [Required(ErrorMessage = "is required.")]
        public int DurationNumber {get; set; }

        [Required(ErrorMessage = "is required.")]
        public string DurationKind {get; set; }

        [Required(ErrorMessage = "is required.")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        public string Description {get; set; }

        public int UserId {get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // navigation properties
        public User Creator {get; set; }
        public List<Participant> Participants {get; set; }
    }
}