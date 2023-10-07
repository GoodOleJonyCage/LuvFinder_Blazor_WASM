namespace LuvFinder_Blazor_WASM.Services
{
    public class BlogCountStateContainer
    {
        private readonly IBlogService _BlogService;
        public BlogCountStateContainer(IBlogService BlogService)
        {
            _BlogService = BlogService;
        }

        public int Count { get; private set; }

        public event Action? OnChange;

        public async void LoadCount(string username)
        {
            Count = await _BlogService.BlogCount(username);
            OnChange?.Invoke();
        }

    }
}
