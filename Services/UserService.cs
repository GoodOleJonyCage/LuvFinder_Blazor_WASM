 using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuvFinder_Blazor_WASM.Services
{
    public interface IUserService
    {

        Task<bool> Register(string username,string password);
        Task<IEnumerable<LuvFinder_ViewModels.User>> GetAll();
    }

    public class UserService : IUserService
    {
        private IHttpService _httpService;

        public UserService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<IEnumerable<LuvFinder_ViewModels.User>> GetAll()
        {
            return await _httpService.Get<IEnumerable<LuvFinder_ViewModels.User>>("/users");
        }

        public async Task<bool> Register(string username, string password)
        {
            return await _httpService.Post<bool>("/user/register", new { username, password });
        }
    }
}