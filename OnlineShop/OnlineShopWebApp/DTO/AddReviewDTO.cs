using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.DTO
{
    public class AddReviewDTO
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public Guid ProductId { get; set; }

        [Required]
        public string? Text { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "Оценка должна быть от 0 до 5")]
        public int Grade { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
