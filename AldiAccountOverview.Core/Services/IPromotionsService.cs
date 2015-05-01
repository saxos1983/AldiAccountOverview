using System;
using System.Collections.Generic;

namespace AldiAccountOverview.Core
{
	public interface IPromotionsService
	{
		IList<Promotion> RemainingPromotions ();
	}
}

