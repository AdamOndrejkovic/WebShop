namespace WebShop.Core
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public override bool Equals(object? obj)
        {
            var product = obj as Product;
            if (product == null)
            {
                return false;
            }
            
            return Id == product.Id && Name == product.Name;
        }
    }
}