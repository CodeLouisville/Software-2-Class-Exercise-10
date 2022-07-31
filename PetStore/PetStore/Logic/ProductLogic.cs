using PetStore.Data;
using PetStore.Logic;
using PetStore.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore
{
    internal class ProductLogic : IProductLogic
    {
        private readonly IProductRepository _productRepo;

        public ProductLogic(IProductRepository productRepository)
        {
            _productRepo = productRepository;
        }

        public void AddProduct(Product product)
        {
            var validator = new ProductValidator();
            if (validator.Validate(product).IsValid)
            {
                _productRepo.AddProduct(product);
            }
        }

        public List<Product> GetAllProducts()
        {
            return _productRepo.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return _productRepo.GetProductById(id);
        }
    }
}
