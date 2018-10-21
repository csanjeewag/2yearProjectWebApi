using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Data.Models
{
    public class Employee 
    {
        [Key]
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpContact { get; set; }
        public string EmpAddress1 { get; set; }

        public string EmpAddress2 { get; set; }
        
        public string EmpEmail { get; set; }
        public string EmpPassword { get; set; }
        public string EmpGender { get; set; }
        [ForeignKey("Position")]
        public string PositionPId { get; set; } 
         
        [ForeignKey("Department")]
        public string DepartmentDprtId { get; set; } 
        public DateTime StartDate { get; set; }
        public Boolean IsActive { get; set; }
        public string RegisterCode { get; set; }
        

    }
}
 