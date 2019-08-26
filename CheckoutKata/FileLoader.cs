using System.Collections.Generic;
using System.IO;
using CheckoutKata.Interfaces;
using CheckoutKata.Models;
using Newtonsoft.Json;

namespace CheckoutKata
{
    public class FileLoader : IStockLoader
    {
        public List<Item> LoadStock(string uri)
        {
            List<Item> items;
            
            using (StreamReader r = new StreamReader(uri))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<Item>>(json);
            }

            return items;
        }
    }
}