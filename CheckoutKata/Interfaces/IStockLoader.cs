using System.Collections.Generic;
using CheckoutKata.Models;

namespace CheckoutKata.Interfaces
{
    public interface IStockLoader
    {
        List<Item> LoadStock(string uri);
    }
}