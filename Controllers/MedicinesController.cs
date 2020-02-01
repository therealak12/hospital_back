using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Hospital.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Hospital.API.Controllers
{
    [Route("/api/[controller]")]
    public class MedicinesController : Controller
    {
        private readonly AppDbContext dbContext;

        public MedicinesController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetMedicines() {
            var medicines = dbContext.Medicine.FromSqlRaw("select * from medicine").ToList();
            return Ok(medicines);
        }
    }
}