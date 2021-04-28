using System;

namespace API.DTOs
{
    public class QuoteForCreationDto
    {
        public int QuoteId { get; set; }
        public DateTime QuoteDate { get; set; }
        public string QuotedBy { get; set; }
        
        public int SupplierId { get; set; }
    }
}