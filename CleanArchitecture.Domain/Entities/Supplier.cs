using System.Collections.Generic;

namespace CleanArchitecture.Domain.Entities
{
    public class Supplier : BaseEntity
    {
        public string Description { get; private set; }

        public string Cnpj { get; private set; }

        public Supplier(int code, string description, string cnpj)
        {
            this.Code = code;
            this.Description = description;
            this.Cnpj = cnpj;
        }

        public ICollection<Product> Products { get; set; }
    }
}
