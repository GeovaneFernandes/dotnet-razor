using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {

        }
    }
}
