namespace Accounting_WebApi.Entities.DataTransferObjects.View
{
    public class ExpenseViewRepo
    {
        public Guid Id { get; set; }
        public string? title { get; set; }

        public double? cost { get; set; }

        public DateTime dateOfTransaction { get; set; }

        public string? clientName { get; set; }
    }
}
