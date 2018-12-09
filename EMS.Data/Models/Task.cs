using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace EMS.Data.Models
{
public class Task
    {

        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime AddDate { get; set; }
        public string EventName { get; set; }
        public float BudgetedCost { get; set; }
        public string Description { get; set; }
        public Boolean Status { get; set; }
              
        public ICollection<TaskInformation> TaskInformation { get; set; }


        public virtual ICollection<EmployeeTask> EmployeeTasks { get; set; }



    }
}
