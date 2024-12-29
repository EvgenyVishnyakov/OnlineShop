using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.DTO;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Service;

namespace OnlineShopWebApp.Controllers;

public class ReviewController : Controller
{
    private readonly ReviewService _reviewService;

    public ReviewController(ReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    public async Task<ActionResult> GetByProductIdAsync(Guid productId)
    {
        var reviews = await _reviewService.GetAllByProductIdAsync(productId);
        return View(Mapping.ToReviewViewModels(reviews));
    }

    [Authorize]
    public ActionResult Add(string userLogin, Guid productId)
    {
        if (ModelState.IsValid)
        {
            var addReview = new AddReviewDTO();
            addReview.UserLogin = userLogin;
            addReview.ProductId = productId;
            return View(addReview);
        }
        else
        {
            return Redirect("~/Home/Index");
        }
    }

    public async Task<ActionResult> AddReviewAsync(AddReviewDTO addReview)
    {
        await _reviewService.AddAsync(addReview);
        return Redirect("~/Home/Index");
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteAsync(Guid id, string userName)
    {
        await _reviewService.TryToDeleteAsync(id, userName);
        return Redirect("~/Home/Index");
    }
}
