using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IExtremeRepository
    {

        //General Methods
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<bool> SaveChangesAsync();

        //TxQoh Methods
        Task<IEnumerable<TxQoh>> GetTxQohsAsync();
        Task<TxQoh> GetTxQoh(int id);
        void DeleteTxQoh(TxQoh txQoh);

        //PoPlan Methods
        Task<IEnumerable<PoPlan>> GetPoPlansAsync();
        Task<IEnumerable<PoPlan>> GetNotReceived();
        Task<IEnumerable<PoPlan>> GetTransit();
        Task<IEnumerable<PoPlan>> GetReceived();
        Task<PoPlan> GetPoPlan(int id);
        void DeletePoPlan(PoPlan poPLan);

        //SoPlan Methods
        Task<IEnumerable<SoPlan>> GetSoPlansAsync();
        Task<IEnumerable<SoPlan>> GetOpenSoPlansAsync();        
        Task<IEnumerable<SoPlan>> GetShipOuts();
        Task<IEnumerable<SoPlan>> GetSlotted();
        Task<SoPlan> GetSoPlan(int id);
        void DeleteSoPlan(SoPlan soPlan);

        //Quote Methods
        Task<IEnumerable<Quote>> GetQuotesAsync();        
        Task<Quote> GetQuote(int id);
        void DeleteQuote(Quote quote);

        //QuoteDetail Methods
        Task<IEnumerable<QuoteDetail>> GetQuoteDetailsAsync();        
        Task<QuoteDetail> GetQuoteDetail(int id);
        void DeleteQuoteDetail(QuoteDetail quoteDetail);

        //Supplier Methods
        Task<IEnumerable<Supplier>> GetSuppliersAsync();        
        Task<Supplier> GetSupplier(int id);
        void DeleteSupplier(Supplier supplier);
    }
}