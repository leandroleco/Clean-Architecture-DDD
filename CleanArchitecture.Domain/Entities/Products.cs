using System;

namespace CleanArchitecture.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public string Description { get; private set; }

        // Ativo ou Inativo
        public bool Status { get; private set; }

        public DateTime ManufacturedDate { get; private set; }

        public DateTime ValidityDate { get; private set; }

        public int CodeSupplier { get; set; }
        public Supplier Supplier { get; set; }

        public Product(int code,
            string description,
            bool status,
            DateTime manufacturedDate,
            DateTime ValidityDate)
        {
            this.Code = code;
            this.Description = description;
            this.Status = status;
            this.ManufacturedDate = manufacturedDate;
            this.ValidityDate = ValidityDate;
        }
    }
}