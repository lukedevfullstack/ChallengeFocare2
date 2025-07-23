
namespace ChallengeFocare2.Application
{
    using ChallengeFocare2.Domain;

    public class SearchApplication
    {
        private readonly ISearchService _searchService;

        public SearchApplication(ISearchService searchService)
        {
            _searchService = searchService;
        }
    }
}
