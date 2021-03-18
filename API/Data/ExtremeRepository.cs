using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ExtremeRepository : IExtremeRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ExtremeRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<TxQoh>> GetTxQohsAsync()
        {
            var txqohs = await _context.TxQohs.ToListAsync();
            return txqohs;
        }

        public async Task<IEnumerable<TxQoh>> GetActualQohAsync()
        {

            var txqohs = await _context.TxQohs.ToListAsync();
            return txqohs;
            /*
            var startDate = DateTime.Parse("1/1/2021");
            var query = from tx in _context.TxQohs
                        join r in _context.PoPlans.Where(a=>a.ReceiptDateTime >= startDate).Where(y=>y.PoOrderStatus == 5) on tx.Pn equals r.CustomerPn into g
                        join r in _context.SoPlans.Where(a=>a.ShipDateTime >= startDate).Where(y=>y.ShipPlanStatus == 5) on tx.Pn equals r.CustomerPn into gr
                        orderby tx.Pn
                        select new
                        {
                            Id = tx.TxQohId,
                            Pn = tx.Pn,
                            Customer = tx.Customer,
                            Jan1Qoh = tx.Qoh,
                            Jan1Rec = (int?)g.Select(x => x.ReceivedQty).DefaultIfEmpty(0).Sum(),
                            Jan1Ship = (int?)gr.Select(x => x.ShipQty).DefaultIfEmpty(0).Sum(),
                            Qoh = tx.Qoh + (int?)g.Select(x => x.ReceivedQty).DefaultIfEmpty(0).Sum() - (int?)gr.Select(x => x.ShipQty).DefaultIfEmpty(0).Sum(),
                            Location = tx.Location,
                            Notes = tx.Notes
                        };

            //var txqohs = await _context.TxQohs.ToListAsync();
            return query;
            */
        }
 
        public async Task<TxQoh> GetTxQoh(int id)
        {
            var specificpn = await _context.TxQohs.FirstOrDefaultAsync(m => m.TxQohId == id);
            return specificpn;
        }

        public async Task<IEnumerable<PoPlan>> GetPoPlansAsync()
        {
            var poplans = await _context.PoPlans.ToListAsync();
            return poplans;
        }
 
        public async Task<PoPlan> GetPoPlan(int id)
        {
            var poplanspecific = await _context.PoPlans.FirstOrDefaultAsync(m => m.PoPlanId == id);
            return poplanspecific;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}