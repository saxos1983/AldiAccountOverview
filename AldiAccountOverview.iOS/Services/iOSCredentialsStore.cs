using System;
using AldiAccountOverview.Core;
using Foundation;

namespace AldiAccountOverview.iOS
{
	public class iOSCredentialsStore : ICredentialsStore
	{
		private const string RememeberCredentialsKey  = "RememeberCredentialsKey";
		private const string UsernameKey  = "UsernameKey";
		private const string PasswordKey  = "PasswordKey";

		public iOSCredentialsStore ()
		{
		}

		#region ICredentialsStore implementation

		public void ClearCredentials ()
		{
			NSUserDefaults.StandardUserDefaults.SetString ("", UsernameKey);
			NSUserDefaults.StandardUserDefaults.SetString ("", PasswordKey);
		}

		public string Password {
			get {
				return NSUserDefaults.StandardUserDefaults.StringForKey (PasswordKey);	
			}
			set {
				NSUserDefaults.StandardUserDefaults.SetString (value, PasswordKey);
			}
		}

		public string Username {
			get {
				return NSUserDefaults.StandardUserDefaults.StringForKey (UsernameKey);
			}
			set {
				NSUserDefaults.StandardUserDefaults.SetString (value, UsernameKey);
			}
		}

		public bool ShouldRememberCredentials {
			get {
				return NSUserDefaults.StandardUserDefaults.BoolForKey (RememeberCredentialsKey);
			}
			set {
				NSUserDefaults.StandardUserDefaults.SetBool(value, RememeberCredentialsKey);
			}
		}

		#endregion
	}
}

