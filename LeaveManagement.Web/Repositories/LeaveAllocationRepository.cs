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

            foreach (var employee in employees)
            {
                // if the leave already esists for this employee & for this year...
                if (await AllocationExists(employee.Id, leaveTypeId, Year))
                {
                    continue; // ...go to the next iteration. Skip Adding leaveAllocationsList
                }

                leaveAllocationList.Add(new LeaveAllocation
                {
                    EmployeeId = employee.Id.ToString(),
                    LeaveType = leaveType,
                    LeaveTypeId = leaveType.Id,
                    Year = Year,
                    NumberOfDays = leaveType.DefaultDays,
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

        /// <summary>
        /// Method to get the Specific Employee's LeaveAllocation along with the LeaveType.
        /// </summary>
        /// <param name="leaveTypeId">The LeaveTypeId of the LeaveAllocation instance</param>
        /// <returns>An instance of the LeaveAllocation inner join with the LeaveType</returns>
        public async Task<LeaveAllocation> FindByEmployeeAsync(int? id)
        {
            if (id is null || _context is null)
            {
                throw new Exception("There is nothing to Show");
            }

            var employeeLeaveAllocation = await _context.LeaveAllocations
                .Include(e => e.LeaveType)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (employeeLeaveAllocation == null)
            {
                throw new Exception("There are no leaves with this leave type");
            }

            return employeeLeaveAllocation;
        }

        /// <summary>
        /// Method to get all leave allocations that belong to an employee
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns> List of leave allocations with an EployeeId that matches the provided Employee.Id </returns>
        public async Task<List<LeaveAllocation>> GetAllByEmployeeAsync(string employeeId)
        {
            //to also retrieve the related(nested) table LeaveType data, we have to do an inner join => Include
            var employeeLeaveAllocationList = await _context.LeaveAllocations
                .Include(q => q.LeaveType)
                .Where(x => x.EmployeeId == employeeId).ToListAsync();

            return employeeLeaveAllocationList;
        }
    }
}