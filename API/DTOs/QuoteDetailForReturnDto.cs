using System;

namespace API.DTOs
{
    public class QuoteDetailForReturnDto
    {
        public int QuoteDetailId { get; set; }
        public string Pn { get; set; }
        public decimal Weight { get; set; }
        public decimal Material { get; set; }
        public decimal Labor { get; set; }
        public decimal Freight { get; set; }
        public decimal Tariff { get; set; }
        public decimal TotalPrice { get; set; }
        public bool LatestQuote { get; set; }

        public int QuoteId { get; set; }
    }
}