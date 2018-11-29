using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EMS.Data.Models
{
    public class OneDayTripRegistrant
    {

        [Key]
        public string PKey { get; set; }
        public string EventId { get; set; }
        public string EmployeeId { get; set; }
        public string TransportationMode { get; set; }
        public string NumberOfFamilyMembers { get; set; }


    }
}
