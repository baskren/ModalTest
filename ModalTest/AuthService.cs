using System;
using System.ComponentModel;
namespace ModalTest
{
	public static class AuthService
	{
		static string _currentUser;
		public static string CurrentUser
		{
			get => _currentUser;
			set
			{
				if (_currentUser != value)
				{
					_currentUser = value;
					PropertyChanged?.Invoke(_currentUser, new PropertyChangedEventArgs("CurrentUser"));
				}
			}
		}

		public static event PropertyChangedEventHandler PropertyChanged;


	}
}
