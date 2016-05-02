namespace ReactiveXExample
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Number { get; set; }

        public Product(int id, string productName, int number)
        {
            this.Id = id;
            this.ProductName = productName;
            this.Number = number;
        }

        public Product()
        {
            
        }
        
    }
}