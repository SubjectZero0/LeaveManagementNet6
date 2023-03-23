using LeaveManagement.Web.Configurations.Entities;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LeaveManagement.Web.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationsRepository
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<Employee> _userManager;

        public LeaveAllocationRepository
            (
            ApplicationDbContext context,
            ILeaveTypeRepository leaveTypeRepository,
            IHttpContextAccessor httpContextAccessor,
            UserManager<Employee> userManager
            ) : base(context)
        {
            this._leaveTypeRepository = leaveTypeRepository;
            this._httpContextAccessor = httpContextAccessor;
            this._userManager = userManager;
        }

        public async Task AddLeaveAllocation(int leaveTypeId)
        {
            var Year = DateTime.Now.Year;
            var leaveType = await _leaveTypeRepository.GetAsync(leaveTypeId);

            if (leaveType is null)
            {
                throw new Exception("leaveType {leaveTypeId} not Found");
            };

            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);

            if (currentUser is null)
            {
                throw new Exception("Unauthorized");
            }
            var currentUserId = currentUser.Id;

            var leaveAllocation = new LeaveAllocation
            {
                LeaveTypeId = leaveTypeId,
                EmployeeId = currentUserId,
                Year = Year,
                LeaveType = leaveType,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
            };

            await AddAsync(leaveAllocation);
        }
    }
}