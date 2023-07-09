using CleanArchitecture.Domain.Entities;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> GetAll();

        Supplier GetByCode(int code);

        Supplier Create(Supplier supplier);

        bool Update(Supplier supplier);

        bool Delete(Supplier supplier);
    }
}