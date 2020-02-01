using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Hospital.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Hospital.API.Domain.Models;

namespace Hospital.API.Controllers
{
    [Route("/api/[controller]")]
    public class DoctorsController : Controller
    {
        private readonly AppDbContext dbContext;

        public DoctorsController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            var doctors = dbContext.Doctor.FromSqlRaw("select * from doctor natural join person").ToList();
            return Ok(doctors);
        }

        [HttpGet("{id}/visits")]
        public IActionResult GetDoctors(int id)
        {
            var visits = dbContext.Visit
            .FromSqlRaw("select * from doctor inner join visit on (visit.doctor_id = doctor.emp_id) where doctor_id = {0}", id)
            .ToList();

            var medicines = dbContext.pres_medicine
            .FromSqlRaw("select med_name, amount, each_n_hours, pres_id from visit natural join pres_medicine where doctor_id = {0}", id)
            .ToList();


            foreach (Visit visit in visits)
            {
                foreach (PresMedicine medicine in medicines)
                {
                    if (medicine.pres_id == visit.pres_id)
                    {
                        visit.medicines.Add(medicine);
                    }
                }
            }

            return Ok(visits);
        }
    }
}