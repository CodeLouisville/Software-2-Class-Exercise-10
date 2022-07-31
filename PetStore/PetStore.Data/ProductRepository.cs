using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _dbContext;

        public ProductRepository()
        {
            _dbContext = new ProductContext();
        }

        public void AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        public Product GetProductById(int productId)
        {
            return _dbContext.Products.SingleOrDefault(x => x.ProductId == productId);
        }

        public List<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }
    }
}
