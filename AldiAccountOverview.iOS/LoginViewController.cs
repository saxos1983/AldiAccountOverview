
using System;
using System.Linq;
using System.Collections.Generic;

using MonoTouch.Dialog;

using Foundation;
using UIKit;
using AldiAccountOverview.Core;
using MonoTouch.Dialog;
using System.Threading.Tasks;
using CoreGraphics;
using System.Threading;

namespace AldiAccountOverview.iOS
{
	public partial class LoginViewController : DialogViewController
	{
		EntryElement username, password;
		bool saveCredentials;
		BooleanElement remeberMeBooleanElement;
		UpdateableStringElement statusElement;

		CancellationTokenSource cts;

		ICredentialsStore credentialsStore;
		ILoginService loginService;

		public LoginViewController (ICredentialsStore credentialsStore, ILoginService loginService) : base (UITableViewStyle.Grouped, null)
		{
			this.credentialsStore = credentialsStore;
			this.loginService = loginService;

			cts = new CancellationTokenSource ();

			this.Title = "Login";

			Root = new RootElement (this.Title) {
				new Section("Credentials")
				{
					(username = new EntryElement("Username", "Who are you?", this.credentialsStore.Username)),
					(password = new EntryElement("Password", "", this.credentialsStore.Password, true)),
				}, new Section() {
					(remeberMeBooleanElement = new BooleanElement("Remember me", this.credentialsStore.ShouldRememberCredentials)),
					new StringElement("Login", Login),
					(statusElement = new UpdateableStringElement("Status: ", "Ready")),
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

		private async void Login()
		{
			statusElement.UpdateValue("Login Started");
			LoadingOverlay loadingOverlay = new LoadingOverlay (UIScreen.MainScreen.Bounds, "Logging in...", () => cts.Cancel(), "Cancel");
			this.View.Add (loadingOverlay);

			// If you are not awaiting the login task and use continue with, you need to use BeginInvokeOnMainThread
			// because you are most probably executing the continuation from a background thread and the UI will not update.
			// NOTE: If you pass TaskScheduler.FromCurrentSynchronizationContext() in the continuation, then the sync context
			// of the UI thread will be used and BeginInvokeOnMainThread will not be needed anymore.

//			this.loginService.Login (this.credentialsStore.Username, this.credentialsStore.Password)
//				.ContinueWith(t => 
//					{
//						BeginInvokeOnMainThread(() => {
//							statusElement.UpdateValue("Login ended. Successful: " + t.Result);
//						});
//					}/*, TaskScheduler.FromCurrentSynchronizationContext()*/);

			// Here we are awaiting the login task. InvokeOnMainThread is not required because when an awaited task 
			// completes the method continues on the calling thread (UI Thread).

			//bool result = await this.loginService.Login (this.credentialsStore.Username, this.credentialsStore.Password, cts.Token);
			bool result = false;
			var loginTask = this.loginService.Login (this.credentialsStore.Username, this.credentialsStore.Password, cts.Token);

			try{
				result = await loginTask;
			} catch(TaskCanceledException e) {
				statusElement.UpdateValue("Task Cancelled. Successful: " + result);
			} finally{
				loadingOverlay.Hide ();
				cts = new CancellationTokenSource ();
			}

			if (result) {
				statusElement.UpdateValue("Login ended. Successful: " + result);
				SaveCredentialsIfRequested ();
				NavigationController.PushViewController (new RemainingPromotionsController (), true);
			}

			Console.WriteLine ("Exiting Login Method.");
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			NavigationItem.SetBackButton("Back");

			// I am not using the event based mechanism for the login anymore.
			// Commented code just for the learning reference.

//			this.loginService.LoginStarted += (sender, e) => { 
//				statusElement.UpdateValue("Login Started");
//			};
//			this.loginService.LoginEnded += (bool success) => 
//			{
//				statusElement.UpdateValue("Login ended. Successful: " + success);
//				if(success)
//				{
//					SaveCredentialsIfRequested ();
//					NavigationController.PushViewController (new RemainingPromotionsController (), false);
//				}
//			};
		}

		void SaveCredentialsIfRequested ()
		{
			if (this.credentialsStore.ShouldRememberCredentials) {
				this.credentialsStore.Username = username.Value;
				this.credentialsStore.Password = password.Value;
			}
		}
	}
}
