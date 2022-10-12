using CreditSuisseApp.CreditSuisse.Core.Interfaces;

namespace CreditSuisseApp.CreditSuisse.Core.Entities.Categories
{
	public class TradeCategoryExpired : ICategory
	{
		public string getCategory(Trade trade)
		{
			return ((trade.ReferenceDate.Subtract(trade.NextPaymentDate)).Days > 30) ? "EXPIRED" : "";
		}
	}
}
