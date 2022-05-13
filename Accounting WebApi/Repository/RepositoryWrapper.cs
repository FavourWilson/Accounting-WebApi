using Accounting_WebApi.Contracts;
using Accounting_WebApi.Entities;

namespace Accounting_WebApi.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _context;
        private IStaff? _staff;
        private IIncome? _income;
        private IExpenses? _expenses;
        private IClient? _client;
        public IStaff staff
        {
            get
            {
                if(_staff == null )
                {
                    _staff = new StaffRepository(_context);
                }
                return _staff;
            }
        }

        public IIncome income
        {
            get
            {
                if(_income == null)
                {
                    _income = new IncomeRepository(_context);
                }
                return _income;
            }
        }

        public IExpenses expenses
        {
            get
            {
                if(_expenses == null)
                {
                    _expenses = new ExpenseRepository(_context);
                }
                return _expenses;
            }
        }

        public IClient clients
        {
            get
            {
                if (_client == null)
                {
                    _client = new ClientRepository(_context);
                }
                return _client;
            }
        }

       

        public RepositoryWrapper(RepositoryContext context)
        {
            _context = context;
        }
        public void save()
        {
            _context.SaveChanges();
        }
    }
}
