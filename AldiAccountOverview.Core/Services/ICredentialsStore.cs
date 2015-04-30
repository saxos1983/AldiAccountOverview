using System;

namespace AldiAccountOverview.Core
{
	public interface ICredentialsStore
	{
		string Password {
			get;
			set;
		}

		string Username {
			get;
			set;
		}

		bool ShouldRememberCredentials {
			get;
			set;
		}

		void ClearCredentials();
	}
}

