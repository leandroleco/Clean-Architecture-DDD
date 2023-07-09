using CleanArchitecture.Application.Dtos;
using System.Collections.Generic;

namespace CleanArchitecture.Application.Interfaces
{
    public interface ISupplierService
    {
        IEnumerable<SupplierDTO> GetAll();

        SupplierDTO GetByCode(int code);

        SupplierDTO Create(SupplierDTO supplierDto);

        bool Update(SupplierDTO supplierDto);

        bool Delete(SupplierDTO supplierDto);
    }
}
