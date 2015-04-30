using System;
using System.Threading.Tasks;
using System.Threading;

namespace AldiAccountOverview.Core
{
	public interface ILoginService
	{
		Task<bool> Login(string username, string password, CancellationToken token);
		bool Logout();

		event EventHandler LoginStarted;
		event LoginEndedDelegate LoginEnded;
	}

	public delegate void LoginEndedDelegate(bool success);
}

