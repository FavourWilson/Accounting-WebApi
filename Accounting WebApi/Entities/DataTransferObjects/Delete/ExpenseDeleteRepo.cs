namespace Accounting_WebApi.Entities.DataTransferObjects.Delete
{
    public class ExpenseDeleteRepo
    {
        public string? title { get; set; }

        public double? cost { get; set; }

        public DateTime dateOfTransaction { get; set; }

        public string? clientName { get; set; }
    }
}
