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

    public ActionResult GetReview(Guid productId, string userLogin)
    {
        var reviewAdd = Mapping.ToReviewTransit(productId, userLogin);
        return View(reviewAdd);
    }

    public async Task<ActionResult> GetByProductIdAsync(Guid productId, string userLogin)
    {
        var reviews = await _reviewService.GetAllByProductIdAsync(productId);
        if (reviews.Count != 0)
        {
            return View(Mapping.ToReviewViewModels(reviews));
        }
        else
        {
            return RedirectToAction("GetReview", new { productId, userLogin });
        }
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

    [Authorize]
    public async Task<ActionResult> DeleteAsync(Guid id, string userLogin)
    {
        if (ModelState.IsValid)
        {
            await _reviewService.TryToDeleteAsync(id, userLogin);
            return Redirect("~/Home/Index");
        }
        else
        {
            return Redirect("~/Home/Index");
        }
    }
}
