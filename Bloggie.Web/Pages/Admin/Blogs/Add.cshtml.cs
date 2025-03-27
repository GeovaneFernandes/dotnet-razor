using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    [Authorize(Roles = "Admin")]
    public class AddModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly ILogger<AddModel> logger;

        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }

        //[BindProperty]
        //public IFormFile FeaturedImage { get; set; }

        [BindProperty(SupportsGet = false)]
        public IFormFile? FeaturedImage { get; set; }


        [BindProperty]
        [Required]
        public string Tags { get; set; }

        public AddModel(IBlogPostRepository blogPostRepository, ILogger<AddModel> logger)
        {
            this.blogPostRepository = blogPostRepository;
            this.logger = logger;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            ValidateAddBlogPost();

            if (!ModelState.IsValid)
            {
                logger.LogWarning("ModelState is invalid. Errors:");

                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        logger.LogWarning("Field: {Field}, Error: {Error}", state.Key, error.ErrorMessage);
                    }
                }

                return Page();
            }

            try
            {
                var blogPost = new BlogPost
                {
                    Heading = AddBlogPostRequest.Heading,
                    PageTitle = AddBlogPostRequest.PageTitle,
                    Content = AddBlogPostRequest.Content,
                    ShortDescription = AddBlogPostRequest.ShortDescription,
                    FeaturedImageUrl = AddBlogPostRequest.FeaturedImageUrl,
                    UrlHandle = AddBlogPostRequest.UrlHandle,
                    PublishedDate = AddBlogPostRequest.PublishedDate,
                    Author = AddBlogPostRequest.Author,
                    Visible = AddBlogPostRequest.Visible,
                    Tags = new List<Tag>(Tags.Split(',').Select(x => new Tag { Name = x.Trim() }))
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
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while adding the blog post.");
                // Optional: show a generic error message
                ModelState.AddModelError(string.Empty, "An unexpected error occurred. Please try again.");
                return Page();
            }
        }

        private void ValidateAddBlogPost()
        {
            if (AddBlogPostRequest.PublishedDate.Date < DateTime.Now.Date)
            {
                ModelState.AddModelError("AddBlogPostRequest.PublishedDate", $"PublishedDate can only be today's date or a future date");
            }
        }
    }
}
