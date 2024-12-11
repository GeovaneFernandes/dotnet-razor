using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("This is the Images GET method!");
        }
    }
}
