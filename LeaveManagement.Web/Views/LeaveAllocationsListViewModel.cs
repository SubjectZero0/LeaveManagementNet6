using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LeaveManagement.Web.Views
{
    public class LeaveAllocationsListViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Type of Leave")]
        public LeaveTypeViewModel? LeaveType { get; set; }

        [Display(Name = "Allocated Number of Days")]
        [Required]
        public int NumberOfDays { get; set; }

        [Display(Name = "Year")]
        [Required]
        public int Year { get; set; }
    }
}