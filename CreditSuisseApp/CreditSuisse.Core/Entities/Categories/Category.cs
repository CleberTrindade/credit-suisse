using CreditSuisseApp.CreditSuisse.Core.Interfaces;
using System.Collections.Generic;

namespace CreditSuisseApp.CreditSuisse.Core.Entities.Categories
{
	public class Category : ICategory
	{
		private List<ICategory> tradeCategories = new List<ICategory>()
		{
			new TradeCategoryExpired(),
			new TradeCategoryMediumRisk(),
			new TradeCategoryHighRisk()
		};

		public string getCategory(Trade trade)
		{
			string category = "";
			foreach (var _category in tradeCategories)
			{
				if (category.Equals(""))
					category = _category.getCategory(trade);
			}
			return category;
		}
	}
}
