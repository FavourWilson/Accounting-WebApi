namespace Accounting_WebApi.Entities.DataTransferObjects.Update
{
    public class IncomeUpdateRepo
    {
        public string? Title { get; set; }

        public double? Cost { get; set; }

        public DateTime DateOfTransaction { get; set; }
    }
}
