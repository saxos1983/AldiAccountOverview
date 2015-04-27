
using System;
using System.Linq;
using System.Collections.Generic;

using MonoTouch.Dialog;

using Foundation;
using UIKit;

namespace AldiAccountOverview.iOS
{
	public partial class LoginViewController : DialogViewController
	{
		EntryElement username, password;
		bool saveCredentials;
		BooleanElement remeberMeBooleanElement;

		private const string RememeberCredentialsKey  = "RememeberCredentialsKey";
		private const string UsernameKey  = "UsernameKey";
		private const string PasswordKey  = "PasswordKey";



		public LoginViewController () : base (UITableViewStyle.Grouped, null)
		{
			this.Title = "Login";

			Root = new RootElement (this.Title) {
				new Section("Credentials")
				{
					(username = new EntryElement("Username", "Who are you?", GetLoadedUsername())),
					(password = new EntryElement("Password", "", GetLoadedPassword(), true)),
				}, new Section() {
					(remeberMeBooleanElement = new BooleanElement("Remember me", UserWantsToRememberCredentials())),
					new StringElement("Login", Login),
				}
			};

			remeberMeBooleanElement.ValueChanged += (sender, e) => {
				NSUserDefaults.StandardUserDefaults.SetBool(remeberMeBooleanElement.Value, RememeberCredentialsKey);
				if(!UserWantsToRememberCredentials())
				{
					ClearCredentials();
				}
			};
		}

		private void Login()
		{
			string loginData = string.Format ("Username: {0}, Password: {1}", username.Value, password.Value);
			if (UserWantsToRememberCredentials()) {
				SaveCredentials (username.Value, password.Value);
			}
			NavigationController.PushViewController(new RemainingPromotionsController(), false);
		}

		private string GetLoadedUsername()
		{
			return NSUserDefaults.StandardUserDefaults.StringForKey (UsernameKey);
		}

		private string GetLoadedPassword()
		{
			return NSUserDefaults.StandardUserDefaults.StringForKey (PasswordKey);
		}

		private bool UserWantsToRememberCredentials()
		{
			return NSUserDefaults.StandardUserDefaults.BoolForKey (RememeberCredentialsKey);
		}

		private void SaveCredentials(string username, string password)
		{
			NSUserDefaults.StandardUserDefaults.SetString (username, UsernameKey);
			NSUserDefaults.StandardUserDefaults.SetString (password, PasswordKey);
		}

		private void ClearCredentials()
		{
			NSUserDefaults.StandardUserDefaults.SetString ("", UsernameKey);
			NSUserDefaults.StandardUserDefaults.SetString ("", PasswordKey);
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			NavigationItem.SetBackButton("Zurück");
		}
	}
}
