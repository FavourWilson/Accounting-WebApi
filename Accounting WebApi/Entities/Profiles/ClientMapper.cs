using AutoMapper;

namespace Accounting_WebApi.Entities.Profiles
{
    public class ClientMapper : Profile
    {
        public ClientMapper()
        {
            CreateMap<Models.Clients, DataTransferObjects.View.ClientViewRepo>();
            CreateMap<DataTransferObjects.Create.ClientsCreateRepo, Models.Clients>();
            CreateMap<DataTransferObjects.Update.ClientsUpdateRepo, Models.Clients>();
        }
    }
}
