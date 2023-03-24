using LeaveManagement.Web.Data;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LeaveManagement.Web.Views
{
    public class LeaveAllocationsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Type of Leave")]
        [Required]
        public LeaveType LeaveType { get; set; }

        [Display(Name = "Employee")]
        public string EmployeeId { get; set; }

        [Display(Name = "Year")]
        public int Year { get; set; }

    }
}
