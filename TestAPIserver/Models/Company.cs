﻿using System.ComponentModel.DataAnnotations;

namespace TestAPIserver.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }


    }
}