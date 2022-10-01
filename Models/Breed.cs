using System.ComponentModel.DataAnnotations;

namespace EV.Models
{
    public class Breed
    { 
        [Key]
        public string breed_name { get; set; } 
        public string? illness { get; set; } 
        public string? facts { get; set; }
    }
}