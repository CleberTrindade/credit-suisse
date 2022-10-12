using CreditSuisseApp.CreditSuisse.Application.Validations;
using CreditSuisseApp.CreditSuisse.Core.Entities;
using CreditSuisseApp.CreditSuisse.Core.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace CreditSuisseApp.CreditSuisse.Application.Service
{
	public class ShippingService : IShippingService
	{
		public List<string> ProcessShipping(Shipping shipping)
		{
			List<string> resultShipping = new List<string>();

			if (shipping.NumberTrades <= 0)
			{
				resultShipping.Add("Number of trades inválid.");
				return resultShipping;
			}

			foreach (var transacao in shipping.Transactions)
			{
				TransactionValidation.TradeValidation(transacao);

				if (TransactionValidation.IsValid)
				{
					Trade trade = getTrade(shipping.ReferenceDate, shipping.NumberTrades, transacao);
					resultShipping.Add(trade.getCategory());

				}
				else
				{
					resultShipping.Clear();
					resultShipping.Add(TransactionValidation.Message);
					return resultShipping;
				}
			}
			return resultShipping;
		}

		private Trade getTrade(DateTime referenceDate, int numberTrades, string transactions)
		{
			var fields = transactions.Split(" ");

			return new Trade(referenceDate,
							 numberTrades,
							 Convert.ToDouble(fields[0].ToString()),
							 fields[1].ToString().Trim(),
							 DateTime.ParseExact(fields[2].ToString(), "MM/dd/yyyy", null)
							 //,fields[3].ToString().Equals("1") ? true : false
							 );
		}


	}
}
