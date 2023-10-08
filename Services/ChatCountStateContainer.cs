namespace LuvFinder_Blazor_WASM.Services
{
    public class ChatCountStateContainer
    {
        private readonly IChatService _ChatService;
        public ChatCountStateContainer(IChatService ChatService)
        {
            _ChatService = ChatService;
        }

        public int Count { get; private set; }

        public event Action? OnChange;

        public async void LoadCount(string username)
        {
            Count = await _ChatService.GetChatMessagesCount(username);
            OnChange?.Invoke();
        }
    }
}
