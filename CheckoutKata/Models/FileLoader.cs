using System.Collections.Generic;
using System.IO;
using CheckoutKata.Interfaces;
using Newtonsoft.Json;

namespace CheckoutKata.Models
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