namespace Accounting_WebApi.Entities.DataTransferObjects.Create
{
    public class StaffCreateRepo
    {
        public string? fullName { get; set; }
       
        public DateTime Dob { get; set; }
        
        public string? Position { get; set; }
        public IFormFile? Pic { get; set; }
    }
}
