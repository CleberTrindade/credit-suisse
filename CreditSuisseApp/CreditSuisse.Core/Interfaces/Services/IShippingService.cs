using CreditSuisseApp.CreditSuisse.Core.Entities;
using System.Collections.Generic;

namespace CreditSuisseApp.CreditSuisse.Core.Interfaces.Services
{
	public interface IShippingService
	{
		List<string> ProcessShipping(Shipping shipping);
	}
}
