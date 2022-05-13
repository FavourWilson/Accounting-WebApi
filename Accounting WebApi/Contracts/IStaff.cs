using Accounting_WebApi.Entities.Models;

namespace Accounting_WebApi.Contracts
{
    public interface IStaff
    {
        IEnumerable<Staffs> GetStaffs();
        Staffs GetStaffsById(Guid id);
        void DeleteStaffs(Staffs staffs);
        void UpdateStaffs(Staffs staffs);
        void CreateStaffs(Staffs staffs);   
    }
}
