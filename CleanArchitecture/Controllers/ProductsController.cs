using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace CleanArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        /// <summary>
        /// Recuperar um registro por código;
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet("{code}")]
        public IActionResult GetByCode(int code)
        {
            try
            {
                var product = _productService.GetByCode(code);

                if (product == null)
                {
                    return NotFound($"Product code {code} not found");
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Trazer registros Filtrando a partir de parâmetros e paginando a resposta
        /// </summary>
        /// <returns>IEnumerable<Products></returns>
        [HttpGet]
        public IActionResult GetAll(int page = 0, int limit = 10, string search = null)
        {
            try
            {
                var products = _productService.Find(page, limit, search);

                if (products == null)
                {
                    return NotFound("Products not found");
                }

                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Criar validação para o campo data de fabricação 
        /// que não poderá ser maior ou igual a data de validade.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] ProductDTO productDTO)
        {
            try
            {
                var product = _productService.Create(productDTO);

                return CreatedAtAction(
                    nameof(GetByCode),
                    new { code = product.Code },
                    product
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Criar validação para o campo data de fabricação 
        /// que não poderá ser maior ou igual a data de validade.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="productDTO"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(int code, [FromBody] ProductDTO productDTO)
        {
            try
            {
                _productService.Update(productDTO);

                return Ok(productDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }    
        }

        /*
      Excluir
     A exclusão deverá ser lógica, atualizando o campo situação com o valor Inativo.
        */

        [HttpDelete("{code}")]
        public IActionResult Delete(int code)
        {
            try
            {
                var product = _productService.GetByCode(code);
                _productService.Delete(product);

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
       
    }
}
