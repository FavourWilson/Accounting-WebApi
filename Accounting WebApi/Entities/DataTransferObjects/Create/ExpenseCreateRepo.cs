namespace Accounting_WebApi.Entities.DataTransferObjects.Create
{
    public class ExpenseCreateRepo
    {
        
        public string? title { get; set; }
      
        public double? cost { get; set; }
       
        public DateTime dateOfTransaction { get; set; }
        
        public string? clientName { get; set; }
    }
}
