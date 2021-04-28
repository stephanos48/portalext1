using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Authorize]
    public class SupplierController : BaseApiController
    {
        
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SupplierController(IUnitOfWork unitOfWork, IMapper mapper )
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("getSuppliers")]
        public async Task<IActionResult> GetSuppliers()
        {

            var quotes = await _unitOfWork.ExtremeRepository.GetSuppliersAsync();

            var quotesToReturn = _mapper.Map<IEnumerable<SupplierForReturnDto>>(quotes);

            return Ok();

        }

        [HttpGet("{id}", Name = "getSupplier")]
        public async Task<IActionResult> GetSupplier(int id)
        {
            var quoteFromRepo = await _unitOfWork.ExtremeRepository.GetSupplier(id);

            var quoteToReturn = _mapper.Map<SupplierForReturnDto>(quoteFromRepo);

            return Ok(quoteToReturn);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupplier(int id, SupplierForUpdateDto supplierForUpdateDto)
        {
            var quoteFromRepo = await _unitOfWork.ExtremeRepository.GetSupplier(id);

            _mapper.Map(supplierForUpdateDto, quoteFromRepo);

            if (await _unitOfWork.ExtremeRepository.SaveAll())
                return NoContent();

            throw new Exception($"Updating PoPlan {id} failed on save");    
        }

        [HttpPost("createSupplier")]
        public async Task<ActionResult> CreateSupplier([FromBody]SupplierForCreationDto supplierForCreationDto)
        {
            if (ModelState.IsValid)
            {
                var supplierToCreate = _mapper.Map<Supplier>(supplierForCreationDto);
                _unitOfWork.ExtremeRepository.Add(supplierToCreate);

                if (await _unitOfWork.ExtremeRepository.SaveChangesAsync())
                {
                var supplierToReturn = _mapper.Map<SupplierForReturnDto>(supplierToCreate);
                return CreatedAtRoute("GetSupplier", 
                        new { controller = "Supplier", id = supplierToCreate.SupplierId }, supplierToReturn);
                }
                else
                {
                    return BadRequest("Failed to save changes to the database.");
                }   
            }

            return BadRequest(ModelState);

        }

        [HttpDelete("delete-supplier/{supplierId}")]
        public async Task<ActionResult> Supplier(int supplierId)
        {
            var supplier = await _unitOfWork.ExtremeRepository.GetSupplier(supplierId);

            if (supplier == null) return NotFound();

            _unitOfWork.ExtremeRepository.DeleteSupplier(supplier);

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest("Failed to delete the PO");
        }

    }
}