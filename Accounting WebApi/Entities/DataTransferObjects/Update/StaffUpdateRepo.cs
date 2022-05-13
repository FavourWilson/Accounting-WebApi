namespace Accounting_WebApi.Entities.DataTransferObjects.Update
{
    public class StaffUpdateRepo
    {
        public string? firstName { get; set; }
       
        public string? middleName { get; set; }
       
        public string? LastName { get; set; }
       
        public DateTime Dob { get; set; }
      
        public string? Position { get; set; }
        public string? Pic { get; set; }
    }
}
