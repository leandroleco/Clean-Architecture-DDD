using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Infra.Data.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {

        private ApplicationDbContext _supplierContext;

        public SupplierRepository(ApplicationDbContext context)
        {
            _supplierContext = context;
        }

        public Supplier Create(Supplier supplier)
        {
            _supplierContext.Add(supplier);
            _supplierContext.SaveChanges();

            return supplier;
        }

        /// <summary>
        /// Get All Suppliers
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<Supplier> GetAll()
        {
            var supplier = _supplierContext.Suppliers;

            return supplier;
        }

        /// <summary>
        /// Return product by Code
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Product</returns>
        public Supplier GetByCode(int code)
        {
            var supplier = _supplierContext.Suppliers.FirstOrDefault(s => s.Code.Equals(code));

            return supplier;
        }

        /// <summary>
        /// Delete Supplier
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        public bool Delete(Supplier supplier)
        {
            _supplierContext.Remove(supplier);
            _supplierContext.SaveChanges();

            return true;
        }

        /// <summary>
        /// Update supplier
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        public bool Update(Supplier supplier)
        {
            _supplierContext.Update(supplier);
            _supplierContext.SaveChanges();

            return true;
        }
    }
}
