using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPIserver.Models
{
    public class User
    {
        public int Id { get; set; }
        //  [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string FirstName { get; set; }
        //  [Required]
        public string LastName { get; set; }
        // [Required]
        public bool Sex { get; set; }
        //  [Required]
        public string Mail { get; set; }
        // [Required]
        public int PhoneNumber { get; set; }
        // [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //[Required]
        public Address Address { get; set; }
        public List<SurveyUser> SurveyUsers { get; set; }
    }
}
