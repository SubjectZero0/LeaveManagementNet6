using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Views
{
    public class AdminLeaveStatisticsViewModel
    {
        public int Approved { get; set; }

        public int Rejected { get; set; }

        public int Pending { get; set; }

        public int Cancelled { get; set; }

        public int Total { get; set; }

        [Display(Name = "Total Days Approved")]
        public int LeaveDaysApproved { get; set; }
    }
}