using LearnSmart.Controls.FormsVideoLibrary;
using LearnSmart.Models.Tutorial;
using LearnSmart.Services.Navigation;
using LearnSmart.Services.Tutorials;
using LearnSmart.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LearnSmart.ViewModels
{
    public class DetailViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private ITutorialsService _tutorialService;
        private string _video;
        private Tutorial _tutorial;


        public DetailViewModel(
           INavigationService navigationService,
           ITutorialsService tutorialService)
        {
            _navigationService = navigationService;
            _tutorialService = tutorialService;
        }

        public Tutorial Tutorial
        {
            get { return _tutorial; }
            set
            {
                _tutorial = value;
                OnPropertyChanged();
            }
        }

        public string Video
        {
            get { return _video; }
            set
            {
                _video = value;
                OnPropertyChanged();
            }
        }

        public ICommand ItemSelectedCommand => new Xamarin.Forms.Command<VideoPlayer>(VideoUpdates);
        
        private async void VideoUpdates(VideoPlayer item)
        {
            if (item.IsEnabled)
            {
                
            }
        }

        public override async Task InitializeAsync(object navigationData)
        {
            if (navigationData is Tutorial)
            {
                IsBusy = true;

                var tutorial = (Tutorial)navigationData;
                Tutorial = tutorial;
                var videos = await _tutorialService.GetVideosAsync(tutorial.Id);
                
                if (videos.Videos.Any())
                {
                    var video = videos.Videos.First();
                    Video = string.Format("{0}{1}", AppSettings.YouTubeUrl, video.Key);
                }

                IsBusy = false;
            }
        }

    }
}
