using System;
using MonoTouch.Dialog;
using UIKit;

namespace AldiAccountOverview.iOS
{
	class UpdateableStringElement : StringElement
	{
		public UpdateableStringElement(string name): base (name)
		{
		}

		public UpdateableStringElement(string name, string value): base (name, value)
		{
		}

		UILabel DetailText = null;

		public void UpdateValue(string text)
		{
			Value = text;
			if (DetailText != null)
				DetailText.Text = text;
		}

		public override UITableViewCell GetCell(UITableView tv)
		{
			var cell = base.GetCell(tv);
			DetailText = cell.DetailTextLabel;
			return cell;
		}
	}
}

