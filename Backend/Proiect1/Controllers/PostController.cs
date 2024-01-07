using Microsoft.AspNetCore.Mvc;
using Proiect1.BLL.Interfaces;
using Proiect1.BLL.Models;
using Proiect1.DAL;
using System.Threading.Tasks;

namespace Proiect1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostManager manager;

        public PostController(IPostManager postManager, AppDbContext context)
        {
            this.manager = postManager;
        }

        [HttpGet("Select_all_user{id}_posts")]
        public async Task<IActionResult> GetUserPosts([FromRoute] int id)
        {
            var posts = manager.GetAllUserPosts(id);

            return Ok(posts);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var posts = manager.GetAllPosts();
            return Ok(posts);
        }


        [HttpPost("Create_Post")]
        public async Task<IActionResult> CreatePost([FromBody] PostModel postModel)
        {
            manager.CreatePost(postModel);
            return Ok();
        }

        [HttpPut("Update_post_By_Id")]
        public async Task<IActionResult> UpdatePost([FromBody] PostModel postModel)
        {
            manager.UpdatePost(postModel);
            return Ok();
        }

        [HttpDelete("Delete_Post_By_{id}")]
        public async Task<IActionResult> DeletePost([FromRoute] int id)
        {
            manager.DeletePost(id);
            return Ok();
        }

    }
}