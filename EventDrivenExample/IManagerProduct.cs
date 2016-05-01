using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDrivenExample
{
    public interface IManagerProduct: IObserver<Product>
    {
        void ReCalculateProduct(int numberSell,int productId);
    }

    public class ManagerProduct:IManagerProduct
    {
        public void ReCalculateProduct(int numberSell, int productId)
        {
            Console.WriteLine($"sell {numberSell}");
        }

        public void OnNext(Product value)
        {
            ReCalculateProduct(value.Number,value.Id);
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }
    }
}
