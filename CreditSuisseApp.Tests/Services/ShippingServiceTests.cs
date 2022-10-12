using CreditSuisseApp.CreditSuisse.Application.Service;
using CreditSuisseApp.CreditSuisse.Core.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace CreditSuisseApp.Tests.Services
{
	public class ShippingServiceTests
	{
		private ShippingService shippingService;

		public ShippingServiceTests()
		{
			shippingService = new ShippingService();
		}

		[Fact]
		public void ProcessShipping_valid()
		{
			var result = shippingService.ProcessShipping(getTransactions_valid());
			Assert.True(result.Count == 4);
		}

		[Fact]
		public void ProcessShipping_invalid_numberTrades()
		{
			var result = shippingService.ProcessShipping(getShipping_numberTrades_invalid());
			Assert.Equal("Number of trades inválid.", result[0]);
		}

		[Fact]
		public void ProcessShipping_invalid_nextPaymentDate()
		{
			var result = shippingService.ProcessShipping(getShipping_nextPaymentDate_invalid());
			Assert.Equal("Next Payment Date inválid.", result[0]);
		}

		[Fact]
		public void ProcessShipping_invalid_transaction()
		{
			var result = shippingService.ProcessShipping(getShipping_transaction_invalid());
			Assert.Equal("Transaction inválid.", result[0]);
		}

		[Fact]
		public void ProcessShipping_invalid_transaction_amount()
		{
			var result = shippingService.ProcessShipping(getShipping_transaction_amount_invalid());
			Assert.Equal("Transaction amount must be greater than 0.", result[0]);
		}

		private static Shipping getTransactions_valid()
		{
			Shipping shipping = new Shipping();

			shipping.ReferenceDate = new DateTime(2020, 11, 12);
			shipping.NumberTrades = 4;

			List<string> transacoes = new List<string>();
			transacoes.Add("2000000 Private 12/29/2025");
			transacoes.Add("400000 Public 07/01/2020");
			transacoes.Add("5000000 Public 01/02/2024");
			transacoes.Add("3000000 Public 10/26/2023");

			shipping.Transactions = transacoes;
			return shipping;
		}

		private static Shipping getShipping_numberTrades_invalid()
		{
			Shipping shipping = new Shipping();

			shipping.ReferenceDate = new DateTime(2020, 11, 12);
			shipping.NumberTrades = 0;

			List<string> transacoes = new List<string>();
			transacoes.Add("2000000 Private 00/29/2025");

			shipping.Transactions = transacoes;
			return shipping;
		}

		private static Shipping getShipping_nextPaymentDate_invalid()
		{
			Shipping shipping = new Shipping();

			shipping.ReferenceDate = new DateTime(2020, 11, 12);
			shipping.NumberTrades = 4;

			List<string> transacoes = new List<string>();
			transacoes.Add("2000000 Private 00/29/2025");

			shipping.Transactions = transacoes;
			return shipping;
		}
		private static Shipping getShipping_transaction_invalid()
		{
			Shipping shipping = new Shipping();

			shipping.ReferenceDate = new DateTime(2020, 11, 12);
			shipping.NumberTrades = 4;

			List<string> transacoes = new List<string>();
			transacoes.Add("2000000 Private");

			shipping.Transactions = transacoes;
			return shipping;
		}

		private static Shipping getShipping_transaction_amount_invalid()
		{
			Shipping shipping = new Shipping();

			shipping.ReferenceDate = new DateTime(2020, 11, 12);
			shipping.NumberTrades = 4;

			List<string> transacoes = new List<string>();
			transacoes.Add("0 Private 00/29/2025");

			shipping.Transactions = transacoes;
			return shipping;
		}
	}
}
