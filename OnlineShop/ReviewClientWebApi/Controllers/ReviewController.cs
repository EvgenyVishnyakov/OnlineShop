using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using ReviewClientWebApi.DTO;
using ReviewClientWebApi.Service;

namespace ReviewClientWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ReviewController : Controller
{
    private readonly ReviewService _reviewService;
    private readonly UserManager<User> _userManager;

    public ReviewController(ReviewService reviewService, UserManager<User> userManager)
    {
        _reviewService = reviewService;
        _userManager = userManager;

    }

    [HttpGet("Get")]
    public async Task<ActionResult> GetReviewAsync(Guid reviewId)
    {
        var reviewDb = await _reviewService.TryGetByIdAsync(reviewId);
        if (reviewDb != null)
        {
            return Ok(reviewDb);
        }
        else
            return Ok($"Отзыва {reviewId} не существует");
    }

    [HttpGet("GetReviewsByProduct")]
    public async Task<ActionResult> GetByProductIdAsync(Guid productId)
    {
        var reviews = await _reviewService.GetAllByProductIdAsync(productId);
        if (reviews.Count != 0)
        {
            return Ok(reviews);
        }
        else
        {
            return BadRequest($"Ошибка в поиске списка отзывов");
        }
    }

    [HttpPost("Add")]
    public async Task<ActionResult> AddReviewAsync(AddReviewDTO addReview)
    {
        var controlUser = await _userManager.FindByEmailAsync(addReview.UserLogin);
        if (controlUser != null)
        {
            var result = await _reviewService.AddAsync(addReview);
            if (result)
            {
                return Ok(new { Message = $"Отзыв успешно добавлен" });
            }

            return BadRequest($"Возникла ошибка при добавлении отзыва");
        }
        else
        {
            return BadRequest($"Пользователь {addReview.UserLogin} не зарегистрирован");
        }
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult> DeleteAsync(Guid id, string userLogin)
    {

        var result = await _reviewService.TryToDeleteAsync(id, userLogin);
        if (result)
        {
            return Ok(new { Message = $"Отзыв {id} успешно удален" });
        }

        return BadRequest($"Возникла ошибка при добавлении отзыва {id}");

    }
}

