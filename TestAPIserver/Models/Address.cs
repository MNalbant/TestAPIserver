using System.ComponentModel.DataAnnotations;

namespace TestAPIserver.Models
{
    public class Address
    {
        public int Id { get; set; }
       // [Required]
        public string StreetName { get; set; }
       // [Required]
        public int HouseNumber { get; set; }
        //[Required]
        public string Addition { get; set; }
        //[Required]
        public string ZipCode { get; set; }
    }
}