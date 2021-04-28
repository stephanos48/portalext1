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
    public class QuoteDetailController : BaseApiController
    {
        
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public QuoteDetailController(IUnitOfWork unitOfWork, IMapper mapper )
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        [HttpGet("getQuoteDetails")]
        public async Task<IActionResult> GetQuoteDetails()
        {

            var quotes = await _unitOfWork.ExtremeRepository.GetQuoteDetailsAsync();

            var quotesToReturn = _mapper.Map<IEnumerable<QuoteDetailForReturnDto>>(quotes);

            return Ok();

        }

        [HttpGet("{id}", Name = "getQuoteDetail")]
        public async Task<IActionResult> GetQuoteDetail(int id)
        {
            var quoteFromRepo = await _unitOfWork.ExtremeRepository.GetQuoteDetail(id);

            var quoteToReturn = _mapper.Map<QuoteDetailForReturnDto>(quoteFromRepo);

            return Ok(quoteToReturn);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuoteDetail(int id, QuoteDetailForUpdateDto quoteDetailForUpdateDto)
        {
            var quoteFromRepo = await _unitOfWork.ExtremeRepository.GetQuoteDetail(id);

            _mapper.Map(quoteDetailForUpdateDto, quoteFromRepo);

            if (await _unitOfWork.ExtremeRepository.SaveAll())
                return NoContent();

            throw new Exception($"Updating PoPlan {id} failed on save");    
        }

        [HttpPost("createQuoteDetail")]
        public async Task<ActionResult> CreateQuoteDetail([FromBody]QuoteDetailForCreationDto quoteDetailForCreationDto)
        {
            if (ModelState.IsValid)
            {
                var quoteToCreate = _mapper.Map<QuoteDetail>(quoteDetailForCreationDto);
                _unitOfWork.ExtremeRepository.Add(quoteToCreate);

                if (await _unitOfWork.ExtremeRepository.SaveChangesAsync())
                {
                var quoteToReturn = _mapper.Map<QuoteDetailForReturnDto>(quoteToCreate);
                return CreatedAtRoute("GetQuoteDetail", 
                        new { controller = "QuoteDetail", id = quoteToCreate.QuoteDetailId }, quoteToReturn);
                }
                else
                {
                    return BadRequest("Failed to save changes to the database.");
                }   
            }

            return BadRequest(ModelState);

        }

        [HttpDelete("delete-quoteDetail/{quoteDetailId}")]
        public async Task<ActionResult> DeleteQuoteDetail(int quoteDetailId)
        {
            var quoteDetail = await _unitOfWork.ExtremeRepository.GetQuoteDetail(quoteDetailId);

            if (quoteDetail == null) return NotFound();

            _unitOfWork.ExtremeRepository.DeleteQuoteDetail(quoteDetail);

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest("Failed to delete the Quote");
        }

    }
}