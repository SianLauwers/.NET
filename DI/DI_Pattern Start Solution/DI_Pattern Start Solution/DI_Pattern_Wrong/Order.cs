using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Pattern_Wrong
{
    //Contact customer when order is shipped
    public class Order
    {
        public string ContactCustomer(int customerId, string message)
        {
            TelSender telSender = new TelSender();
            return telSender.Contact(customerId, message);
        }
    }
}
