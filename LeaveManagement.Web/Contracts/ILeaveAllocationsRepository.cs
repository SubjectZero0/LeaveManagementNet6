﻿using LeaveManagement.Web.Data;

namespace LeaveManagement.Web.Contracts
{
    public interface ILeaveAllocationsRepository : IGenericRepository<LeaveAllocation>
    {
        public Task AddLeaveAllocation(int leaveTypeId);

        public Task<bool> AllocationExists(string employeeId, int leaveTypeId, int year);

        public Task<List<LeaveAllocation>> GetAllByEmployeeAsync(string employeeId);
    }
}