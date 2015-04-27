using System;
using UIKit;

namespace AldiAccountOverview.iOS
{
	public static class NavigationHelpers
	{
		public static void SetBackButton(this UINavigationItem navItem, string text)
		{
			navItem.BackBarButtonItem = new UIBarButtonItem (text, UIBarButtonItemStyle.Plain, null);
		}
	}
}

