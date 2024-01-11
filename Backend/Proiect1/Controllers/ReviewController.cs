using Microsoft.AspNetCore.Mvc;
using Proiect1.BLL.Interfaces;
using Proiect1.BLL.Models;
using System.Threading.Tasks;

namespace Proiect1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewManager manager;
        public ReviewController(IReviewManager reviewManager)
        {
            this.manager = reviewManager;
        }

        //get all reviews
        [HttpGet("Get_All_Reviews")]
        public async Task<IActionResult> GetAllReviews()
        {
            var reviews = manager.GetAllReviews();
            return Ok(reviews);
        }

        // get the reviews made by a specific user
        [HttpGet("Get_Reviews_By_User_id/{id}")]
        public async Task<IActionResult> GetUserReviews([FromRoute] int id)
        {

            var userReviews = manager.GetUserReviews(id);

            return Ok(userReviews);

        }

        //get all the reviews for a specific book
        [HttpGet("Get_Reviews_By_bookname/{bookName}")]
        public async Task<IActionResult> GetBookReviews([FromRoute] string bookName)
        {

            var bookReviews = manager.GetBookReviews(bookName);

            return Ok(bookReviews);

        }

        //make a review (user)
        [HttpPost("Create_Review")]
        public async Task<IActionResult> CreateReview([FromBody] ReviewModel reviewModel)
        {

            manager.CreateReview(reviewModel);
            return Ok();
        }

        //edit a review with a given id (user)
        [HttpPut("Update_Review_By_{id}")]
        public async Task<IActionResult> UpdateChallenge([FromBody] ReviewModel reviewModel)
        {
            manager.UpdateReview(reviewModel);
            return Ok();
        }

        //delete a review with a given id (user)
        [HttpDelete("Delete_Review_By_{id}_User")]
        public async Task<IActionResult> DeleteReview([FromRoute] int id)
        {
            manager.DeleteReview(id);
            return Ok();
        }

        //delete a review with a given id (admin)
        [HttpDelete("Delete_Review_By_{id}_Admin")]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteReviewAdmin([FromRoute] int id)
        {
            manager.DeleteReview(id);
            return Ok();
        }

        [HttpGet("Get_Reviews_of_User's{id}_Friends")]
        public async Task<IActionResult> GetReviewsofFriends([FromRoute] int id)
        {
            var reviews = manager.GetReviewsofFriends(id);

            return Ok(reviews);
        }
    }
}