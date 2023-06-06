using System;

namespace DI_Pattern_Wrong
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order();
            order.ContactCustomer(1, "Your shipment will be delivered tomorrow at 4pm.");
            Console.ReadKey();
        }
    }
}
