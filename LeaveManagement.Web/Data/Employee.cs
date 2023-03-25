using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Data
{
    public class Employee : IdentityUser
    ///<summary>
    /// Class to extend IdentityUser and add the
    /// following table columns.
    /// </summary>
    {
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; }

        [StringLength(15, MinimumLength = 15)]
        public string TaxId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateJoined { get; set; }
    }
}