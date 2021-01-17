using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class PoPlan
    {
        public int PoPlanId { get; set; }

        [Display(Name = "Extreme PO")]
        public string PoNumber { get; set; }

        [Display(Name = "PO Line")]
        public string PoLine { get; set; }

        public string Supplier { get; set; }

        [Display(Name = "CustomerPo")]
        public string CustomerOrderNumber { get; set; }

        [Display(Name = "SoNo")]
        public string SoNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "OrderDate")]
        public DateTime? OrderDateTime { get; set; }

        [Display(Name = "CustomerPn")]
        public string CustomerPn { get; set; }

        [Display(Name = "ExtremePn")]
        public string ExtremePn { get; set; }

        public string PartDescription { get; set; }

        [Display(Name = "OrderQty")]
        public int OrderQty { get; set; }

        [Display(Name = "ReceivedQty")]
        public int? ReceivedQty { get; set; }

        public string ContainerId { get; set; }

        public string ContainerExt { get; set; }

        public string FreightFowarder { get; set; }

        public string Destination { get; set; }

        public string AMS { get; set; }

        public string BOL { get; set; }

        public string Pallet { get; set; }

        public string Invoice { get; set; }

        public string ArrivalWk { get; set; }

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

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "EtaDate")]
        public DateTime? EtaDateTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ReceiptDateTime { get; set; }

        public string PoOrderStatus { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PoSentDateTime { get; set; }

        public string PoSentBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PoConfirmedDateTime { get; set; }

        public string PoConfirmedBy { get; set; }

        public string Notes { get; set; }

    }
}