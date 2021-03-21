using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class SoPlanForCreationDto
    {
       public int SoPlanId { get; set; }

        [Display(Name = "Extreme SO")]
        public string SoNumber { get; set; }

        [Display(Name = "SO Line")]
        public string SoLine { get; set; }

        public string Customer { get; set; }

        [Display(Name = "CustomerPo")]
        public string CustomerOrderNumber { get; set; }

        [Display(Name = "Customer PO Line")]
        public string customerPoLine { get; set; }
        public string Invoice { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "OrderDate")]
        public DateTime? OrderDateTime { get; set; }

        [Display(Name = "CustomerPn")]
        public string CustomerPn { get; set; }

        [Display(Name = "ExtremePn")]
        public string ExtremePn { get; set; }

        public string PartDescription { get; set; }
        public string WorkOrderNumber { get; set; }

        [Display(Name = "OrderQty")]
        public int OrderQty { get; set; }

        [Display(Name = "ShipQty")]
        public int? ShipQty { get; set; }

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

        public string SoOrderStatus { get; set; }

        public bool HotShipment { get; set; }

        public string Carrier { get; set; }

        public string TrackingInfo { get; set; }

        public string ShipToAddress { get; set; }

        public string Notes { get; set; }
    }
}