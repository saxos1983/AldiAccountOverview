
using System;

using Foundation;
using UIKit;
using AldiAccountOverview.Core;

namespace AldiAccountOverview.iOS
{
	public partial class PromotionCell : UITableViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("PromotionCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("PromotionCell");

		public Promotion Model { get; set; }

		public PromotionCell (IntPtr handle) : base (handle)
		{	
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews ();
			this.ServiceName.Text = Model.Name;
			this.ServiceEnds.Text = Model.ServiceEnds.ToShortDateString();
			this.RemainingCredit.Text = Model.RemainingCredit;
		}

		public static PromotionCell Create ()
		{
			return (PromotionCell)Nib.Instantiate (null, null) [0];
		}
	}
}

