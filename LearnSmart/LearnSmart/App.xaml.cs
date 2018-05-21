using LearnSmart.Services.Navigation;
using LearnSmart.ViewModels.Base;
using Plugin.MediaManager.Forms;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace LearnSmart
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            InitNavigation();

            // Make sure it doesn't get stripped away by the linker
            var workaround = typeof(VideoView);
        }

        private Task InitNavigation()
        {
            var navigationService = Locator.Instance.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }


        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
