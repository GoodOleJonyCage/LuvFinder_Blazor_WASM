using LuvFinder_ViewModels;
using Microsoft.AspNetCore.Components.Forms;
using System.Xml.Linq;

namespace LuvFinder_Blazor_WASM.Services
{

    public interface IBlogService
    {
        Task<List<LuvFinder_ViewModels.Blog>> Blogs(string username);
        Task<int> BlogCount(string username);
        Task<LuvFinder_ViewModels.Blog> GetBlog(string username, int blogid);
        Task<bool> AddBlogComment(string username, int blogid, string comment, int replyto);
        Task<string> UpdateBlog(byte[]? bytes, int blogid, string title, string body, string username);
        Task<string> AddBlog(byte[]? bytes,string title, string body, string username);
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

        public async Task<string> UpdateBlog(byte[]? bytes, int blogid, string title, string body, string username)
        {
            return await _httpService.PostBlog<string>("/blog/editblog",bytes, blogid, title, body, username );
        }

        public async Task<string> AddBlog(byte[]? bytes, string title, string body, string username)
        {
            return await _httpService.PostNewBlog<string>("/blog/createblog", bytes, title, body, username);
        }
    }
}
