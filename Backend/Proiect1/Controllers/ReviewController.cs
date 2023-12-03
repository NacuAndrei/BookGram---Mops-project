using Microsoft.AspNetCore.Mvc;
using Proiect1.BLL.Interfaces;
using Proiect1.BLL.Models;
using System.Threading.Tasks;

namespace Proiect1.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewManager manager;
        public ReviewController(IReviewManager reviewManager)
        {
            this.manager = reviewManager;
        }

        [HttpGet("GetAllReviews")]
        public async Task<IActionResult> GetAllReviews()
        {
            var reviews = manager.GetAllReviews();
            return Ok(reviews);
        }

        [HttpGet("GetReviewsByUserid/{id}")]
        public async Task<IActionResult> GetUserReviews([FromRoute] int id)
        {

            var userReviews = manager.GetUserReviews(id);

            return Ok(userReviews);

        }

        [HttpGet("GetReviewsByBookName/{bookName}")]
        public async Task<IActionResult> GetBookReviews([FromRoute] string bookName)
        {

            var bookReviews = manager.GetBookReviews(bookName);

            return Ok(bookReviews);

        }

        [HttpPost("CreateReview")]
        public async Task<IActionResult> CreateReview([FromBody] ReviewModel reviewModel)
        {

            manager.CreateReview(reviewModel);
            return Ok();
        }
        
        [HttpPut("UpdateReviewById{id}")]
        public async Task<IActionResult> UpdateChallenge([FromBody] ReviewModel reviewModel)
        {
            manager.UpdateReview(reviewModel);
            return Ok();
        }

        [HttpDelete("DeleteReviewBy{id}User")]
        public async Task<IActionResult> DeleteReview([FromRoute] int id)
        {
            manager.DeleteReview(id);
            return Ok();
        }

        [HttpDelete("DeleteReviewBy{id}Admin")]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteReviewAdmin([FromRoute] int id)
        {
            manager.DeleteReview(id);
            return Ok();
        }

        
    }
}
