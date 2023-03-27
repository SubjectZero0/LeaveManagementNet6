using LeaveManagement.Web.Data;
using LeaveManagement.Web.Repositories;
using LeaveManagement.Web.Views;

namespace LeaveManagement.Web.Contracts
{
    public interface ILeaveAllocationsRepository : IGenericRepository<LeaveAllocation>
    {
        public Task AddLeaveAllocation(int leaveTypeId);

        public Task<bool> AllocationExists(string employeeId, int leaveTypeId, int year);

        public Task<List<LeaveAllocation>> GetAllByEmployeeAsync(string employeeId);

        public Task<LeaveAllocation> FindByEmployeeAsync(int? id);

        public Task UpdateEmployeeAllocation(LeaveAllocation leaveAllocation, LeaveAllocationsViewModel leaveAllocationVM);
    }
}