using System.ComponentModel.DataAnnotations;

namespace Hospital.API.Domain.Models {
    public class Disease {
        [Key]
        public int disease_code { get; set; }
        public string name { get; set; }
    }
}