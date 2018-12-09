using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace EMS.Data.GetModels
{
  public  class GetEmployee
    {
       
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpContact { get; set; }
        public string EmpAddress1 { get; set; }

        public string EmpAddress2 { get; set; }

        public string EmpEmail { get; set; }
        public string EmpPassword { get; set; }
        public string EmpGender { get; set; }
        
        public string PositionPId { get; set; }

        
        public string DepartmentDprtId { get; set; }
        public DateTime StartDate { get; set; }
        public Boolean IsActive { get; set; }
        public string RegisterCode { get; set; }
        public int ProjectId { get; set; }
        public IFormFile EmpProfilePicture { get; set; }
    }
}
