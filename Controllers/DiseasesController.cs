using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Hospital.API.Persistence.Contexts;

namespace Hospital.API.Controllers
{
    [Route("/api/[controller]")]
    public class DiseasesController : Controller
    {
        private readonly AppDbContext dbContext;

        public DiseasesController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetDiseases()
        {
            var diseases = dbContext.Disease.FromSqlRaw("select * from disease").ToList();
            return Ok(diseases);
        }
    }
}