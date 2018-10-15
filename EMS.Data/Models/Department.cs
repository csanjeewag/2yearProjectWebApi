using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Data.Models
{
    public class Department
    {
        [Key]
        public string DprtId { get; set; }
        public string DprtName { get; set; }
       // public ICollection<Emp> Emp { get; set; }
       public IEnumerable<Employee> Emp { get; set; }
    }
}
