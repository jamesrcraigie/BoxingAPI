using System.ComponentModel.DataAnnotations;

namespace BoxingAPI.Models
{
    public class Gym
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        // Optional Navigation Property
        public ICollection<Boxer> Boxers { get; set; }
    }
}
