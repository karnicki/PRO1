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
    public class ZamowieniesController : ControllerBase
    {
        private s17129Context _context;
        public ZamowieniesController(s17129Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetZamowienies()
        {
            return Ok(_context.Zamowienie.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetZamowienie(int id)
        {
            var zamowienie = _context.Zamowienie.FirstOrDefault(e => e.IdZamowienie == id);
            if (zamowienie == null)
            {
                return NotFound();
            }
            return Ok(zamowienie);
        }
    }
}