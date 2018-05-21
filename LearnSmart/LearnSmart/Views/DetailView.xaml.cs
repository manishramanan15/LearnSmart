using LearnSmart.Controls.FormsVideoLibrary;
using LearnSmart.Models.Tutorial;
using LearnSmart.Services.Tutorials;
using LearnSmart.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearnSmart.Views
{
    public partial class DetailView : ContentPage
    {
        public DetailView()
        {
            InitializeComponent();
        }

        void OnPlayPauseButtonClicked(object sender, EventArgs args)
        {
            var item = new TutorialStatus()
            {
                Id = "1",
                LastPayedTime = videoPlayer.TimeToEnd,
                TutorialName = "sample"

            };
            var player = videoPlayer;
            if (player.Status == VideoStatus.Playing)
            {
                player.Pause();

            }
            else if (player.Status == VideoStatus.Paused)
            {
                player.Play();
            }

            item.LastAction = Enum.GetName(typeof(VideoStatus), player.Status);
            var service = Locator.Instance.Resolve<ITutorialsService>();
            service.SaveVideoStatus(item);
        }

        void OnStopButtonClicked(object sender, EventArgs args)
        {
            var item = new TutorialStatus()
            {
                Id = "1",
                LastPayedTime = videoPlayer.TimeToEnd,
                TutorialName = "sample",
                LastAction = "Stop"
            };

            var service = Locator.Instance.Resolve<ITutorialsService>();
            service.SaveVideoStatus(item);

            var player = videoPlayer;
            player.Stop();

        }

    }


}