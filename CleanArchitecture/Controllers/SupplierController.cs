using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CleanArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }


        /// <summary>
        /// Return a Supplier by code;
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet("{code}")]
        public IActionResult GetByCode(int code)
        {
            try
            {
                var supplier = _supplierService.GetByCode(code);

                if (supplier == null)
                {
                    return NotFound($"Supplier code {code} not found");
                }

                return Ok(supplier);
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
        public IActionResult GetAll()
        {
            try
            {
                var suppliers = _supplierService.GetAll();

                if (suppliers == null)
                {
                    return NotFound("Suplliers not found");
                }

                return Ok(suppliers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Create Supplier
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] SupplierDTO supplierDto)
        {
            try
            {
                var supplier = _supplierService.Create(supplierDto);

                return CreatedAtAction(
                    nameof(GetByCode),
                    new { code = supplier.Code },
                    supplier
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="code"></param>
        /// <param name="supplierDto"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(int code, [FromBody] SupplierDTO supplierDto)
        {
            try
            {
                if (code != supplierDto.Code)
                    return BadRequest();

                _supplierService.Update(supplierDto);

                return Ok(supplierDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpDelete("{code}")]
        public IActionResult Delete(int code)
        {
            try
            {
                var supplier = _supplierService.GetByCode(code);
                _supplierService.Delete(supplier);

                return Ok(supplier);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}