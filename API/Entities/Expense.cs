using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Expense
    {
        public int ExpenseId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "DateEntered")]
        public DateTime? EnterDateTime { get; set; }

        public string PaidVia { get; set; }

        public string AccountDetail { get; set; }

        public string Payee { get; set; }

        public string Employee { get; set; }

        public string ExpenseCategory { get; set; }

        public string ExpenseDetail { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "ExpenseDate")]
        public DateTime? ExpenseDateTime { get; set; }

        public string ExpenseDescription { get; set; }

        public decimal Cost { get; set; }

        public decimal Taxes { get; set; }

        public decimal Shipping { get; set; }

        public decimal TotalCost { get; set; }

        public string Notes { get; set; }

    }
}