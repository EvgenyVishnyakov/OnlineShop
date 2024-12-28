using System.ComponentModel.DataAnnotations;

namespace ReviewApiClientWebApp.Models
{
    public class AddReviewDTO
    {
        public Guid ProductId { get; set; }

        public Guid UserId { get; set; }

        [Required]
        public string? Text { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "Оценка должна быть от 0 до 5")]
        public int Grade { get; set; }
    }

}
