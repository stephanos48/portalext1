using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class SoPlan
    {
        public int SoPlanId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Order Date")]
        public DateTime? OrderDateTime { get; set; }

        public string Customer { get; set; }

        [Required]
        [Display(Name = "Customer PO")]
        public string CustomerOrderNo { get; set; }

        [Display(Name = "Customer PO Line")]
        public string CustomerOrderLine { get; set; }

        [Display(Name = "MLS SO")]
        public string SoNumber { get; set; }

        [Display(Name = "MLS WO")]
        public string WoNumber { get; set; }

        [Display(Name = "Customer PN")]
        public string CustomerPn { get; set; }

        [Display(Name = "Extreme PN")]
        public string ExtremePn { get; set; }

        public string PartDescription { get; set; }

        [Display(Name = "Order Qty")]
        public int OrderQty { get; set; }

        [Display(Name = "Ship Qty")]
        public int? ShipQty { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? RequestedDateTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PromiseDateTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ShipDateTime { get; set; }

        [Display(Name = "Status")]
        public string ShipPlanStatus { get; set; }

        [Display(Name = "HOT")]
        public string HotShipment { get; set; }

        public string Carrier { get; set; }

        public string TrackingInfo { get; set; }

        public string ShipToAddress { get; set; }

        public string Notes { get; set; }

        public string InvNo { get; set; }
    }
}