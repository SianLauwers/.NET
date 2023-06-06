using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Services
{
    public class DiscountTotalPrice : IDiscountService
    {
        public int GetDiscount(List<CartItem> items)
        {
            int sum = 0;
            foreach(var item in items)
            {
                 sum += item.Album.Price ;
            }

            if (sum < 25)
            {
                return 0;
            }

            else if (sum < 50)
            {
                return 5;
            }

            return 10;
        }

    }
}
