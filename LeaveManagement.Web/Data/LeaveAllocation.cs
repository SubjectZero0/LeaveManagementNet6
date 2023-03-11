using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement.Web.Data
{
    public class LeaveAllocation : BaseEntity
    ///<summary>
    ///Table for keeping track of allocated leaves
    /// </summary>
    {
        ///<remarks>
        ///LeaveType is a FK
        /// </remarks>
        [ForeignKey("LeaveTypeId")]
        public LeaveType LeaveType { get; set; }

        public int LeaveTypeId { get; set; }

        /// <remarks>
        /// EmployeeId is NOT  FK yet
        /// </remarks>
        public string EmployeeId { get; set; }
    }
}