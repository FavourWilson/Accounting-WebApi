namespace Accounting_WebApi.Entities.DataTransferObjects.Delete
{
    public class ClientDeleteRepo
    {
        public string? clientName { get; set; }

        public string? phone { get; set; }
        public string? businessName
        {
            get; set;
        }
    }
}
