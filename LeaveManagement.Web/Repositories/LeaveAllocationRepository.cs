using LeaveManagement.Web.Configurations.Entities;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly UserManager<Employee> _userManager;

        public LeaveAllocationRepository
            (
            ApplicationDbContext context,
            ILeaveTypeRepository leaveTypeRepository,
            UserManager<Employee> userManager
            ) : base(context)
        {
            this._context = context;
            this._leaveTypeRepository = leaveTypeRepository;
            this._userManager = userManager;
        }

        /// <summary>
        /// Allocates A list of leaves to all Employees
        /// </summary>
        /// <param name="leaveTypeId"></param>        
        public async Task AddLeaveAllocation(int leaveTypeId)
        {
            var Year = DateTime.Now.Year;
            var leaveType = await _leaveTypeRepository.GetAsync(leaveTypeId);

            if (leaveType is null)
            {
                throw new Exception($"leaveType {leaveTypeId} not Found");
            }

            var employees = await _userManager.GetUsersInRoleAsync(UserRoleConstants.User);

            if (employees is null)
            {
                throw new Exception("No Users in the System");
            }

            List<LeaveAllocation> leaveAllocationList = new();

            foreach ( var employee in employees )
            {

                // if the leave already esists for this employee & for this year...
                if(await AllocationExists(employee.Id, leaveTypeId, Year))
                {
                    continue; // ...go to the next iteration. Skip Adding leaveAllocationsList
                }

                leaveAllocationList.Add(new LeaveAllocation
            {
                EmployeeId = employee.Id.ToString(),
                LeaveTypeId = leaveTypeId,
                Year = Year,
                LeaveType = leaveType,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
                
            });

            }
            await AddRangeAsync(leaveAllocationList);
        }

        ///<summary>
        ///Checks if user already has leave allocated for that year
        /// </summary>
        public async Task<bool> AllocationExists(string employeeId, int leaveTypeId, int year)
        {
            
            var allocations = await _context.LeaveAllocations.AnyAsync
                (
                leaveAllocations => leaveAllocations.LeaveTypeId == leaveTypeId &&
                leaveAllocations.Year == year &&
                leaveAllocations.EmployeeId == employeeId
                );


            return allocations;
        }
    }
}