namespace LeaveManagement.Web.Views
{
    public class EmployeeLeavesListViewModel
    {
        public List<LeaveAllocationsListViewModel> LeaveAllocations { get; set; }

        public List<LeaveRequestsListViewModel> LeaveRequests { get; set; }
    }
}