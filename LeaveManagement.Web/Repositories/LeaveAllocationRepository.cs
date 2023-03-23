using LeaveManagement.Web.Configurations.Entities;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using Microsoft.AspNetCore.Identity;

namespace LeaveManagement.Web.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationsRepository
    {
        private readonly UserManager<Employee> _userManager;
        private readonly HttpContext _httpContext;

        public LeaveAllocationRepository(ApplicationDbContext context, UserManager<Employee> userManager, HttpContext httpContext) : base(context)
        {
            this._userManager = userManager;
            this._httpContext = httpContext;
        }

        public async Task LeaveAllocation(int leaveTypeId)
        {
            var user = await _userManager.GetUserAsync(_httpContext.User);
            var userId = user.Id;
            var Year = DateTime.Now.Year;

            LeaveAllocation allocation = new()
            {
                LeaveTypeId = leaveTypeId,
                EmployeeId = userId,
                Year = Year,

            };


            throw new NotImplementedException();
        }
    }
}
