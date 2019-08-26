using System.Collections.Generic;
using CheckoutKata.Interfaces;

namespace CheckoutKata.Models
{
    public class FileLoader : IStockLoader
    {
        public List<Item> LoadStock(string uri)
        {
            return new List<Item>();
        }
    }
}