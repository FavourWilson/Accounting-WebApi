namespace Accounting_WebApi.Entities.DataTransferObjects.View
{
    public class ClientViewRepo
    {
        public Guid Id { get; set; }
        public string? clientName { get; set; }
        public string? phone { get; set; }
        public string? businessName
        {
            get; set;
        }
    }
}
