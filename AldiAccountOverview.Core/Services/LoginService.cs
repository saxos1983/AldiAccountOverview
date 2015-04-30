using System;
using System.Threading.Tasks;
using System.Threading;

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

		public async Task<bool> Login (string username, string password, CancellationToken token)
		{
			//this.LoginStarted (this, EventArgs.Empty);
			await Task.Delay(8000, token);
			//this.LoginEnded (true);

			return true;
		}

		public bool Logout ()
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

