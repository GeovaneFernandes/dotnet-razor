using System.Text.Json;
using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class AddModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }

        [BindProperty]
        public  IFormFile FeaturedImage { get; set; }

        public AddModel(IBlogPostRepository blogPostRepository)
        {            
            this.blogPostRepository = blogPostRepository;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost() 
        {
            var blogPost = new BlogPost() {
                Heading = AddBlogPostRequest.Heading,
                PageTitle = AddBlogPostRequest.PageTitle,
                Content = AddBlogPostRequest.Content,
                ShortDescription = AddBlogPostRequest.ShortDescription,
                FeaturedImageUrl = AddBlogPostRequest.FeaturedImageUrl,
                UrlHandle = AddBlogPostRequest.UrlHandle,
                PublishedDate = AddBlogPostRequest.PublishedDate,
                Author = AddBlogPostRequest.Author,
                Visible = AddBlogPostRequest.Visible
            };

            await blogPostRepository.AddAsync(blogPost);

            var notification = new Notification
            {
                Type = Enums.NotificationType.Success,
                Message = "New Blog created!"
            };

            TempData["Notification"] = JsonSerializer.Serialize(notification);

            return RedirectToPage("/Admin/Blogs/List");
        }
    }
}
