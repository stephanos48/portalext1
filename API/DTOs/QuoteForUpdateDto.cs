using System;

namespace API.DTOs
{
    public class QuoteForUpdateDto
    {
        public int QuoteId { get; set; }
        public DateTime QuoteDate { get; set; }
        public string QuotedBy { get; set; }
        
        public int SupplierId { get; set; }
    }
}