using System;
using System.Collections.Generic;

namespace ReactiveXExample
{
    public interface IProductService
    {
        void SellProduct(Product product);
    }

    public class ProductService: IProductService
    {
        public void SellProduct(Product product)
        {
            Console.WriteLine($"sell product {product.ProductName}");
        }
    }
}
