using System;

namespace DI_Pattern_Good
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order1 = new Order(new EmailSender());
            order1.ContactCustomer(1, "Your shipment will be delivered tomorrow at 4pm.");

            Order order2 = new Order(new TelSender());
            order2.ContactCustomer(1, "Your shipment will be delivered tomorrow at 4pm.");

            Console.ReadKey();
     
        }
    }
}
