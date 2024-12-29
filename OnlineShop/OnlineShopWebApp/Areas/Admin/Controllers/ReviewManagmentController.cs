using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Service;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    public class ReviewManagmentController : Controller
    {
        private readonly ReviewService _reviewService;

        public ReviewManagmentController(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        //public async Task<ActionResult<List<ReviewDTO>>> GetByProductIdAsync(Guid productId)
        //{

        //    var result = await _reviewService.GetAllByProductIdAsync(productId);
        //    return Ok(Mapping.ToReviewApiModels(result));
        //}




        //public async Task<ActionResult<ReviewDTO>> GetByIdAsync(Guid reviewId)
        //{
        //    try
        //    {
        //        var result = await _reviewService.TryGetByIdAsync(reviewId);
        //        return Ok(Mapping.ToReviewApiModel(result));
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError(e.Message, e);
        //        return BadRequest(new { Error = e.Message });
        //    }
        //}

        //[HttpPost("Add")]
        //public async Task<ActionResult> AddAsync(AddReviewDTO addReview)
        //{
        //    try
        //    {
        //        await _reviewService.AddAsync(addReview);
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError(e.Message, e);
        //        return BadRequest(new { Error = e.Message });
        //    }
        //}


        //public async Task<ActionResult> DeleteAsync(Guid id)
        //{
        //    try
        //    {
        //        await _reviewService.TryToDeleteAsync(id);
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError(e.Message, e);
        //        return BadRequest(new { Error = e.Message });
        //    }
        //}
    }
}
