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
    public class QuoteController : BaseApiController
    {
        
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public QuoteController(IUnitOfWork unitOfWork, IMapper mapper )
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        [HttpGet("getQuotes")]
        public async Task<IActionResult> GetQuotes()
        {

            var quotes = await _unitOfWork.ExtremeRepository.GetQuotesAsync();

            var quotesToReturn = _mapper.Map<IEnumerable<QuoteForReturnDto>>(quotes);

            return Ok();

        }

        [HttpGet("{id}", Name = "getQuote")]
        public async Task<IActionResult> GetQuote(int id)
        {
            var quoteFromRepo = await _unitOfWork.ExtremeRepository.GetQuote(id);

            var quoteToReturn = _mapper.Map<QuoteForReturnDto>(quoteFromRepo);

            return Ok(quoteToReturn);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuote(int id, QuoteForUpdateDto quoteForUpdateDto)
        {
            var quoteFromRepo = await _unitOfWork.ExtremeRepository.GetQuote(id);

            _mapper.Map(quoteForUpdateDto, quoteFromRepo);

            if (await _unitOfWork.ExtremeRepository.SaveAll())
                return NoContent();

            throw new Exception($"Updating PoPlan {id} failed on save");    
        }

        [HttpPost("createQuote")]
        public async Task<ActionResult> CreateQuote([FromBody]QuoteForCreationDto quoteForCreationDto)
        {
            if (ModelState.IsValid)
            {
                var quoteToCreate = _mapper.Map<Quote>(quoteForCreationDto);
                _unitOfWork.ExtremeRepository.Add(quoteToCreate);

                if (await _unitOfWork.ExtremeRepository.SaveChangesAsync())
                {
                var quoteToReturn = _mapper.Map<QuoteForReturnDto>(quoteToCreate);
                return CreatedAtRoute("GetQuote", 
                        new { controller = "Quote", id = quoteToCreate.QuoteId }, quoteToReturn);
                }
                else
                {
                    return BadRequest("Failed to save changes to the database.");
                }   
            }

            return BadRequest(ModelState);

        }

        [HttpDelete("delete-quote/{quoteId}")]
        public async Task<ActionResult> DeleteQuote(int quoteId)
        {
            var quote = await _unitOfWork.ExtremeRepository.GetQuote(quoteId);

            if (quote == null) return NotFound();

            _unitOfWork.ExtremeRepository.DeleteQuote(quote);

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest("Failed to delete the Quote");
        }

    }
}