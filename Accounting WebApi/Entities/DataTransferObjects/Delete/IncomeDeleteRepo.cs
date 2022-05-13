namespace Accounting_WebApi.Entities.DataTransferObjects.Delete
{
    public class IncomeDeleteRepo
    {
        public string? Title { get; set; }

        public double? Cost { get; set; }

        public DateTime DateOfTransaction { get; set; }
    }
}
