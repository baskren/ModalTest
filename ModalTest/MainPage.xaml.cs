using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ModalTest
{
	public partial class MainPage : ContentPage
	{

		Button _logoutButton = new Button
		{
			Text = "LOGOUT",
			BackgroundColor = Color.Blue,
			TextColor = Color.White,
			CornerRadius = 4,
			VerticalOptions = LayoutOptions.Center
		};

		Label _label = new Label
		{
			Text = "Main Page",
			HorizontalOptions = LayoutOptions.FillAndExpand,
			HorizontalTextAlignment = TextAlignment.Center,
			VerticalOptions = LayoutOptions.Center
		};

		public MainPage()
		{
			//InitializeComponent();

			Content = new StackLayout
			{
				Padding = 20,
				VerticalOptions = LayoutOptions.Center,
				Children =
				{
					_label,
					_logoutButton
				}
			};


			_logoutButton.Clicked += (object sender, EventArgs e) =>
			{
				AuthService.CurrentUser = null;
			};

		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			_label.Text = "Current User: " + AuthService.CurrentUser;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			_label.Text = " ";

		}

	}
}
