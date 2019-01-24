using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Data.GetModels
{
    public class GetTaskInformation
    {
        public int ContactId { get; set; } //contact type
        public int EmpId { get; set;}   //responsible RC
        public int TaskId { get; set; } 

        public int Contact1 { get; set; }
        public int Contact2 { get; set; }
        public string InfoDescription { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactDescription { get; set; }
        public Boolean IsComplete { get; set; } //status of task



    }
}
