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
    public class SoPlansController : BaseApiController
    {
        
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SoPlansController(IUnitOfWork unitOfWork, IMapper mapper )
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        [HttpGet("getSoPlans")]
        public async Task<IActionResult> GetSoPlans()
        {

            var soplans = await _unitOfWork.ExtremeRepository.GetSoPlansAsync();

            var soplansToReturn = _mapper.Map<IEnumerable<SoPlanForReturnDto>>(soplans);

            return Ok(soplansToReturn.OrderBy(m=>m.ShipDateTime));

        }
      
        [HttpGet("{id}", Name = "getSoPlan")]
        public async Task<IActionResult> GetSoPlan(int id)
        {
            var soplanFromRepo = await _unitOfWork.ExtremeRepository.GetSoPlan(id);

            var soplanToReturn = _mapper.Map<PoPlanForReturnDto>(soplanFromRepo);

            return Ok(soplanToReturn);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSoPlan(int id, SoPlanForUpdateDto soplanForUpdateDto)
        {
            var soplanFromRepo = await _unitOfWork.ExtremeRepository.GetSoPlan(id);

            _mapper.Map(soplanForUpdateDto, soplanFromRepo);

            if (await _unitOfWork.ExtremeRepository.SaveAll())
                return NoContent();

            throw new Exception($"Updating SoPlan {id} failed on save");    
        }

        [HttpPost("createSoPlan")]
        public async Task<ActionResult> CreateSoPlan([FromBody]SoPlanForCreationDto soplanForCreationDto)
        {
            if (ModelState.IsValid)
            {
                var soplanToCreate = _mapper.Map<SoPlan>(soplanForCreationDto);
                _unitOfWork.ExtremeRepository.Add(soplanToCreate);

                if (await _unitOfWork.ExtremeRepository.SaveChangesAsync())
                {
                var soplanToReturn = _mapper.Map<SoPlanForReturnDto>(soplanToCreate);
                return CreatedAtRoute("GetSoPlan", 
                        new { controller = "SoPlans", id = soplanToCreate.SoPlanId }, soplanToReturn);
                }
                else
                {
                    return BadRequest("Failed to save changes to the database.");
                }   
            }

            return BadRequest(ModelState);

        }

    }
}