using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.API.Domain.Models
{
    public class Medicine
    {
        [Key]
        public string sci_name { get; set; }
        public string brand_name { get; set; }
    }
}