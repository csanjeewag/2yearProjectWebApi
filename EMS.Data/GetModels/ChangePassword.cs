using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Data.GetModels
{
   public class ChangePassword
    {
        public string EmployeeOldPassword { get; set; }
        public string EmployeeNewPassword { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeId { get; set; }
    }
}
