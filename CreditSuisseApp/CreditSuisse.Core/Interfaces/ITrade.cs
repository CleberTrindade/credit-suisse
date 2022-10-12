using System;

namespace CreditSuisseApp.CreditSuisse.Core.Interfaces
{
	public interface ITrade
	{
		double Value { get; }
		string ClientSector { get; }
		DateTime NextPaymentDate { get; }
	}
}
