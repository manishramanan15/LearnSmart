using LearnSmart.Models;
using LearnSmart.Models.Tutorial;
using System.Threading.Tasks;

namespace LearnSmart.Services.Tutorials
{
    public interface ITutorialsService
    {
        Task<SearchResponse<Tutorial>> GetLatestTutorials(int pageNumber = 1, string language = "en");

        Task<TutorialVideo> GetVideosAsync(int movieId, string language = "en");

        Task<TutorialStatus> SaveVideoStatus(TutorialStatus tutorialStatus);
    }
}