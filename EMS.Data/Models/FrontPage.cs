using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EMS.Data.Models
{
  public  class FrontPage
    {
        [Key]
        public string CriEventId { get; set; }
        public string CriEventMainTopic { get; set; }
        public string CriEventSubTopic { get; set; }
        public DateTime CriEventDate { get; set; }
        public DateTime CriEventTime { get; set; }
        public string CriEventPlace { get; set; }
        public DateTime CriEventDeadLine { get; set; }
        public string CriEventContent1 { get; set; }
        public string CriEventContent2 { get; set; }
    }
}
