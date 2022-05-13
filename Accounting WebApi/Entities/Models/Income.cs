using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting_WebApi.Entities.Models
{ 
    [Table("Profits")]
    public class Income
    {
        [Column("ProfitId")]
        public Guid Id { get; set; }
    [Required(ErrorMessage = "Tile is Needed")]
    public string? Title { get; set; }
    [Required(ErrorMessage = "Cost is Needed")]
    public double? Cost  { get; set; }
    [Required(ErrorMessage = "Date is Needed")]
    public DateTime DateOfTransaction { get; set; }
        
    }
}
