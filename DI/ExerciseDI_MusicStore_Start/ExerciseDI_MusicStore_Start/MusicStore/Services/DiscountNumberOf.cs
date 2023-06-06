using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Services
{
    public class DiscountNumberOf : IDiscountService
    {
        public int GetDiscount(List<CartItem> items)
        {
            if (items.Count < 5)
            {
                return 0;
            }

            else if (items.Count < 10 )
            {
                return 5;
            }

            return 10;
        }
    }
}
