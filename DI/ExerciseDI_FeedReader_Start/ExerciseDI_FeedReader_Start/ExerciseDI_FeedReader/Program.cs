using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Xml;

namespace ExerciseDI_FeedReader
{
    internal class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            RegisterServices();

            FeedService feedService1 = new FeedService(_serviceProvider.GetServices<IFeedReader>().ElementAt(0));
            Console.WriteLine(feedService1.GetFeed());
            FeedService feedService2 = new FeedService(_serviceProvider.GetServices<IFeedReader>().ElementAt(1));
            Console.WriteLine(feedService2.GetFeed());
            FeedService feedService3 = new FeedService(_serviceProvider.GetServices<IFeedReader>().ElementAt(2));
            Console.WriteLine(feedService3.GetFeed());

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
                Console.WriteLine(Type.GetType(service.FirstChild.InnerText));
                Console.WriteLine(Type.GetType(service.LastChild.InnerText));
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
