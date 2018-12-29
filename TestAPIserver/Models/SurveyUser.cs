using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TestAPIserver.Models;

namespace TestAPIserver.Models
{
    public class SurveyUser
    {
        [Key]
        [ForeignKey("UserMaster")]
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }

        [Key]
        [ForeignKey("UserMaster")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
