using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzeriaApp.Models;

namespace PizzeriaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditivesController : ControllerBase
    {
        private readonly s17129Context _context;

        public AdditivesController(s17129Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAdditives()
        {
            return Ok(_context.Dodatki.ToList());
        }

        [HttpGet("{IdDodatek:int}")]
        public IActionResult GetAdditive(int IdDodatek)
        {
            var additive = _context.Dodatki.FirstOrDefault(e => e.IdDodatek == IdDodatek);
            if (additive == null)
            {
                return NotFound();
            }
            return Ok(additive);
        }

        [HttpPut("{IdDodatek:int}")]
        public IActionResult Update(int IdDodatek, Dodatki updatedAdditive)
        {

            if (_context.Dodatki.Count(e => e.IdDodatek == IdDodatek) == 0)
            {
                return NotFound();
            }

            _context.Dodatki.Attach(updatedAdditive);
            _context.Entry(updatedAdditive).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedAdditive);
        }

        [HttpDelete("{IdDodatek:int}")]
        public IActionResult Delete(int IdDodatek)
        {
            var additive = _context.Dodatki.FirstOrDefault(e => e.IdDodatek == IdDodatek);
            if (additive == null)
            {
                return NotFound();
            }

            _context.Dodatki.Remove(additive);
            _context.SaveChanges();

            return Ok(additive);
        }
    }
}