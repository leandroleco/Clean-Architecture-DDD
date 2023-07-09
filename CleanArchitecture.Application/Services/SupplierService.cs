using AutoMapper;
using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace CleanArchitecture.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private IValidator<Supplier> _supplierValidator;
        private ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public SupplierService(ISupplierRepository supplierRepository, IMapper mapper, IValidator<Supplier> supplierValidator)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
            _supplierValidator = supplierValidator;
        }

        public IEnumerable<SupplierDTO> GetAll()
        {
            var supplier = _supplierRepository.GetAll();
            return _mapper.Map<IEnumerable<SupplierDTO>>(supplier);
        }

        public SupplierDTO GetByCode(int code)
        {
            var supplier = _supplierRepository.GetByCode(code);
            return _mapper.Map<SupplierDTO>(supplier);
        }

        public SupplierDTO Create(SupplierDTO supplierDto)
        {
            try
            {
                var supplier = _mapper.Map<Supplier>(supplierDto);
                _supplierValidator.ValidateAndThrow(supplier);

                var insertedProduct = _supplierRepository.Create(supplier);
                return _mapper.Map<SupplierDTO>(insertedProduct);
            }
            catch (ValidationException vx)
            {
                throw vx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(SupplierDTO supplierDto)
        {
            var supplier = _mapper.Map<Supplier>(supplierDto);
            var result = _supplierValidator.Validate(supplier);
            if (result.IsValid)
            {
                return _supplierRepository.Update(supplier);
            }
            else
            {
                throw new Exception(result.Errors.ToString());
            }
        }

        public bool Delete(SupplierDTO supplierDto)
        {
            var supplier = _mapper.Map<Supplier>(supplierDto);
            return _supplierRepository.Delete(supplier);
        }
    }
}
