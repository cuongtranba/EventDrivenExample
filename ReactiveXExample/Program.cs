using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveXExample
{
    class Program
    {
        static void Main(string[] args)
        {
            IManagerProduct managerProduct=new ManagerProduct();
            IProductService productService=new ProductService();

            var productSell=new Product(1,"iphone",4);

            var hq2=new Subject<Action>();

            hq2.Subscribe(action =>
            {
                action.Invoke();
                managerProduct.ReCalculateProduct(productSell.Number, productSell.Id);
            });

            hq2.OnNext(() => productService.SellProduct(productSell));
        }
    }
}
