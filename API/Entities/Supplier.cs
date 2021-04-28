using System.Collections.Generic;

namespace API.Entities
{
    public class Supplier
    {
        
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public virtual ICollection<Quote> Quotes { get; set; }

    }
}