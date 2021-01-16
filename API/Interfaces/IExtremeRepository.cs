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
        Task<IEnumerable<TxQoh>> GetTxQohsAsync();
        Task<TxQoh> GetTxQoh(int id);

        Task<bool> SaveChangesAsync();
    }
}