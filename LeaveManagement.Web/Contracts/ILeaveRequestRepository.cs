using LeaveManagement.Web.Data;
using LeaveManagement.Web.Views;
using System.Security.Claims;

namespace LeaveManagement.Web.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task CreateWithCurrentUser(LeaveRequest leaveRequest);

        Task<ClaimsPrincipal> GetCurrentUser();

        Task<EmployeeLeavesListViewModel> GetMyLeavesAsync();

        Task<List<LeaveRequest>> GetAllEmployeeRequestsAsync(string employeeId);
    }
}