using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Xml;

namespace DI_Pattern_Best
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            RegisterServices();

            //We get the correct instance from the RegisterServices method
            Order order = new Order(_serviceProvider.GetServices<IContact>().ElementAt(0));
            order.ContactCustomer(1, "Your shipment will be delivered tomorrow at 4pm.");
            Console.ReadKey();

            //Disposing is done automatically by the ServiceProvider
            DisposeServices();
        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            //We get the correct instances from the xml file
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;

            // Load the document and set the root element.  
            XmlDocument doc = new XmlDocument();
            doc.Load("config\\di_configuration.xml");
            XmlNode root = doc.DocumentElement;

            XmlNodeList nodeList = root.SelectNodes("implementation");
            foreach (XmlNode service in nodeList)
            {
                //firstchild = interface
                //lastchild = instance
                services.AddSingleton(Type.GetType(service.FirstChild.InnerText), Type.GetType(service.LastChild.InnerText));
            }
            _serviceProvider = services.BuildServiceProvider(true);
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}
