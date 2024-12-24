namespace Bloggie.Web.Repositories
{
    public interface IBlogPostLikeRepository
    {
        Task<int> GetTotalLikesForBlog(Guid blogPostId);

        Task AddLikeForBlog(Guid blogPostId, Guid userId);
    }
}
