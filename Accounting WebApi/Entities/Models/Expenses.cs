using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting_WebApi.Entities.Models
{
    [Table("Expenses")]
    public class Expenses
    {
        [Column("ExpensesId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage="Title is Required")]
        public string? title { get; set; }
        [Required(ErrorMessage ="Cost is Needed")]
        public double? cost { get; set; }
        [Required(ErrorMessage = "Date is Needed")]
        public DateTime dateOfTransaction { get; set; }
        [Required(ErrorMessage = "ClientName is Needed")]
        public string? clientName { get; set; }
    }
}
