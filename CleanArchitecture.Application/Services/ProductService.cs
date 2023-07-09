using AutoMapper;
using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class ProductService : IProductService
    {
        private IValidator<Product> _productValidator;
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper, IValidator<Product> productValidator)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productValidator = productValidator;
        }

        public IEnumerable<ProductDTO> Find(int page, int limit, string search)
        {
            var products = _productRepository.Find(page, limit, search);
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public ProductDTO GetByCode(int code)
        {
            var products = _productRepository.GetByCode(code);
            return _mapper.Map<ProductDTO>(products);
        }

        public ProductDTO Create(ProductDTO productDto)
        {
            try
            {
                var product = _mapper.Map<Product>(productDto);
                _productValidator.ValidateAndThrow(product);

                var insertedProduct = _productRepository.Create(product);
                return _mapper.Map<ProductDTO>(insertedProduct);
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

        public bool Update(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var result = _productValidator.Validate(product);
            if (result.IsValid)
            {
                return _productRepository.Update(product);
            }
            else
            {
                throw new Exception(result.Errors.ToString());
            }
        }

        public bool Delete(ProductDTO productDto)
        {
            productDto.Status = false;

            var product = _mapper.Map<Product>(productDto);
            var result = _productValidator.Validate(product);
            if (result.IsValid)
            {
                return _productRepository.Delete(product);
            }
            else
            {
                throw new Exception(result.Errors.ToString());
            }
        }
    }
}
