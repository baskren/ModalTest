using System;

using Xamarin.Forms;

namespace ModalTest
{
	public class LoginPage : ContentPage
	{
		Button _loginButton = new Button
		{
			Text = "LOGIN",
			BackgroundColor = Color.Blue,
			TextColor = Color.White,
			CornerRadius = 4,
			VerticalOptions = LayoutOptions.Center
		};

		Entry _userName = new Entry
		{
			Placeholder = "Enter User Name"
		};

		public LoginPage()
		{
			BackgroundColor = Color.DarkGray;

			Content = new StackLayout
			{
				Padding = 20,
				VerticalOptions = LayoutOptions.Center,
				Children =
				{
					_userName,
					_loginButton
				}
			};

			_userName.Completed += (object sender, EventArgs e) => _loginButton.SendClicked();

			_loginButton.Clicked += (object sender, EventArgs e) =>
			{
				AuthService.CurrentUser = _userName.Text;
			};
		}
	}
}

