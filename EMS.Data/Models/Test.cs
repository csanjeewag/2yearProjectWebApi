using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Data.Models
{
    public class Test
    {
        // public string EmpName { get; set; }
      //  public Employee EmpName{ get; set; } 
      //  public Department DprtName { get; set; }   
        [Key]
        public string EmpName { get; set; } 
        public string Name { get; set; }
    }
}
