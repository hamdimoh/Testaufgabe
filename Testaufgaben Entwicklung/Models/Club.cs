using System;
using System.ComponentModel.DataAnnotations;
namespace Testaufgaben_Entwicklung.Models
{
    public class Club
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ClubName { get; set; }
        public int YearEstablished { get; set; }
        public string League { get; set; }
        public string Country { get; set; }
    }
}

