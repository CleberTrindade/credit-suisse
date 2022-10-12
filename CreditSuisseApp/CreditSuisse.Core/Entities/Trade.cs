using CreditSuisseApp.CreditSuisse.Core.Entities.Categories;
using CreditSuisseApp.CreditSuisse.Core.Interfaces;
using System;

namespace CreditSuisseApp.CreditSuisse.Core.Entities
{
	public class Trade : ITrade
	{
		public DateTime ReferenceDate { get; private set; }
		public int NumberTrades { get; private set; }
		public double Value { get; private set; }
		public string ClientSector { get; private set; }
		public DateTime NextPaymentDate { get; private set; }

		public Trade() { }
		public Trade(
			DateTime _referenceDate,
			int numberTrades,
			double _value,
			string _clientSector,
			DateTime _nextPaymentDate)
		{
			ReferenceDate = _referenceDate;
			NumberTrades = numberTrades;
			Value = _value;
			ClientSector = _clientSector;
			NextPaymentDate = _nextPaymentDate;
			
		}

		public string getCategory()
		{
			Category category = new Category();
			return category.getCategory(this);
		}
	}
}
