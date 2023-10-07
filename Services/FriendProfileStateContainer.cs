using LuvFinder_ViewModels;

namespace LuvFinder_Blazor_WASM.Services
{
    public class FriendProfileStateContainer
    {
        private readonly IProfileService _ProfileService;
        public FriendProfileStateContainer(IProfileService ProfileService)
        {
            _ProfileService = ProfileService;
        }

        public List<UserInfo> Profiles { get; private set; } = new List<UserInfo>();

        public event Action? OnChange;

        public async void LoadProfiles(string username)
        {
            Profiles = await _ProfileService.GetFriendProfiles(username);
            OnChange?.Invoke();
        }
    }
}
