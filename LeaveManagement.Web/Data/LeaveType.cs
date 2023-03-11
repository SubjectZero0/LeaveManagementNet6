namespace LeaveManagement.Web.Data
{
    public class LeaveType : BaseEntity
    ///<summary>
    ///
    /// Type of Leave Request
    /// Used by Administrators
    ///
    /// </summary>
    {
        /// <remark>
        /// Name is added by admins
        /// </remark>
        public string Name { get; set; }

        public int DefaultDays { get; set; }
    }
}