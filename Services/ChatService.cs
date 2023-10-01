using LuvFinder_ViewModels;

namespace LuvFinder_Blazor_WASM.Services
{

    public interface IChatService
    {
        Task<bool> AddChatMessage(string usernamefrom, string usernameto, string message);
        Task<bool> GetChatInvitationStatus(string usernamefrom, string usernameto);
        Task<bool> AreFriends(string usernamefrom, string usernameto);
    }

    public class ChatService : IChatService
    {
        private IHttpService _httpService;
        public ChatService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<bool> AddChatMessage(string usernamefrom, string usernameto, string message)
        {
            return await _httpService.Post<bool>("/chat/addchatmessage", new { usernamefrom, usernameto, message });
        }

        public async Task<bool> GetChatInvitationStatus(string usernamefrom, string usernameto)
        {
            return await _httpService.Post<bool>("/chat/chatinvitationstatus", new { usernamefrom, usernameto  });
        }

        public async Task<bool> AreFriends(string usernamefrom, string usernameto)
        {
            return await _httpService.Post<bool>("/chat/arefriends", new { usernamefrom, usernameto });
        }
    }
}
