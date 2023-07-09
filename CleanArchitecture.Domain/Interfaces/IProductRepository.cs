using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> Find(int page, int limit, string? search);

        Product GetByCode(int code);

        Product Create(Product product);

        bool Update(Product product);

        bool Delete(Product product);
    }
}
