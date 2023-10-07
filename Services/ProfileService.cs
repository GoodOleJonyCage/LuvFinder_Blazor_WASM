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
        Task<bool> SaveProfile(string username, LuvFinder_ViewModels.UserInfo info, List<LuvFinder_ViewModels.ProfileQuestion> vm);
        Task<List<Gender>> GetGenders();
        Task<List<MaritalStatus>> GetMaritalStatuses();
        Task<List<FriendActivity>> ActivityFriends(string usernameTo);
        Task<FriendActivity> StartFriendShip(string usernameFrom, string usernameTo);
        Task<int> GetFriendCount(string username);
        Task<List<LuvFinder_ViewModels.UserInfo>> GetFriendProfiles(string username);
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
            return await _httpService.Post<List<LuvFinder_ViewModels.UserInfo>>("/profile/profiles", new { username });
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

        public async Task<List<ProfileQuestion>> GetUserProfile(string username)
        {
            return await _httpService.Post<List<ProfileQuestion>>("/profile/userprofile", new { username });
        }

        public async Task<bool> SaveProfile(string username, UserInfo info, List<ProfileQuestion> vm)
        {
            return await _httpService.Post<bool>("/profile/saveprofile", new { username, info, vm });
        }

        public async Task<List<Gender>> GetGenders()
        {
            return await _httpService.Get<List<Gender>>("/profile/genders");
        }

        public async Task<List<MaritalStatus>> GetMaritalStatuses()
        {
            return await _httpService.Get<List<MaritalStatus>>("/profile/maritalstatuses");
        }

        public async Task<List<FriendActivity>> ActivityFriends(string usernameto)
        {
            return await _httpService.Post<List<FriendActivity>>("/profile/activityfriends", new { usernameto });
        }

        public async Task<FriendActivity>  StartFriendShip(string usernamefrom, string usernameto)
        {
            return await _httpService.Post<FriendActivity>("/profile/startfriendship", new { usernamefrom, usernameto });
        }

        public async Task<int> GetFriendCount(string username)
        {
            return await _httpService.Post<int>("/profile/friendcount", new { username });
        }

        public async Task<List<UserInfo>> GetFriendProfiles(string username)
        {
            return await _httpService.Post<List<LuvFinder_ViewModels.UserInfo>>("/profile/friends", new { username });
        }
    }
}
