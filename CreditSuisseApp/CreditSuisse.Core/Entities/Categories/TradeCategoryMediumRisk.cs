using CreditSuisseApp.CreditSuisse.Core.Interfaces;

namespace CreditSuisseApp.CreditSuisse.Core.Entities.Categories
{
	public class TradeCategoryMediumRisk : ICategory
	{
		public string getCategory(Trade trade)
		{
			return (trade.Value > 1000000 && trade.ClientSector.Equals("Public")) ? "MEDIUMRISK" : "";
		}
	}
}