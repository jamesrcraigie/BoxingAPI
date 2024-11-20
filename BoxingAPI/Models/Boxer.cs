using System.ComponentModel.DataAnnotations;

namespace BoxingAPI.Models
{
    public class Boxer
    {
        
        public Guid Id { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public Guid RegisteredGymId { get; set; }

        // Navigation Property
        public Gym? RegisteredGym { get; set; }
    }
}
