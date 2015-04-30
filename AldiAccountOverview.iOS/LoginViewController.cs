﻿
using System;
using System.Linq;
using System.Collections.Generic;

using MonoTouch.Dialog;

using Foundation;
using UIKit;
using AldiAccountOverview.Core;

namespace AldiAccountOverview.iOS
{
	public partial class LoginViewController : DialogViewController
	{
		EntryElement username, password;
		bool saveCredentials;
		BooleanElement remeberMeBooleanElement;
		StringElement statusElement;

		ICredentialsStore credentialsStore;
		ILoginService loginService;

		public LoginViewController (ICredentialsStore credentialsStore, ILoginService loginService) : base (UITableViewStyle.Grouped, null)
		{
			this.credentialsStore = credentialsStore;
			this.loginService = loginService;

			this.Title = "Login";

			Root = new RootElement (this.Title) {
				new Section("Credentials")
				{
					(username = new EntryElement("Username", "Who are you?", this.credentialsStore.Username)),
					(password = new EntryElement("Password", "", this.credentialsStore.Password, true)),
				}, new Section() {
					(remeberMeBooleanElement = new BooleanElement("Remember me", this.credentialsStore.ShouldRememberCredentials)),
					new StringElement("Login", Login),
					(statusElement = new StringElement("Status: ", "Ready")),
				}
			};

			remeberMeBooleanElement.ValueChanged += (sender, e) => {
				this.credentialsStore.ShouldRememberCredentials = remeberMeBooleanElement.Value;
				if(!this.credentialsStore.ShouldRememberCredentials)
				{
					this.credentialsStore.ClearCredentials();
				}
			};
		}

		private void Login()
		{
			statusElement.Value = "Login Started";
			this.loginService.Login (this.credentialsStore.Username, this.credentialsStore.Password);
			statusElement.Value = "Login ended";
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			NavigationItem.SetBackButton("Zurück");
			this.loginService.LoginStarted += (sender, e) => { 
				Console.WriteLine ("Login Started");
			};
			this.loginService.LoginEnded += (bool success) => 
			{
				if(success)
				{
					if (this.credentialsStore.ShouldRememberCredentials) {
						this.credentialsStore.Username = username.Value;
						this.credentialsStore.Password = password.Value;
					}
					NavigationController.PushViewController(new RemainingPromotionsController(), false);
				}
			};
		}
	}
}
