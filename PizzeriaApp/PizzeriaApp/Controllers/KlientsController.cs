using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzeriaApp.Models;

namespace PizzeriaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KlientsController : ControllerBase
    {
        private s17129Context _context;
        public KlientsController(s17129Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetKlients()
        {
            return Ok(_context.Klient.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetKlient(int id)
        {
            var klient = _context.Klient.FirstOrDefault(e => e.IdUser == id);
            if (klient == null)
            {
                return NotFound();
            }
            return Ok(klient);
        }
    }
}