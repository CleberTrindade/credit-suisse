using CreditSuisseApp.CreditSuisse.Application.Service;
using CreditSuisseApp.CreditSuisse.Core.Entities;
using CreditSuisseApp.CreditSuisse.Core.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace CreditSuisseApp
{
	class Program
	{
		static void Main(string[] args)
		{
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var shippingCommand = serviceProvider.GetService<IShippingService>();

            var retorno = shippingCommand.ProcessShipping(getTransactions());

            System.Console.WriteLine("");
            System.Console.WriteLine("Result:");
            foreach (var item in retorno)
            {
                System.Console.WriteLine($"{item}");
            }

            Console.ReadKey();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IShippingService, ShippingService>();
        }

        private static Shipping getTransactions()
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
    }
}
