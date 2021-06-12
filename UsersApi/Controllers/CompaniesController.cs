using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UsersApi.Models;

namespace UsersApi.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompaniesController : Controller
    {
        CompanyContext db;

        public CompaniesController(CompanyContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> Get()
        {
            return await db.Companies.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> Get(int id)
        {
            var company = await db.Companies.FirstOrDefaultAsync(x => x.Id == id);
            if (company == null)
                return NotFound();
            return new ObjectResult(company);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Company>> Post(Company company)
        {
            if (company == null)
            {
                return BadRequest();
            }

            db.Companies.Add(company);
            await db.SaveChangesAsync();
            return Ok(company);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Company>> Put(Company company)
        {
            if (company == null)
            {
                return BadRequest();
            }
            if (!db.Companies.Any(x => x.Id == company.Id))
            {
                return NotFound();
            }

            db.Update(company);
            await db.SaveChangesAsync();
            return Ok(company);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Company>> Delete(int id)
        {
            var company = db.Companies.FirstOrDefault(x => x.Id == id);
            if (company == null)
            {
                return NotFound();
            }
            db.Companies.Remove(company);
            await db.SaveChangesAsync();
            return Ok(company);
        }

    }
}
