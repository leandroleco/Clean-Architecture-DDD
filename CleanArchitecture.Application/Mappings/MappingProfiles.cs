using AutoMapper;
using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Supplier, SupplierDTO>().ReverseMap();
        }

    }
}
