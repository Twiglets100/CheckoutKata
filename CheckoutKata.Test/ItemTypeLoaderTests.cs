using System.Collections.Generic;
using System.IO;
using System.Linq;
using CheckoutKata.Interfaces;
using NUnit.Framework;

namespace CheckoutKata.Test
{
    public class ItemTypeLoaderTests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        private static List<IStockLoader> Loaders()
        {
            return new List<IStockLoader>{new FileLoader()};
        }

        [TestCaseSource(nameof(Loaders))]
        public void GivenUri_ReturnStockList(IStockLoader stockLoader)
        {
            var uri = "../../../../CheckoutKata/StockList.json";

            var stock = stockLoader.LoadStock(uri);
            
            Assert.True(stock.Any());
        }

        [TestCaseSource(nameof(Loaders))]
        public void GivenInvalidUri_ThrowArgumentException(IStockLoader stockLoader)
        {
            var uri = "invalidFile.txt";

            Assert.Throws<FileNotFoundException>(() => stockLoader.LoadStock(uri));
        }
    }
}