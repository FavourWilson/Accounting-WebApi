namespace Accounting_WebApi.Entities.DataTransferObjects.Update
{
    public class ExpenseUpdateRepo
    {
        public string? title { get; set; }

        public double? cost { get; set; }

        public DateTime dateOfTransaction { get; set; }

        public string? clientName { get; set; }
    }
}
