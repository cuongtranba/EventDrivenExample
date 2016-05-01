
using System;
using System.Collections.Generic;

namespace EventDrivenExample
{
    public interface IProductService: IObservable<Product>
    {
        void SellProduct(Product product);
    }

    public class ProductService:IProductService
    {
        private List<IObserver<Product>> observers;

        public ProductService()
        {
            observers = new List<IObserver<Product>>();
        }

        public void SellProduct(Product product)
        {
            Console.WriteLine($"sell product {product.ProductName}");
            foreach (var observer in observers)
            {
                observer.OnNext(product);
            }
        }

        public IDisposable Subscribe(IObserver<Product> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }
        private class Unsubscriber : IDisposable
        {
            private List<IObserver<Product>> _observers;
            private IObserver<Product> _observer;

            public Unsubscriber(List<IObserver<Product>> observers, IObserver<Product> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
    }
}
