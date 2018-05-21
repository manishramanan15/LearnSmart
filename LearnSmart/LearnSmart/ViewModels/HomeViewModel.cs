using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using LearnSmart.ViewModels.Base;
using LearnSmart.Models.Tutorial;
using LearnSmart.Services.Tutorials;
using LearnSmart.Services.Navigation;

namespace LearnSmart.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private Tutorial _highlight;
        private ObservableCollection<Tutorial> _topRatedTutorials;
        private ITutorialsService _tutorialService;
        private INavigationService _navigationService;



        public HomeViewModel(
           INavigationService navigationService,
           ITutorialsService tutorialService)
        {
            _tutorialService = tutorialService;
            _navigationService = navigationService;
            TopRatedTutorials = new ObservableCollection<Tutorial>();
        }
        
        public ObservableCollection<Tutorial> TopRatedTutorials
        {
            get { return _topRatedTutorials; }
            set
            {
                _topRatedTutorials = value;
                OnPropertyChanged();
            }
        }

        public ICommand TutorialDetailCommand => new Command<Tutorial>(TutorialDetailAsync);


        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;
            await GetLatestTutorialsAync();
            IsBusy = false;
        }

        public Tutorial Highlight
        {
            get { return _highlight; }
            set
            {
                _highlight = value;
                OnPropertyChanged();
            }
        }

        private async void TutorialDetailAsync(object obj)
        {
            var tutorial = obj as Tutorial;

            if (tutorial != null)
            {
                await _navigationService.NavigateToAsync<DetailViewModel>(tutorial);
            }
        }

        private async Task GetLatestTutorialsAync()
        {
            var result = await _tutorialService.GetLatestTutorials();
            TopRatedTutorials = new ObservableCollection<Tutorial>(result.Results.Take(10));
            Highlight = result.Results.First();
        }
       
    }
}