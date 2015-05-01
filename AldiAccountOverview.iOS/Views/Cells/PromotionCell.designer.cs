// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace AldiAccountOverview.iOS
{
	[Register ("PromotionCell")]
	partial class PromotionCell
	{
		[Outlet]
		UIKit.UILabel RemainingCredit { get; set; }

		[Outlet]
		UIKit.UILabel ServiceEnds { get; set; }

		[Outlet]
		UIKit.UILabel ServiceName { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ServiceName != null) {
				ServiceName.Dispose ();
				ServiceName = null;
			}

			if (RemainingCredit != null) {
				RemainingCredit.Dispose ();
				RemainingCredit = null;
			}

			if (ServiceEnds != null) {
				ServiceEnds.Dispose ();
				ServiceEnds = null;
			}
		}
	}
}
