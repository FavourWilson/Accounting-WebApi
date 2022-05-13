namespace Accounting_WebApi.Entities.DataTransferObjects.Delete
{
    public class StaffDeleteRepo
    {
        public string? fullName { get; set; }
        
        public DateTime Dob { get; set; }
        public string? Position { get; set; }
        public string? Pic { get; set; }
    }
}
