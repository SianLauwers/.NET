using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Pattern_Better
{
    //Contact customer when order is shipped
    public class Order
    {
        IContact medium;
        public Order(IContact medium)
        { 
       this.medium = medium;
        }
        public string ContactCustomer(int customerId, string message)
        {
            return medium.Contact(customerId,message);
        }

    }
}
