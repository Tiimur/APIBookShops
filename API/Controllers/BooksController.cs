using API.EFModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookstoreChainContext LocalContext = new();

        //[HttpGet("Main")]
        //public ActionResult<Book> Book
    }
}
