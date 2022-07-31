namespace PetStore.Data
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        Product GetProductById(int productId);

        public List<Product> GetAllProducts();
    }
}