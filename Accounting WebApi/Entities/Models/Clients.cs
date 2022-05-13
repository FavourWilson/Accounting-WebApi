using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting_WebApi.Entities.Models
{

    [Table("Clients")]
    public class Clients
    {
        [Column("ClientId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "ClientName is Needed")]
        public string? clientName { get; set; }
        [Required(ErrorMessage = "Phone is Needed")]
        public string? phone { get; set; }
        public string? businessName { get; set; }
    }
}
