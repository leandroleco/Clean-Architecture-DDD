using CleanArchitecture.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> Find(int page, int limit, string? search);

        ProductDTO GetByCode(int code);

        ProductDTO Create(ProductDTO productDto);

        bool Update(ProductDTO productDto);

        bool Delete(ProductDTO productDto);
    }
}
