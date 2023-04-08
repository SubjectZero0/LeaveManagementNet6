using LeaveManagement.Web.Data;
using LeaveManagement.Web.Views;
using System.Security.Claims;

namespace LeaveManagement.Web.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task CreateWithCurrentUser(LeaveRequest leaveRequest);

        Task<ClaimsPrincipal> GetCurrentUser();

        Task<List<LeaveRequest>> GetAllEmployeeRequestsAsync(string employeeId);

        Task CancelLeaveRequest(int id);

        Task<List<LeaveRequest>> GetAllWithLeaveTypeAsync();
    }
}