using LeaveManagement.Web.Data;

namespace LeaveManagement.Web.Contracts
{
    public interface ILeaveAllocationsRepository : IGenericRepository<LeaveAllocation>
    {
        public Task AddLeaveAllocation(int leaveTypeId);
    }
}