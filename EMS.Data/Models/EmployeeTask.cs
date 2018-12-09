using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Data.Models
{
   public  class EmployeeTask
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public int TaskId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Task Task { get; set; }

    }
}
