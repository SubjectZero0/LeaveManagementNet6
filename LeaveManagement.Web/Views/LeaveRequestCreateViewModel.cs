using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Views
{
    public class LeaveRequestCreateViewModel : IValidatableObject
    {
        public int Id { get; set; }

        [Display(Name = "Leave Type")]
        [Required]
        public int LeaveTypeId { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime DateStarted { get; set; } = DateTime.Now;

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime DateEnded { get; set; } = DateTime.Now;

        [Display(Name = "Description")]
        public string? Comment { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateStarted > DateEnded)
            {
                yield return new ValidationResult("The Start Date can't be after the End Date", new[] { nameof(DateStarted), nameof(DateEnded) });
            }
        }
    }
}