using LeaveManagement.Web.Data;
using System.Security.Claims;

namespace LeaveManagement.Web.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task CreateWithCurrentUser(LeaveRequest leaveRequest, ClaimsPrincipal user);

        Task<ClaimsPrincipal> GetCurrentUser();
    }
}