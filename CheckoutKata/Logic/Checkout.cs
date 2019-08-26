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
        private string _items;
        
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
            _items = item;
        }

        public int GetTotalPrice()
        {
            return _itemTypes.FirstOrDefault(item => item.Name == _items).Price;
        }
    }
}