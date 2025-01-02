using System.ComponentModel.DataAnnotations;

namespace ReviewClientWebApi.DTO
{
    public class AddReviewDTO
    {
        [Required(ErrorMessage = "Не указан email")]
        [EmailAddress(ErrorMessage = "введите Ваш email")]
        public string UserLogin { get; set; }

        public Guid ProductId { get; set; }

        [Required]
        public string? Text { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Оценка должна быть от 1 до 5")]
        public int Grade { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
