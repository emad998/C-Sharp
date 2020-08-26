using System.ComponentModel.DataAnnotations;
namespace FormSubmission.Models
{
    public class User
    {
        [Required]
        [MinLength(4)]
        public string FirstName {get; set; }

        [Required]
        [MinLength(4)]
        public string LastName {get; set;}

        [Required]
        [Range(1, 200, 
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        public string Email {get; set; }

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password {get; set; }

    }
}