using Accounting_WebApi.Entities.Models;

namespace Accounting_WebApi.Contracts
{
    public interface IClient
    {
        IEnumerable<Clients> GetAllClients();
        Clients GetClientsById(Guid id);
        void DeleteClients(Clients clients);
        void UpdateClients(Clients clients);
        void CreateClients(Clients clients);
    }
}
