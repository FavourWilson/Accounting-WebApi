using AutoMapper;
namespace Accounting_WebApi.Entities.Profiles
{
    public class ExpenseMapper : Profile
    {
        public ExpenseMapper()
        {
            CreateMap<Models.Expenses, DataTransferObjects.View.ExpenseViewRepo>();
            CreateMap<DataTransferObjects.Create.ExpenseCreateRepo, Models.Expenses>();
            CreateMap<DataTransferObjects.Update.ExpenseUpdateRepo, Models.Expenses>();
        }
    }
}
