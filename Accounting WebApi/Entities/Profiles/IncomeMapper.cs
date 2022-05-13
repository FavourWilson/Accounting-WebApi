using AutoMapper;

namespace Accounting_WebApi.Entities.Profiles
{
    public class IncomeMapper : Profile
    {
        public IncomeMapper()
        {
            CreateMap<Models.Income, DataTransferObjects.View.IncomeViewRepo>();
            CreateMap<DataTransferObjects.Create.IncomeCreateRepo, Models.Income>();
            CreateMap<DataTransferObjects.Update.IncomeUpdateRepo, Models.Income>();
        }
    }
}
