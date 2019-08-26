using System.Collections.Generic;

namespace CheckoutKata
{
    public interface IStockLoader
    {
        List<Item> LoadStock(string uri);
    }
}