using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EMS.Data.Models
{
    public class CricketTeam
    {
        [Key]
        public string CriTeamID { get; set; }
        public string CriTeamName { get; set; }
        public string CriTeamCaptionName { get; set; }
        public string CriTeamCaptionContact { get; set; }
        public string CriTeamCaptionEmail { get; set; }
        public string CriTeamParticipations { get; set; }
        public string CriTeamVegitarion { get; set; }
        public string CriTeamNonVegitarion { get; set; }

    }
}
