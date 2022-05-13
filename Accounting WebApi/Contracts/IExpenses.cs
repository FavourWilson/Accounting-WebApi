using Accounting_WebApi.Entities.Models;

namespace Accounting_WebApi.Contracts
{
    public interface IExpenses
    {
        IEnumerable<Expenses> GetExpenses();
        Expenses GetExpensesById(Guid expenseid);
        void DeleteExpenses(Expenses expenses);
        void UpdateExpenses(Expenses expenses);
        void CreateExpenses(Expenses expenses);

    }
}
