using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Hospital.API.Domain.Models
{
    public class Prescribtion
    {
        [Key]
        public int pres_id { get; set; }
    }
}