using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hospital.API.Domain.Models;

namespace Hospital.API.Domain.Models
{
    public class PresMedicine
    {
        [Key]
        public string med_name { get; set; }
        public int pres_id { get; set; }
        public int amount { get; set; }
        public int each_n_hours { get; set; }

    }
}