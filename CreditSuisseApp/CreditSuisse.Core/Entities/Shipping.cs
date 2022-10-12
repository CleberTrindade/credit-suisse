using System;
using System.Collections.Generic;

namespace CreditSuisseApp.CreditSuisse.Core.Entities
{
	public class Shipping
	{
		public DateTime ReferenceDate { get; set; }
		public int NumberTrades { get; set; }
		public List<string> Transactions { get; set; }

		public Shipping() { }

		public Shipping(DateTime referenceDate, int numberTrades, List<string> transactions)
		{
			ReferenceDate = referenceDate;
			NumberTrades = numberTrades;
			Transactions = transactions;
		}
	}
}
