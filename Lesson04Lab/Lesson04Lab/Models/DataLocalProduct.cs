namespace Lesson04Lab.Models
{
    public class DataLocalProduct
    {
        public static List<Product> _products = new List<Product>()
        {
            new Product()
            {
                Id = 0,
                Name = "Quần áo trẻ em",
                Price = 500000,
            },
        };
        public static List<Product> GetProducts()
        {
            return _products;
        }
        public static Product? GetProductsById(int id)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);
            return product;
        }
    }
}
