using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Services
{
    public interface IDiscountService
    {
        int GetDiscount(List<CartItem> items);
    }
}
