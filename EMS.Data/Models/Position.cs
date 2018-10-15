using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Data.Models
{
    public class Position
    {
        [Key]
        public string PositionId { get; set; }
        public string PositionName { get; set; } 
        public string PositionDis { get; set; }
        public ICollection<Employee> Employee { get; set; }
    }
}
