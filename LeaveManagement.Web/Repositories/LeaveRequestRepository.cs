using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using System.Security.Claims;

namespace LeaveManagement.Web.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LeaveRequestRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateWithCurrentUser(LeaveRequest leaveRequest, ClaimsPrincipal user)
        {
            if (user is not null)
            {
                leaveRequest.IsCancelled = false;
                leaveRequest.DateCreated = DateTime.Now;
                leaveRequest.DateModified = DateTime.Now;
                leaveRequest.RequestingEmployeeId = user.FindFirstValue(ClaimTypes.NameIdentifier);

                await _context.LeaveRequests.AddAsync(leaveRequest);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("You are not an authenticated user");
            }
        }

        public async Task<ClaimsPrincipal> GetCurrentUser()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user is not null)
            {
                return await Task.FromResult(user);
            }
            throw new Exception("You are not an authenticated user");
        }
    }
}