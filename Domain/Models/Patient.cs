using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Hospital.API.Domain.Models
{
    public class Patient
    {
        [Key]
        public int national_id { get; set; }
        public bool hospitalized { get; set; }
        public string comp_name { get; set; }
        public string comp_phone_number { get; set; }
    }
}