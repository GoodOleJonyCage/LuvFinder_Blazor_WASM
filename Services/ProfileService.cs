using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuvFinder_Blazor_WASM.Services
{

    public interface IProfileService
    {
        Task<List<LuvFinder_ViewModels.UserInfo>> LoadProfles(string username);
    }
    
    public class ProfileService : IProfileService
    {
        private IHttpService _httpService;
        public ProfileService(IHttpService httpService) 
        { 
            _httpService = httpService;
        }

        public async Task<List<LuvFinder_ViewModels.UserInfo>> LoadProfles(string username)
        {
         
            return await _httpService.Post<List<LuvFinder_ViewModels.UserInfo>>("/profile/profiles", new {username});
        }
    }
}
