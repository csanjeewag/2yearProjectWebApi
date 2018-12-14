using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMS.Data.Models
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string EventId { get; set; }
        public string EventName { get; set; }

        [ForeignKey("Eventtype")]
        public int EventTypeId { get; set; }
        public string EventDescription { get; set; }
       public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public DateTime EventClosingDate { get; set; }


    }
}
