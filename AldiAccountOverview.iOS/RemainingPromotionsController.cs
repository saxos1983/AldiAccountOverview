
using System;

using Foundation;
using UIKit;

namespace AldiAccountOverview.iOS
{
	public class RemainingPromotionsController : UITableViewController
	{
		public RemainingPromotionsController () : base (UITableViewStyle.Grouped)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.Title = "Remaining Promotions";

			// Register the TableView's data source
			string[] items = new string[] {"SMS 100 pcs", "National 1399mins"};
			TableView.Source = new RemainingPromotionsSource (items, this);
		}
	}
}

