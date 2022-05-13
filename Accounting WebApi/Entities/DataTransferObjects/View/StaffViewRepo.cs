namespace Accounting_WebApi.Entities.DataTransferObjects.View
{
    public class StaffViewRepo
    {
        public Guid Id { get; set; }
        public string? fullName { get; set; }
        
        public DateTime Dob { get; set; }
       
        public string? Position { get; set; }
        public string? Pic { get; set; }
    }
}
