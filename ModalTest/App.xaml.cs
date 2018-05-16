using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ModalTest
{
	public partial class App : Application
	{
		LoginPage _loginPage = new LoginPage();


		public App()
		{
			InitializeComponent();

			MainPage = new MainPage();

			AuthService.PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e) =>
			{
				if (e.PropertyName == "CurrentUser")
					UpdateLoginPageVisiblity();
			};


			MainPage.Appearing += (object sender, EventArgs e) =>
			{
				if (AuthService.CurrentUser == null)
					UpdateLoginPageVisiblity();

			};
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

		void UpdateLoginPageVisiblity()
		{
			if (AuthService.CurrentUser == null && !MainPage.Navigation.ModalStack.Contains(_loginPage))
				MainPage.Navigation.PushModalAsync(_loginPage);
			else if (AuthService.CurrentUser != null && MainPage.Navigation.ModalStack.Contains(_loginPage))
				MainPage.Navigation.PopModalAsync();
		}

	}
}
