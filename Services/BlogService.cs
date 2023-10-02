using LuvFinder_ViewModels;

namespace LuvFinder_Blazor_WASM.Services
{

    public interface IBlogService
    {
        Task<List<LuvFinder_ViewModels.Blog>> Blogs(string username);
        Task<int> BlogCount(string username);
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
    }
}
