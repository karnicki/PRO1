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
    public class OrdersController : ControllerBase
    {
        private readonly s17129Context _context;
        public OrdersController(s17129Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(_context.Zamowienie.ToList());
        }

        [HttpGet("{IdZamowienie:int}")]
        public IActionResult GetOrder(int IdZamowienie)
        {
            var order = _context.Zamowienie.FirstOrDefault(e => e.IdZamowienie == IdZamowienie);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPut("{IdZamowienie:int}")]
        public IActionResult Update(int IdZamowienie, Zamowienie updatedOrder)
        {

            if (_context.Zamowienie.Count(e => e.IdZamowienie == IdZamowienie) == 0)
            {
                return NotFound();
            }

            _context.Zamowienie.Attach(updatedOrder);
            _context.Entry(updatedOrder).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedOrder);
        }

        [HttpDelete("{IdZamowienie:int}")]
        public IActionResult Delete(int IdZamowienie)
        {
            var order = _context.Zamowienie.FirstOrDefault(e => e.IdZamowienie == IdZamowienie);
            if (order == null)
            {
                return NotFound();
            }

            _context.Zamowienie.Remove(order);
            _context.SaveChanges();

            return Ok(order);
        }
    }
}