using CleanArchitecture.Domain.Entities;
using System;
using System.Text.Json.Serialization;

namespace CleanArchitecture.Application.Dtos
{
    public class ProductDTO
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime ManufacturedDate { get; set; }
        public DateTime ValidityDate { get; set; }

        public int CodeSupplier { get; set; }

        [JsonIgnore]
        public Supplier Supplier { get; set; }

    }
}
