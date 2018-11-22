using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMS.Data.ViewModels
{
   public class GetEmployeesDetails
    {
        [Key]
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpContact { get; set; }
        public string EmpAddress1 { get; set; }
        public string EmpAddress2 { get; set; }
        public string EmpEmail { get; set; }
        public string EmpGender { get; set; }
        public string EmpPosition { get; set; }
        public string EmpDepartment{ get; set; } 
        public string EmpProfilePicture { get; set; }
        public DateTime EmpStartDate { get; set; }
    }
}
