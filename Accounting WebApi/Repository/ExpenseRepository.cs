using Accounting_WebApi.Contracts;
using Accounting_WebApi.Entities;
using Accounting_WebApi.Entities.Models;

namespace Accounting_WebApi.Repository
{
    public class ExpenseRepository : RepositoryBase<Expenses>, IExpenses
    {
        public ExpenseRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateExpenses(Expenses expenses) => Create(expenses);


        public void DeleteExpenses(Expenses expenses) => Delete(expenses);
        

        public IEnumerable<Expenses> GetExpenses()
        {
            return FindAll().ToList();
        }

        public Expenses GetExpensesById(Guid expenseid)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return FindByCondition(e => e.Id.Equals(expenseid)).FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
        }

        public void UpdateExpenses(Expenses expenses) => Update(expenses);
        
    }
}
