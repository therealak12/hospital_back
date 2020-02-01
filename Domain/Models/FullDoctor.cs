using System;
using System.ComponentModel.DataAnnotations;

namespace Hospital.API.Domain.Models
{
    public class FullDoctor
    {
        [Key]
        public int national_id { get; set; }
        public string f_name { get; set; }
        public string l_name { get; set; }
        public string phone_number { get; set; }
        public int age { get; set; }
        public int emp_id { get; set; }

        public DateTime hire_date { get; set; }

        public int salary { get; set; }
        public string speciality { get; set; }
        public string work_day1 { get; set; }
        public string work_day2 { get; set; }
        public string work_day3 { get; set; }
        public string work_day4 { get; set; }
    }
}