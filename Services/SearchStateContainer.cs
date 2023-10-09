using LuvFinder_ViewModels;

namespace LuvFinder_Blazor_WASM.Services
{

    public interface ISearchStateContainer
    {
        SearchCriteria SearchCriteria { get; set; } 
        Task<SearchCriteria> GetSearchResults();
    }

    public class SearchStateContainer : ISearchStateContainer
    {
        private readonly ISearchService _SearchService;
        public SearchStateContainer(ISearchService SearchService)
        {
            _SearchService = SearchService;
        }

        public SearchCriteria SearchCriteria { get; set; } = new SearchCriteria();

        public async Task<SearchCriteria> GetSearchResults()
        {
            return await _SearchService.GetSearchResults(SearchCriteria);
        }
    }
}
