using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzeriaApp.Models;
using System.Linq;

namespace PizzeriaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly s17129Context _context;
        public ClientsController(s17129Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetClients()
        {
            return Ok(_context.Klient.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetClient(int id)
        {
            var client = _context.Klient.FirstOrDefault(e => e.IdUser == id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost]
        public IActionResult Create(Klient newClient)
        {
            _context.Klient.Add(newClient);
            _context.SaveChanges();

            return StatusCode(201, newClient);
        }

        [HttpPut("{IdUser:int}")]
        public IActionResult Update(int IdUser, Klient updatedClient)
        {

            if(_context.Klient.Count(e => e.IdUser == IdUser) == 0)
            {
                return NotFound();
            }

            _context.Klient.Attach(updatedClient);
            _context.Entry(updatedClient).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedClient);
        }

        [HttpDelete("{IdUser:int}")]
        public IActionResult Delete(int IdUser)
        {
            var client = _context.Klient.FirstOrDefault(e => e.IdUser == IdUser);
            if (client == null)
            {
                return NotFound();
            }

            _context.Klient.Remove(client);
            _context.SaveChanges();

            return Ok(client);
        }
    }
}