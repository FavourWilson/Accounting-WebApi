namespace Accounting_WebApi.Entities.DataTransferObjects.View
{
    public class IncomeViewRepo
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }

        public double? Cost { get; set; }

        public DateTime DateOfTransaction { get; set; }
    }
}
