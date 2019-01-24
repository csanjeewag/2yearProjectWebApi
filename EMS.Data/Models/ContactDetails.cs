using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Data.Models
{
    public class ContactDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactDetailId { get; set; }
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactDescription { get; set; }
        [ForeignKey("Contact")]
        public Contact ContactId { get; set; }


    }
}
