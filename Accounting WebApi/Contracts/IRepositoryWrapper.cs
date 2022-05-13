namespace Accounting_WebApi.Contracts
{
    public interface IRepositoryWrapper
    {
        IStaff staff { get; }
        IIncome income { get; }
        IExpenses expenses { get; }

        IClient clients { get;  }
        void save();
    }
}
