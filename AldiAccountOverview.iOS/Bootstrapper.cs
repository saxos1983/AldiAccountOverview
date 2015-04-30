using AldiAccountOverview.Core;
using TinyIoC;

namespace AldiAccountOverview.iOS
{
	public class Bootstrapper
	{
		public static void Initialize ()
		{
			var container = TinyIoCContainer.Current;

			container.Register<ICredentialsStore, iOSCredentialsStore> ();
			container.Register<ILoginService, LoginService> ();
		}
	}
}

