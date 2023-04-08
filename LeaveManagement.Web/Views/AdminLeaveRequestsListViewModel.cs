using LeaveManagement.Web.Data;

namespace LeaveManagement.Web.Views
{
    public class AdminLeaveRequestsListViewModel : LeaveRequestsListViewModel
    {
        public string RequestingEmployeeId { get; set; }

        public EmployeesViewModel RequestingEmployee { get; set; }
    }
}