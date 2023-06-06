using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace DI_Pattern_Better
{
    internal class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            RegisterServices();

            Order order = new Order(_serviceProvider.GetService<IContact>());
            order.ContactCustomer(1, "Finally shipped");

            Console.ReadKey();
        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            //register interfaces using factory that returns implementation
            services.AddSingleton<IContact, EmailSender>();
            _serviceProvider = services.BuildServiceProvider(true);
        }
    }
}
