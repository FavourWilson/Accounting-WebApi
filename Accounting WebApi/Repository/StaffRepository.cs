using Accounting_WebApi.Contracts;
using Accounting_WebApi.Entities;
using Accounting_WebApi.Entities.Models;

namespace Accounting_WebApi.Repository
{
    public class StaffRepository : RepositoryBase<Staffs>, IStaff
    {
        public StaffRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateStaffs(Staffs staffs) => Create(staffs);

        public void DeleteStaffs(Staffs staffs) => Delete(staffs);
        

        public IEnumerable<Staffs> GetStaffs()
        {
            return FindAll()
                .ToList();
        }

        public Staffs GetStaffsById(Guid id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return FindByCondition(e => e.Id.Equals(e))
                .FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
        }

        public void UpdateStaffs(Staffs staffs) => Update(staffs);
        
    }
}
