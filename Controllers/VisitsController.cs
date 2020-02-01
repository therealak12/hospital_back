using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Hospital.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Hospital.API.Domain.Models;

namespace Hospital.API.Controllers
{
    [Route("/api/[controller]")]
    public class VisitsController : Controller
    {
        private readonly AppDbContext dbContext;
        public VisitsController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult CreateVisit([FromBody] Visit visit)
        {
            // Console.WriteLine(visit.medicines[0]);

            try
            {
                dbContext.prescribtion
                .FromSqlRaw("insert into prescribtion values({0})", visit.pres_id);
                dbContext.Database.ExecuteSqlRaw("insert into prescribtion values({0})", visit.pres_id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                dbContext.Database
                .ExecuteSqlRaw("insert into visit values ({0}, {1}, {2}, {3}, {4})"
                , visit.patient_id, visit.vis_date, visit.doctor_id, visit.dis_code, visit.pres_id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                foreach (PresMedicine pres_medicine in visit.medicines)
                {
                    dbContext.Database
                    .ExecuteSqlRaw("insert into pres_medicine values ({0}, {1}, {2}, {3})"
                        , pres_medicine.pres_id, pres_medicine.med_name, pres_medicine.amount, pres_medicine.each_n_hours);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return Ok();
        }
    }
}