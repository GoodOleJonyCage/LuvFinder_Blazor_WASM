//using LuvFinder_Blazor_WASM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuvFinder_Blazor_WASM.Services
{
    public interface IUserService
    {
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
    }
}