using System;

namespace AldiAccountOverview.Core
{
	public class Promotion
	{
		public string Name {
			get;
			private set;
		}

		public DateTime ServiceEnds {
			get;
			private set;
		}

		public string RemainingCredit {
			get;
			private set;
		}
			
		public Promotion(string name, DateTime serviceEnds, string remainingCredit)
		{
			this.Name = name;
			this.ServiceEnds = serviceEnds;
			this.RemainingCredit = remainingCredit;
		}
	}
}

