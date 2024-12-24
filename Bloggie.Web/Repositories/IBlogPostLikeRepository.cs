namespace Bloggie.Web.Repositories
{
    public interface IBlogPostLikeRepository
    {
        Task<int> GetTotalLikesForBlog(Guid blogPostId);
    }
}
