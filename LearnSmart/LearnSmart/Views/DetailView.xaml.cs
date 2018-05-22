using LearnSmart.Controls.FormsVideoLibrary;
using LearnSmart.Models.Tutorial;
using LearnSmart.Services.Tutorials;
using LearnSmart.ViewModels.Base;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions;
using Plugin.MediaManager.Abstractions.Enums;
using Plugin.MediaManager.Abstractions.EventArguments;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearnSmart.Views
{
    public partial class DetailView : ContentPage
    {
        private IPlaybackController PlaybackController => CrossMediaManager.Current.PlaybackController;

        public DetailView()
        {
            InitializeComponent();
           
            CrossMediaManager.Current.VolumeManager.Mute = false;

            CrossMediaManager.Current.PlayingChanged += (sender, e) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ProgressBar.Progress = e.Progress;
                    Duration.Text = "" + e.Duration.TotalSeconds + " seconds";
                });
            };
        }

        protected override void OnAppearing()
        {
            videoView.Source = "http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4";
            CrossMediaManager.Current.StatusChanged += CurrentOnStatusChanged;
        }

        protected override void OnDisappearing() {
            CrossMediaManager.Current.StatusChanged -= CurrentOnStatusChanged;
        }


        void PlayClicked(object sender, System.EventArgs e)
        {
            PlaybackController.Play();
        }

        void PauseClicked(object sender, System.EventArgs e)
        {
            PlaybackController.Pause();
        }

        void StopClicked(object sender, System.EventArgs e)
        {
            PlaybackController.Stop();
        }
       

        private void CurrentOnStatusChanged(object sender, StatusChangedEventArgs e)
        {
            var item = new TutorialStatus()
            {
                Id = string.Empty,
                LastAction = Enum.GetName(typeof(MediaPlayerStatus), e.Status),
                TutorialName = "big buck bunny",
                LastPayedTime = CrossMediaManager.Current.VideoPlayer.Position.ToString("c")
            };
            var service = Locator.Instance.Resolve<ITutorialsService>();
                service.SaveVideoStatus(item);
        }

    }


}