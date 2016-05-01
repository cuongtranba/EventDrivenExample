using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDrivenExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // when client sell product it will fire event to calculate product number in database 
            
            IProductService productService=new ProductService();
            IManagerProduct managerProduct=new ManagerProduct();
            var products=new List<Product>()
            {
                new Product(1,"iphone 4",4),
                new Product(2,"iphone 3",5),
                new Product(3,"iphone 2",6),
                new Product(4,"iphone 4",12),
                new Product(5,"iphone 2",8),
                new Product(6,"iphone 1",9),
            };


            productService.Subscribe(managerProduct);
            productService.SellProduct(products.Find(c => c.Id == 4));
            //var student=new Student()
            //{
            //    GpaScore = 80,
            //    Name = "Cuong"
            //};

            //var parent =new Parent()
            //{
            //    Name = "Hung"
            //};

            //student.NotifyToParent += parent.NotifyMe;
            //student.RecordGPAScore();
        }

    }

    public class Parent
    {
        public string Name { get; set; }
        
        public void NotifyMe(object sender, int e)
        {
            Console.WriteLine($"{Name} notified about the gpa {e}");
            Console.WriteLine(sender);
        }
    }

    public class Student
    {
        public event EventHandler<int> NotifyToParent;
        public string Name { get; set; }
        public int GpaScore { get; set; }

        public void RecordGPAScore()
        {
            if (NotifyToParent != null)
            {
                NotifyToParent.Invoke(this,GpaScore);
            }
        }
        
    }
}
