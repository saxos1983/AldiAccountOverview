
using System;

using Foundation;
using UIKit;

namespace AldiAccountOverview.iOS
{
	public class RemainingPromotionsSource : UITableViewSource
	{


		string[] tableItems;
		string cellIdentifier = "TableCell";
		UIViewController parent;

		public RemainingPromotionsSource (string[] items, UIViewController parent)
		{
			tableItems = items;
			this.parent = parent;
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return tableItems.Length;
		}
		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
			// if there are no cells to reuse, create a new one
			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);
			cell.TextLabel.Text = tableItems[indexPath.Row];
			cell.BackgroundColor = UIColor.Cyan;
			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			tableView.DeselectRow(indexPath, false);
			AppDelegate.navCtrl.PopToRootViewController(false);
			AppDelegate.navCtrl.PushViewController (new TestDataViewController (), false);
		}
	}
}

