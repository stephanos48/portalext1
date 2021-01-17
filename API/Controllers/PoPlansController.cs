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
    public class PoPlansController : BaseApiController
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PoPlansController(IUnitOfWork unitOfWork, IMapper mapper )
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        [HttpGet("getPoPlans")]
        public async Task<IActionResult> GetPoPlans()
        {

            var poplans = await _unitOfWork.ExtremeRepository.GetPoPlansAsync();

            var poplansToReturn = _mapper.Map<IEnumerable<PoPlanForReturnDto>>(poplans);

            return Ok(poplansToReturn.OrderBy(m=>m.EtaDateTime));

        }
      
        [HttpGet("{id}", Name = "getPoPlan")]
        public async Task<IActionResult> GetPoPlan(int id)
        {
            var poplanFromRepo = await _unitOfWork.ExtremeRepository.GetPoPlan(id);

            var poplanToReturn = _mapper.Map<PoPlanForReturnDto>(poplanFromRepo);

            return Ok(poplanToReturn);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePoPlan(int id, PoPlanForUpdateDto poplanForUpdateDto)
        {
            var poplanFromRepo = await _unitOfWork.ExtremeRepository.GetPoPlan(id);

            _mapper.Map(poplanForUpdateDto, poplanFromRepo);

            if (await _unitOfWork.ExtremeRepository.SaveAll())
                return NoContent();

            throw new Exception($"Updating PoPlan {id} failed on save");    
        }

        [HttpPost("createPoPlan")]
        public async Task<ActionResult> CreatePoPlan([FromBody]PoPlanForCreationDto poplanForCreationDto)
        {
            if (ModelState.IsValid)
            {
                var poplanToCreate = _mapper.Map<PoPlan>(poplanForCreationDto);
                _unitOfWork.ExtremeRepository.Add(poplanToCreate);

                if (await _unitOfWork.ExtremeRepository.SaveChangesAsync())
                {
                var poplanToReturn = _mapper.Map<PoPlanForReturnDto>(poplanToCreate);
                return CreatedAtRoute("GetPoPlan", 
                        new { controller = "PoPlan", id = poplanToCreate.PoPlanId }, poplanToReturn);
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