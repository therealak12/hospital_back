using System;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Hospital.API.Domain.Models
{
    public class Visit
    {
        public int patient_id { get; set; }
        public DateTime vis_date { get; set; }

        public int doctor_id { get; set; }

        public int dis_code { get; set; }
        public int pres_id { get; set; }

        [NotMapped]
        public List<PresMedicine> medicines { get; set; } = new List<PresMedicine>();
    }
}