namespace Accounting_WebApi.Entities.DataTransferObjects.Create
{
    public class IncomeCreateRepo
    {
        public string? Title { get; set; }
       
        public double? Cost { get; set; }
        
        public DateTime DateOfTransaction { get; set; }
    }
}
