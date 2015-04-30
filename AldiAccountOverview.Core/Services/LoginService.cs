using System;
using System.Threading.Tasks;

namespace AldiAccountOverview.Core
{
	public class LoginService : ILoginService
	{
		public LoginService ()
		{
		}

		#region ILoginService implementation

		public event EventHandler LoginStarted;

		public event LoginEndedDelegate LoginEnded;

		public bool Login (string username, string password)
		{
			this.LoginStarted (this, EventArgs.Empty);

			for(int i = 1; i < 1000000; i++)
			{
			}

			this.LoginEnded (true);
			return true;
		}

		public bool Logout ()
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

