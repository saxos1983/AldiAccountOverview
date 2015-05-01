using System;
using System.Collections.Generic;

namespace AldiAccountOverview.Core
{
	public class PromotionService : IPromotionsService
	{
		#region IPromotionsService implementation

		public System.Collections.Generic.IList<Promotion> RemainingPromotions ()
		{
			return new List<Promotion> {
				new Promotion("SMS", new DateTime(2015, 5, 23), "349 pcs."),
				new Promotion("Mobile Minutes", new DateTime(2015, 6, 29), "1399.23 minutes")
			};
		}

		#endregion
	}
}

