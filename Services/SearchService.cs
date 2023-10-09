using LuvFinder_ViewModels;

namespace LuvFinder_Blazor_WASM.Services
{
    public interface ISearchService
    {
        Task<LuvFinder_ViewModels.SearchCriteria> InitializeSearchCriteria();
        Task<LuvFinder_ViewModels.SearchCriteria> GetSearchResults(LuvFinder_ViewModels.SearchCriteria vm);
    }

    public class SearchService: ISearchService
    {
        private IHttpService _httpService;

        public SearchService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<SearchCriteria> GetSearchResults(SearchCriteria vm)
        {
            return await _httpService.Post<SearchCriteria>("/search/search", new { vm });
        }

        public async Task<SearchCriteria> InitializeSearchCriteria()
        {
            return await _httpService.Get<SearchCriteria>("/search/getsearchcriteria");
        }
    }
}
