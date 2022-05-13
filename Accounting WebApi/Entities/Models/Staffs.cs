using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting_WebApi.Entities.Models
{
    [Table("Staffs")]
    public class Staffs
    {
        [Column("StaffId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Firstname is Needed")]
        public string? firstName { get; set; }
        [Required(ErrorMessage = "Middlename is Needed")]
        public string? middleName { get; set; }
        [Required(ErrorMessage = "Lastname is Needed")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Date is Needed")]
        public DateTime Dob { get; set; }
        [Required(ErrorMessage = "Position is Needed")]
        public string? Position { get; set; }
        public string? Pic { get; set; }
    }
}
