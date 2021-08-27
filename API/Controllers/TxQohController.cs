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
    public class TxQohController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TxQohController(IUnitOfWork unitOfWork, IMapper mapper )
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("getTxQohs")]
        public async Task<IActionResult> GetTxQohs()
        {

            var txqohs = await _unitOfWork.ExtremeRepository.GetTxQohsAsync();

            var txqohsToReturn = _mapper.Map<IEnumerable<TxQohForReturnDto>>(txqohs);

            return Ok(txqohsToReturn);
        }

        [HttpGet("getActualQohs")]
        public async Task<IActionResult> GetActualQohs()
        {
            //List<TxQoh> txhold = new List<TxQoh>();
            //List<PoPlan> pohold = new List<PoPlan>();
            //List<SoPlan> sohold = new List<SoPlan>();

            var txqohs = await _unitOfWork.ExtremeRepository.GetTxQohsAsync();
            var poplans = await _unitOfWork.ExtremeRepository.GetPoPlansAsync();
            var soplans = await _unitOfWork.ExtremeRepository.GetSoPlansAsync();

            var startDate = DateTime.Parse("1/1/2020");
            var query = from tx in txqohs
                        join r in poplans.Where(a=>a.ReceiptDateTime >= startDate).Where(y=>y.PoOrderStatus == "Closed/Received") on tx.Pn equals r.CustomerPn into g
                        join ru in soplans.Where(a=>a.ShipDateTime >= startDate).Where(y=>y.ShipPlanStatus == "Closed/Shipped") on tx.Pn equals ru.CustomerPn into gr
                        orderby tx.Pn                        
                        select new
                        {
                            Id = tx.TxQohId,
                            Pn = tx.Pn,
                            ExtremePn = tx.ExtremePn,
                            Customer = tx.Customer,
                            Jan1Qoh = tx.Qoh,
                            Jan1Rec = (int?)g.Select(x => x.ReceivedQty).DefaultIfEmpty(0).Sum(),
                            Jan1Ship = (int?)gr.Select(x => x.ShipQty).DefaultIfEmpty(0).Sum(),
                            Qoh = tx.Qoh + (int?)g.Select(x => x.ReceivedQty).DefaultIfEmpty(0).Sum() - (int?)gr.Select(x => x.ShipQty).DefaultIfEmpty(0).Sum(),
                            Location = tx.Location,
                            Notes = tx.Notes
                        };

                List<TxQohForReturnDto> txhold = new List<TxQohForReturnDto>();
                foreach(var qoh in query.ToList())
                {
                    txhold.Add(new TxQohForReturnDto
                    {

                        TxQohId = qoh.Id,
                        Pn = qoh.Pn,
                        ExtremePn = qoh.ExtremePn,
                        Customer = qoh.Customer,
                        Jan1Qoh = qoh.Jan1Qoh,
                        Jan1Rec = qoh.Jan1Rec,
                        Jan1Ship = qoh.Jan1Ship,
                        Qoh = qoh.Qoh,
                        Location = qoh.Location,
                        Notes = qoh.Notes

                    });
                }

            return Ok(txhold);
        }
      
        [HttpGet("{id}", Name = "getTxQoh")]
        public async Task<IActionResult> GetTxQoh(int id)
        {
            var txqohFromRepo = await _unitOfWork.ExtremeRepository.GetTxQoh(id);

            var txqohToReturn = _mapper.Map<TxQohForReturnDto>(txqohFromRepo);

            return Ok(txqohToReturn);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTxQoh(int id, TxQohForUpdateDto txqohForUpdateDto)
        {
            var txqohFromRepo = await _unitOfWork.ExtremeRepository.GetTxQoh(id);

            _mapper.Map(txqohForUpdateDto, txqohFromRepo);

            if (await _unitOfWork.ExtremeRepository.SaveAll())
                return NoContent();

            throw new Exception($"Updating TxQoh {id} failed on save");    
        }

        [HttpPost("createTxQoh")]
        public async Task<ActionResult> CreateTxQoh([FromBody]TxQohForCreationDto txqohForCreationDto)
        {
            if (ModelState.IsValid)
            {
                var txqohToCreate = _mapper.Map<TxQoh>(txqohForCreationDto);
                _unitOfWork.ExtremeRepository.Add(txqohToCreate);

                if (await _unitOfWork.ExtremeRepository.SaveChangesAsync())
                {
                var txqohToReturn = _mapper.Map<TxQohForReturnDto>(txqohToCreate);
                return CreatedAtRoute("GetTxQoh", 
                        new { controller = "TxQoh", id = txqohToCreate.TxQohId }, txqohToReturn);
                }
                else
                {
                    return BadRequest("Failed to save changes to the database.");
                }   
            }

            return BadRequest(ModelState);

            /*if (await _repo.SaveAll()) {
                var customerToRetun = _mapper.Map<CustomerForReturnDto>(customer);
                return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustomerId }, customerToRetun);
            }*/  
        }

        /*
        [HttpPost("editCustomer/{customerId}")]
        public async Task<IActionResult> Edit(int customerId, CustomerEditDto customerEditDto)
        {
            if (customerId != customerEditDto.CustomerId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var customerToEdit = _mapper.Map<Customer>(customerEditDto);
                    _repo.Add(customerToEdit);
                    await _repo.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Customer(customerEditDto.CustomerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok(customerEditDto);
            }
            return Ok();
        }
        */

        /*
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var value = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);
            return Ok(value);
        }
        */

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePn(int id)
        {
            var txqohToDelete = await _unitOfWork.ExtremeRepository.GetTxQoh(id);
            
            _unitOfWork.ExtremeRepository.DeleteTxQoh(txqohToDelete);

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest("Problem deleting the message");
        }
    }
}