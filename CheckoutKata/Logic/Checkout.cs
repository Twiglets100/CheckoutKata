using System;
using System.Collections.Generic;
using System.Linq;
using CheckoutKata.Interfaces;
using CheckoutKata.Models;

namespace CheckoutKata.Logic
{
    public class Checkout: ICheckout
    {
        private readonly List<Item> _itemTypes;
        private readonly List<string> _items = new List<string>();
        
        public Checkout(IStockLoader fileLoader)
        {
            _itemTypes = fileLoader.LoadStock("../../../../CheckoutKata/StockList.json");
        }

        public void Scan(string item)
        {
            if (!_itemTypes.Exists(itemType => itemType.Name == item))
            {
                throw new ArgumentOutOfRangeException(item);
            }
            _items.Add(item);
        }

        public int GetTotalPrice()
        {
            var totalPrice = 0;

            if (_items.Where(item => item == "A").ToList().Count >= 3)
            {
                totalPrice += 130;
            }

            if (_items.Where(item => item == "A").ToList().Count < 3)
            {
                _items.ForEach(item => { totalPrice += _itemTypes.FirstOrDefault(itemType => itemType.Name == item).Price; });
            }
            else
            {
                totalPrice += _items.Where(item => item == "A").ToList().Count % 3 *
                              _itemTypes.FirstOrDefault(itemType => itemType.Name == "A").Price;
            }
            
            return totalPrice;
        }
    }
}