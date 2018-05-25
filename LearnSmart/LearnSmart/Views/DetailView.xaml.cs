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
        TimeSpan FixTimeSpan(TimeSpan ts) =>
    Device.RuntimePlatform == Device.Android ? TimeSpan.FromMilliseconds(ts.TotalSeconds) : ts;

        public DetailView()
        {
            InitializeComponent();
            CrossMediaManager.Current.VolumeManager.Mute = false;
        }

        protected override void OnAppearing()
        {
            //videoView.Source = "http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4";
            //CrossMediaManager.Current.StatusChanged += CurrentOnStatusChanged;
            CrossMediaManager.Current.PlayingChanged += (sender, e) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ProgressBar.Progress = e.Progress;
                    ProgressText.Text = FixTimeSpan(e.Duration).ToString(@"hh\:mm\:ss");
                    Duration.Text = FixTimeSpan(e.Position).ToString(@"hh\:mm\:ss");
                });
            };
        }

        protected override void OnDisappearing() {
            //CrossMediaManager.Current.StatusChanged -= CurrentOnStatusChanged;
        }


        void PlayClicked(object sender, System.EventArgs e)
        {
            UpdateStatus(MediaPlayerStatus.Playing);
            PlaybackController.Play();
        }

        void PauseClicked(object sender, System.EventArgs e)
        {
            UpdateStatus(MediaPlayerStatus.Paused);
            PlaybackController.Pause();
        }

        void StopClicked(object sender, System.EventArgs e)
        {
            UpdateStatus(MediaPlayerStatus.Stopped);
            PlaybackController.Stop();
        }

        private void UpdateStatus(MediaPlayerStatus status) {
            var item = new TutorialStatus()
            {
                Id = string.Empty,
                LastAction = Enum.GetName(typeof(MediaPlayerStatus), status),
                TutorialName = "big buck bunny",
                LastPayedTime = FixTimeSpan(CrossMediaManager.Current.VideoPlayer.Position).ToString(@"hh\:mm\:ss")
            };
            var service = Locator.Instance.Resolve<ITutorialsService>();
            service.SaveVideoStatus(item);
        }

        private void CurrentOnStatusChanged(object sender, StatusChangedEventArgs e)
        {
           
        }

    }


}