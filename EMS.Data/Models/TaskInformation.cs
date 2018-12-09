using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Data.Models
{
    public class TaskInformation
    {
       [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int FileID { get; set; }
        public string FileName { get; set; }
        [ForeignKey("Task")]
        public Task TaskId { get; set; }

    }
}
