using CheckoutKata.Interfaces;

namespace CheckoutKata.Logic
{
    public class Checkout: ICheckout
    {
        public Checkout(IStockLoader fileLoader)
        {
        }

        public void Scan(string item)
        {
            
        }

        public int GetTotalPrice()
        {
            return 50;
        }
    }
}