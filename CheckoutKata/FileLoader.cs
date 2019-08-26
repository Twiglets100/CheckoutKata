using System.Collections.Generic;

namespace CheckoutKata
{
    public class FileLoader : IStockLoader
    {
        public List<Item> LoadStock(string uri)
        {
            return new List<Item>();
        }
    }
}