using LearnSmart.Models;
using LearnSmart.Models.Tutorial;
using LearnSmart.Services.Request;
using System.Threading.Tasks;

namespace LearnSmart.Services.Tutorials
{
    public class TutorialsService : ITutorialsService
    {
        private readonly IRequestService _requestProvider;

        public TutorialsService(IRequestService requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<SearchResponse<Tutorial>> GetLatestTutorials(int pageNumber = 1, string language = "en")
        {
            string uri = $"{AppSettings.ApiUrl}movie/popular?api_key={AppSettings.ApiKey}&language={language}&page={pageNumber}";

            var response = await _requestProvider.GetAsync<SearchResponse<Tutorial>>(uri);

            return response;
        }

        public async Task<TutorialVideo> GetVideosAsync(int movieId, string language = "en")
        {
            string uri = $"{AppSettings.ApiUrl}movie/{movieId}/videos?api_key={AppSettings.ApiKey}&language={language}";

            var response = await _requestProvider.GetAsync<TutorialVideo>(uri);

            return response;
        }

        public async Task<TutorialStatus> SaveVideoStatus(TutorialStatus tutorialStatus)
        {
            string uri = $"{AppSettings.VideoApiUrl}/user/{tutorialStatus.Id}";

            var response = await _requestProvider.PutAsync<TutorialStatus>(uri, tutorialStatus);

            return response;
        }
    }
}