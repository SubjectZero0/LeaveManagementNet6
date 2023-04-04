using LeaveManagement.Web.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace LeaveManagement.Web.Views
{
    public class LeaveRequestsListViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Starting Date")]
        [DataType(DataType.Date)]
        public DateTime DateStarted { get; set; }

        [Display(Name = "Ending Date")]
        [DataType(DataType.Date)]
        public DateTime DateEnded { get; set; }

        [Display(Name = "Type of Leave")]
        public LeaveTypeViewModel LeaveType { get; set; }

        [Display(Name = "Approval Status")]
        public bool? IsApproved { get; set; }

        [Display(Name = "Cancellation Status")]
        public bool IsCancelled { get; set; }
    }
}