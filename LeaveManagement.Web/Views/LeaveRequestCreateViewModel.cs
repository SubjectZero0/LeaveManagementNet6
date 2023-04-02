using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Views
{
    public class LeaveRequestCreateViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Leave Type")]
        [Required]
        public int LeaveTypeId { get; set; }

        [Display(Name = "Start Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateStarted { get; set; }

        [Display(Name = "End Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateEnded { get; set; }

        [Display(Name = "Description")]
        public string? Comment { get; set; }
    }
}