using Accounting_WebApi.Entities.Models;

namespace Accounting_WebApi.Contracts
{
    public interface IIncome
    {
        IEnumerable<Income> GetIncomes();
        Income GetIncomeById(Guid profitId);
        void DeleteIncome(Income profit);
        void UpdateIncome(Income profit);
        void CreateIncome(Income profit);
    }
}
