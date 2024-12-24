using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Blog
{
    public class DetailsModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IBlogPostLikeRepository blogPostLikeRepository;

        public BlogPost BlogPost { get; set; }
        public int TotalLikes { get; set; }

        public DetailsModel(IBlogPostRepository blogPostRepository,
            IBlogPostLikeRepository blogPostLikeRepository)
        {
            this.blogPostRepository = blogPostRepository;
            this.blogPostLikeRepository = blogPostLikeRepository;
        }
        public async Task<IActionResult> OnGet(string urlHandle)
        {
            BlogPost = await blogPostRepository.GetAsync(urlHandle);

            if (BlogPost != null)
            {
                TotalLikes = await blogPostLikeRepository.GetTotalLikesForBlog(BlogPost.Id);
            }
            return Page();
        }
    }
}
