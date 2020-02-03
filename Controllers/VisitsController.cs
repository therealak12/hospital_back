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
            var last = dbContext.prescribtion.FromSqlRaw("select * from prescribtion").Count();
            try
            {
                dbContext.prescribtion
                .FromSqlRaw("insert into prescribtion values({0})", last + 1);
                dbContext.Database.ExecuteSqlRaw("insert into prescribtion values({0})", last);
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while inserting in prescribtion table");
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

            try
            {
                dbContext.Database
                .ExecuteSqlRaw("insert into visit values ({0}, {1}, {2}, {3}, {4})"
                , visit.patient_id, visit.vis_date, visit.doctor_id, visit.dis_code, last);
            }
            catch (Exception e)
            {

                Console.WriteLine("Error while inserting in visit table");
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

            try
            {
                foreach (PresMedicine pres_medicine in visit.medicines)
                {
                    dbContext.Database
                    .ExecuteSqlRaw("insert into pres_medicine values ({0}, {1}, {2}, {3})",
                        last, pres_medicine.med_name, pres_medicine.amount, pres_medicine.each_n_hours);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Error while inserting in pres_medicine table");
                Console.WriteLine(e.Message);
            }

            return Ok();
        }
    }
}