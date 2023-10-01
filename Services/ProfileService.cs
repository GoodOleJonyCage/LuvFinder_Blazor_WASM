using LuvFinder_ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuvFinder_Blazor_WASM.Services
{

    public interface IProfileService
    {
        Task<List<LuvFinder_ViewModels.UserInfo>> LoadProfles(string username);
        Task<bool> GetLikeUserStatus(string usernamefrom, string usernameto);
        Task<bool> LikeUser(string usernamefrom, string usernameto);
        Task<LuvFinder_ViewModels.UserInfo> UserInfo(string username);
        Task<List<ProfileQuestion>> GetUserProfile(string username);
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
        public async Task<bool> GetLikeUserStatus(string usernamefrom, string usernameto)
        {
            return await _httpService.Post<bool>("/profile/likeuserstatus", new { usernamefrom, usernameto });
        }

        public async Task<bool> LikeUser(string usernamefrom, string usernameto)
        {
            return await _httpService.Post<bool>("/profile/likeuser", new { usernamefrom, usernameto });
        }

        public async Task<LuvFinder_ViewModels.UserInfo> UserInfo(string username)
        {
            return await _httpService.Post<LuvFinder_ViewModels.UserInfo>("/profile/userinfo", new { username });
        }
        //implement this
        public async Task<List<ProfileQuestion>> GetUserProfile(string username)
        {
            return await _httpService.Post<List<ProfileQuestion>>("/profile/userprofile", new { username });
        }
    }
}
