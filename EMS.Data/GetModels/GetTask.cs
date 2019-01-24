using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Data.GetModels
{
    public class GetTask
    {
        //public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime AddDate { get; set; }
        public string EventName { get; set; }
        public float BudgetedCost { get; set; }
        public string Description { get; set; }
        public Boolean Status { get; set; }
       public List<int> Employees { get; set; }
    }
}
