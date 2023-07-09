using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _productContext;
        public ProductRepository(ApplicationDbContext context)
        {
            _productContext = context;
        }

        /// <summary>
        /// Find by Parameters 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="search">In Description</param>
        /// <returns></returns>
        public IEnumerable<Product> Find(int page, int limit, string search)
        {
            IEnumerable<Product> productsList = _productContext.Products.Where(i => i.Status.Equals(true));

            if (search is not null)
            {
                productsList = productsList
                        .Where(p => p.Description.ToLower().Contains(search.ToLower()))
                        .Where(p => p.Status.Equals(true));
            }

            productsList = productsList.Skip((page - 1) * limit).Take(limit);

            return productsList;
        }

        /// <summary>
        /// Return product by Code
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Product</returns>
        public Product GetByCode(int code)
        {
            var product = _productContext.Products.AsNoTracking()
                .FirstOrDefault(x => x.Code == code && x.Status.Equals(true));

            return product;
        }

        /// <summary>
        /// Create a Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public Product Create(Product product)
        {
            _productContext.Add(product);
            _productContext.SaveChanges();

            return product;
        }

        /// <summary>
        /// Disable Status Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool Delete(Product product)
        {
            _productContext.Update(product);
            _productContext.SaveChanges();

            return true;
        }

        /// <summary>
        /// Update product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool Update(Product product)
        {
            _productContext.Update(product);
            _productContext.SaveChanges();

            return true;
        }

    }
}
