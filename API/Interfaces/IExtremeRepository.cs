using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IExtremeRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<bool> SaveChangesAsync();


        Task<IEnumerable<TxQoh>> GetTxQohsAsync();
        Task<TxQoh> GetTxQoh(int id);

        Task<IEnumerable<PoPlan>> GetPoPlansAsync();
        Task<IEnumerable<PoPlan>> GetNotReceived();
        Task<IEnumerable<PoPlan>> GetTransit();
        Task<IEnumerable<PoPlan>> GetReceived();
        Task<PoPlan> GetPoPlan(int id);

        Task<IEnumerable<SoPlan>> GetSoPlansAsync();        
        Task<IEnumerable<SoPlan>> GetShipOuts();
        Task<SoPlan> GetSoPlan(int id);
    }
}