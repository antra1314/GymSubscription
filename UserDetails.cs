using System.ComponentModel.DataAnnotations;

namespace StayFitGym.Model
{
    public class UserDetails
    {
        [Required][Key]
        public string UserID { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string DOB { get; set; }

      
    }
}