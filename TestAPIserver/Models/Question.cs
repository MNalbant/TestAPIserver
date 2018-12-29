using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPIserver.Models
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        public string _Question { get; set; }
        public QustionType QustionType { get; set; }
        public List<ClosedAnswer> ClosedAnswers { get; set; }
        public OpenAnswer OpenAnswer { get; set; }

    }
}
