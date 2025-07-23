using ChallengeFocare2.Infrastructure;

namespace ChallengeFocare2
{
    class Program
    {
        static void Main()
        {
            using GoogleSearchService searchService = new GoogleSearchService();
            searchService.OpenGoogleAndFilterTopResults(2);
        }
    }
}
