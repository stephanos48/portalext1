using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class SoPlanForReturnDto
    {
       public int SoPlanId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "OrderDate")]
        public DateTime? OrderDateTime { get; set; }

        public string Customer { get; set; }

        [Display(Name = "CustomerPo")]
        public string CustomerOrderNo { get; set; }

        [Display(Name = "Customer PO Line")]
        public string CustomerOrderLine { get; set; }

        [Display(Name = "Extreme SO")]
        public string SoNumber { get; set; }

        public string WoNumber { get; set; }


        [Display(Name = "CustomerPn")]
        public string CustomerPn { get; set; }

        [Display(Name = "ExtremePn")]
        public string ExtremePn { get; set; }

        public string PartDescription { get; set; }


        [Display(Name = "OrderQty")]
        public int OrderQty { get; set; }

        [Display(Name = "ShipQty")]
        public int? ShipQty { get; set; }

        public string InvNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? RequestedDateTime { get; set; }

        [Display(Name = "PromiseDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PromiseDateTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "ShipDate")]
        public DateTime? ShipDateTime { get; set; }

        public string ShipPlanStatus { get; set; }

        public string HotShipment { get; set; }

        public string Carrier { get; set; }

        public string TrackingInfo { get; set; }

        public string ShipToAddress { get; set; }

        public string Notes { get; set; }

    }
}