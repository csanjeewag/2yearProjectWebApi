using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Data.Models
{
    public class TaskInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int InfoID { get; set; }
        public string InfoDescription { get; set; }
        public Boolean IsComplete { get; set; }
        public Boolean IsActive { get; set; }

        [ForeignKey("Employee")]
        public Employee Id { get; set; }

        [ForeignKey("Task")]
        public Task TaskId { get; set; }

       [ForeignKey("Contact")]
       public Contact ContactId { get; set; }
        
    }
}
