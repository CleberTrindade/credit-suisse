using CreditSuisseApp.CreditSuisse.Core.Entities;

namespace CreditSuisseApp.CreditSuisse.Core.Interfaces
{
	public interface ICategory
	{
		string getCategory(Trade trade);
	}
}
