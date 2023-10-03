using LuvFinder_ViewModels;

namespace LuvFinder_Blazor_WASM.Services
{

    public interface IBlogService
    {
        Task<List<LuvFinder_ViewModels.Blog>> Blogs(string username);
        Task<int> BlogCount(string username);
        Task<LuvFinder_ViewModels.Blog> GetBlog(string username, int blogid);
        Task<bool> AddBlogComment(string username, int blogid, string comment, int replyto);
    }

    public class BlogService : IBlogService
    {
        private IHttpService _httpService;

        public BlogService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<List<Blog>> Blogs(string username)
        {
            return await _httpService.Post<List<Blog>>("/blog/blogs", new { username });
        }
        public async Task<int> BlogCount(string username)
        {
            return await _httpService.Post<int>("/blog/blogcount", new { username });
        }
        public async Task<LuvFinder_ViewModels.Blog> GetBlog(string username, int blogid)
        {
            return await _httpService.Post<LuvFinder_ViewModels.Blog>("/blog/blog", new { username, blogid });
        }

        public async Task<bool> AddBlogComment(string username, int blogid, string comment, int replyto)
        {
            return await _httpService.Post<bool>("/blog/addblogcomment", new { username,   blogid,   comment,   replyto });
        }
    }
}
