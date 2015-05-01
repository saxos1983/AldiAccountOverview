
using System;

using Foundation;
using UIKit;
using System.Collections.Generic;
using AldiAccountOverview.Core;

namespace AldiAccountOverview.iOS
{
	public class RemainingPromotionsSource : UITableViewSource
	{


		IList<Promotion> promotions;

		public RemainingPromotionsSource (IList<Promotion> promotions)
		{
			this.promotions = promotions;
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return promotions.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var promotion = promotions [indexPath.Row];
			var cell = (PromotionCell)tableView.DequeueReusableCell (PromotionCell.Key);
			if (cell == null) {
				cell = PromotionCell.Create ();
			}
			cell.Model = promotion;

			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			tableView.DeselectRow(indexPath, false);
			AppDelegate.navCtrl.PopToRootViewController(false);
			AppDelegate.navCtrl.PushViewController (new TestDataViewController (), false);
		}

		public override nfloat GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return 72;
		}
	}
}

