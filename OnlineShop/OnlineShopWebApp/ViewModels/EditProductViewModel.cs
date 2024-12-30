using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace OnlineShopWebApp.ViewModels
{
    public class EditProductViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Имя должно содержать от 5 до 30 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана цена")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "Допускается ввод только положительного числового выражения")]
        public int Cost { get; set; }

        [Required(ErrorMessage = "Не указано описание")]
        [StringLength(150, MinimumLength = 15, ErrorMessage = "Добавьте полноценное описание, минимум 15 символов, максимум 150")]
        public string Description { get; set; }

        [ValidateNever]
        public List<string> Images { get; set; }

        [Required(ErrorMessage = "Не выбран файл")]
        public IFormFile[] UploadedFiles { get; set; }


        [Required(ErrorMessage = "Не указана категория")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Обязательно укажите категорию. Минимум 5 символов, максимум 20")]
        public string Category { get; set; }

        public double Grade { get; set; }
    }
}
