using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMS.Data.Models
{
    public class TwoDayTripRegistrants
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string PKey { get; set; }
        [ForeignKey("Event")]
        public string EventId { get; set; }
        public string EmployeeId { get; set; }
        public string TransportationMode { get; set; }
        public string NumberOfFamilyMembers { get; set; }
        public string Accomadation { get; set; }
        public string MealTypeVegi { get; set; }
        public string MealTypeNonVegi { get; set; }
    }
}

