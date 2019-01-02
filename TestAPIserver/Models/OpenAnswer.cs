using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPIserver.Models
{
    public class OpenAnswer
    {
        public int Id { get; set; }
        //[Required]
        public string Title { get; set; }
        //[Required]
        public string Response { get; set; }

        [ForeignKey("Question")]
        public Question question { get; set; }
    }
}
