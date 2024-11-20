using System.ComponentModel.DataAnnotations;

namespace BoxingAPI.Models
{
    public class Fight
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        // Red Corner Boxer
        [Required]
        public Guid WinnerBoxerId { get; set; }
        public Boxer? WinnerBoxer { get; set; }

        // Blue Corner Boxer
        [Required]
        public Guid LoserBoxerId { get; set; }
        public Boxer? LoserBoxer { get; set; }
    }
}
