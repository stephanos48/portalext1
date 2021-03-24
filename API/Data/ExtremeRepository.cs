using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        //TxQoh Methods

        public async Task<IEnumerable<TxQoh>> GetTxQohsAsync()
        {
            var txqohs = await _context.TxQohs.ToListAsync();
            return txqohs;
        }

        public async Task<TxQoh> GetTxQoh(int id)
        {
            var specificpn = await _context.TxQohs.FirstOrDefaultAsync(m => m.TxQohId == id);
            return specificpn;
        }

        //PoPlan Methods

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

        public async Task<IEnumerable<PoPlan>> GetNotReceived()
        {
            var poplans = await _context.PoPlans.Where(x=>x.PoOrderStatus != "Closed/Received").Where(y=>y.PoOrderStatus != "Transit").ToListAsync();
            return poplans;
        }

        public async Task<IEnumerable<PoPlan>> GetReceived()
        {
            var poplans = await _context.PoPlans.Where(x=>x.PoOrderStatus == "Closed/Received").ToListAsync();
            return poplans;
        }

        public async Task<IEnumerable<PoPlan>> GetTransit()
        {
            var poplans = await _context.PoPlans.Where(x=>x.PoOrderStatus == "Transit").ToListAsync();
            return poplans;
        }

        //SoPlan Methods

        public async Task<IEnumerable<SoPlan>> GetSoPlansAsync()
        {
            var soplans = await _context.SoPlans.ToListAsync();
            return soplans;
        }

        public async Task<SoPlan> GetSoPlan(int id)
        {
            var soplanspecific = await _context.SoPlans.FirstOrDefaultAsync(m => m.SoPlanId == id);
            return soplanspecific;
        }

        public async Task<IEnumerable<SoPlan>> GetShipOuts()
        {
            var soplans = await _context.SoPlans.Where(x=>x.ShipPlanStatus == "Closed/Shipped").ToListAsync();
            return soplans;
        }


    }
}