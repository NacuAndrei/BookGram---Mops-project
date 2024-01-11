using Microsoft.AspNetCore.Mvc;
using Proiect1.BLL.Interfaces;
using Proiect1.BLL.Models;
using System.Threading.Tasks;

namespace Proiect1.Controllers
{
    [Route("api/Books")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IBookManager manager;
        public BookController(IBookManager bookManager)
        {
            this.manager = bookManager;
        }

        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook([FromBody] BookModel bookModel)
        {
            manager.AddBook(bookModel);
            return Ok();
        }

        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = manager.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("GetBookBy{title}")]
        public async Task<IActionResult> GetBook([FromRoute] string title)
        {
            var book = manager.GetBook(title);
            return Ok(book);
        }

        [HttpGet("GetBookRecommendations")]
        public async Task<IActionResult> GetBookRecommendations()
        {
            var books = manager.GetBookRecommendations();
            return Ok(books);
        }
    }
}
