using Accounting_WebApi.Contracts;
using Accounting_WebApi.Entities;
using Accounting_WebApi.Entities.Models;

namespace Accounting_WebApi.Repository
{
    public class IncomeRepository : RepositoryBase<Income>, IIncome
    {
        public IncomeRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateIncome(Income income) => Create(income);


        public void DeleteIncome(Income income) => Delete(income);
        

        public Income GetIncomeById(Guid incomeId)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return FindByCondition(e => e.Id.Equals(incomeId)).FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
        }

        public IEnumerable<Income> GetIncomes()
        {
            return FindAll().ToList();
        }

        public void UpdateIncome(Income income) => Update(income);
        
    }
}
