using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Quote
    {

        public int QuoteId { get; set; }
        public DateTime QuoteDate { get; set; } = DateTime.Now;
        public string QuotedBy { get; set; }
        
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<QuoteDetail> QuoteDetails { get; set; }

    }
}