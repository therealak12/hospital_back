using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Hospital.API.Domain.Models
{
    public class FullPatient
    {
        [Key]
        public int national_id { get; set; }
        public string f_name { get; set; }
        public string l_name { get; set; }
        public string phone_number { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public bool hospitalized { get; set; }
        public string comp_name { get; set; }
        public string comp_phone_number { get; set; }
    }
}