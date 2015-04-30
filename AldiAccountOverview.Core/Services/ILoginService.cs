using System;
using System.Threading.Tasks;

namespace AldiAccountOverview.Core
{
	public interface ILoginService
	{
		Task<bool> Login(string username, string password);
		bool Logout();

		event EventHandler LoginStarted;
		event LoginEndedDelegate LoginEnded;
	}

	public delegate void LoginEndedDelegate(bool success);
}

