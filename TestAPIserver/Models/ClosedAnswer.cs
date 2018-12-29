using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPIserver.Models
{
        public class ClosedAnswer
        {
            public int Id { get; set; }
            [Required]
            public string Title { get; set; }
            public bool Answered { get; set; }

            public Question Question { get; set; }
    }
}
