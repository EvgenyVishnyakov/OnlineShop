using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.DTO;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Service;
using OnlineShopWebApp.ViewModels;

namespace OnlineShopWebApp.Controllers;

public class ReviewController : Controller
{
    private readonly ReviewService _reviewService;

    public ReviewController(ReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    public async Task<ActionResult<List<ReviewViewModel>>> GetByProductIdAsync(Guid productId)
    {
        var reviews = await _reviewService.GetAllByProductIdAsync(productId);
        return View(Mapping.ToReviewViewModels(reviews));
    }

    [HttpPost]
    public async Task<ActionResult> AddAsync(AddReviewDTO addReview)
    {
        await _reviewService.AddAsync(addReview);
        return Redirect("~/Home/Index");
    }

    [HttpPost]
    public async Task<ActionResult> DeleteAsync(Guid id, string userName)
    {
        await _reviewService.TryToDeleteAsync(id, userName);
        return Redirect("~/Home/Index");
    }
}
