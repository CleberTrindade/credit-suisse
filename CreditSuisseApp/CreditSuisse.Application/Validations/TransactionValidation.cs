using CreditSuisseApp.CreditSuisse.Core.Entities;
using System;

namespace CreditSuisseApp.CreditSuisse.Application.Validations
{
	public static class TransactionValidation
	{
		public static bool IsValid { get; set; }

		public static string Message { get; set; }

		public static void TradeValidation(string transaction) {

			var fields = transaction.Split(" ");

			if (fields.Length < 3)
			{
				IsValid = false;
				Message = "Transaction inválid.";
				return;
			}

			if (Convert.ToDouble(fields[0].ToString()) <= 0)
			{
				IsValid = false;
				Message = "Transaction amount must be greater than 0.";
				return;
			}

			if (!DateValidation(fields[2].ToString()))
			{
				IsValid = false;
				Message = "Next Payment Date inválid.";
				return;
			}

			IsValid = true;
		}

		private static bool DateValidation(string data)
		{
			try
			{
				DateTime.ParseExact(data, "MM/dd/yyyy", null);				
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
