using CreditSuisseApp.CreditSuisse.Core.Interfaces;

namespace CreditSuisseApp.CreditSuisse.Core.Entities.Categories
{
	public class TradeCategoryHighRisk : ICategory
	{
		public string getCategory(Trade trade)
		{
			return (trade.Value > 1000000 && trade.ClientSector.Equals("Private")) ? "HIGHRISK" : "";
		}
	}
}
