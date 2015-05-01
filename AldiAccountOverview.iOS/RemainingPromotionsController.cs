
using System;

using Foundation;
using UIKit;
using AldiAccountOverview.Core;

namespace AldiAccountOverview.iOS
{
	public class RemainingPromotionsController : UITableViewController
	{
		private IPromotionsService promoService;

		public RemainingPromotionsController (IPromotionsService promoService) : base (UITableViewStyle.Grouped)
		{
			this.promoService = promoService;
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
			TableView.Source = new RemainingPromotionsSource (this.promoService.RemainingPromotions());
		}
	}
}

