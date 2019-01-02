using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPIserver.Models
{
    public class Survey
    {
        public int Id { get; set; }
        //[Required]
        public string Name { get; set; }
        //[Required]
        public string Description { get; set; }
        public int Reward { get; set; }
        //[Required]
        public Company Company { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<SurveyUser> SurveyUsers { get; set; }
        //[Required]
        public List<Question> Questions { get; set; }
    }
}
