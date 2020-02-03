using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using Hospital.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Hospital.API.Domain.Models;

namespace Hospital.API.Controllers
{
    [Route("/api/[controller]")]
    public class PatientsController : Controller
    {
        private readonly AppDbContext dbContext;

        public PatientsController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetPatientInfo()
        {
            var patient = dbContext.Patient.FromSqlRaw("select * from patient natural join person");
            return Ok(patient);
        }

        [HttpGet("{id}")]
        public IActionResult GetPatient(int id) {
            var patient = dbContext.Patient
            .FromSqlRaw("select * from patient natural join person where national_id = {0}", id);

            return Ok(patient);
        }

        [HttpGet("{id}/visits")]
        public IActionResult GetPatientVisits(int id)
        {
            var visits = dbContext.Visit.
            FromSqlRaw("select * from visit where patient_id = {0}", id)
            .ToList();

            var medicines = dbContext.pres_medicine.
            FromSqlRaw("select med_name, amount, each_n_hours, pres_id from visit natural join pres_medicine where patient_id = {0}", id)
            .ToList();


            foreach (Visit visit in visits)
            {
                foreach (PresMedicine medicine in medicines)
                {
                    if (medicine.pres_id == visit.pres_id) {
                        visit.medicines.Add(medicine);
                    }
                }
            }

            return Ok(visits);
        }
    }
}