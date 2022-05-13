using Accounting_WebApi.Contracts;
using Accounting_WebApi.Entities;
using Accounting_WebApi.Entities.Models;

namespace Accounting_WebApi.Repository
{
    public class ClientRepository : RepositoryBase<Clients>, IClient
    {
        public ClientRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateClients(Clients clients) => Create(clients);


        public void DeleteClients(Clients clients) => Delete(clients);
        

        public IEnumerable<Clients> GetAllClients()
        {
            return FindAll().ToList();
        }

        public Clients GetClientsById(Guid id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return FindByCondition(e => e.Id.Equals(id)).FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
        }

        public void UpdateClients(Clients clients) => Update(clients);
        
    }
}
