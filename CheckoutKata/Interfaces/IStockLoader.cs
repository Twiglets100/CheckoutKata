using System.Collections.Generic;

namespace CheckoutKata.Interfaces
{
    public interface IStockLoader
    {
        List<Item> LoadStock(string uri);
    }
}