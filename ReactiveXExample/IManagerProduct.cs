using System;

namespace ReactiveXExample
{
    public interface IManagerProduct
    {
        void ReCalculateProduct(int numberSell,int productId);
    }

    public class ManagerProduct:IManagerProduct
    {
        public void ReCalculateProduct(int numberSell, int productId)
        {
            Console.WriteLine($"sell {numberSell} recalculate");
        }
    }
}
