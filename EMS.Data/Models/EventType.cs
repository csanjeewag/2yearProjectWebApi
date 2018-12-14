using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMS.Data.Models
{
  public  class Eventtype
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string EventTypeId { get; set; }
        public string EventTypeName { get; set; }
        public string EventTypeDescription { get; set; }
        public IEnumerable<Event> Events { get; set; }
    }
}
