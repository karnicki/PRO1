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
    public class PizzasController : ControllerBase
    {
        private readonly s17129Context _context;
        public PizzasController(s17129Context context)
        {
            _context = context;

        }

        [HttpGet]
        public IActionResult GetPizzas()
        {
            return Ok(_context.Pizza.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPizza(int id)
        {
            var pizza = _context.Pizza.FirstOrDefault(e => e.IdPizza == id);
            if(pizza == null)
            {
                return NotFound();
            }
            return Ok(pizza);
        }
    }
}