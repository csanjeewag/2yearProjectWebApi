using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace EMS.Data.Models
{
   public  class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ContactId { get; set; }

        public string ContactType { get; set; }
        public Boolean IsActive { get; set; }
       // public IEnumerable<TaskInformation> TaskInformation { get; set; }


    }
}
