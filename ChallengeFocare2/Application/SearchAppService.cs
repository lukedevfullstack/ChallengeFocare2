using ChallengeFocare2.Domain.Interfaces;

namespace ChallengeFocare2.Application.Services
{
    public class SearchAppService
    {
        private readonly ISearchService _searchService;

        public SearchAppService(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public void Run(int maxResults)
        {
            _searchService.OpenGoogleAndFilterTopResults(maxResults);
        }
    }
}