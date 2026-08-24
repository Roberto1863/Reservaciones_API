using Microsoft.AspNetCore.Mvc;
using Reservaciones_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reservaciones_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly List<Reservas> reservaciones = new List<Reservas>
        {
            new Reservas { Id = 1, NombreReservacion = "Reservación 1", Fecha = DateOnly.FromDateTime(DateTime.Now), Cliente = "Cliente 1" },
            new Reservas { Id = 2, NombreReservacion = "Reservación 2", Fecha = DateOnly.FromDateTime(DateTime.Now.AddDays(1)), Cliente = "Cliente 2" },
            new Reservas { Id = 3, NombreReservacion = "Reservación 3", Fecha = DateOnly.FromDateTime(DateTime.Now.AddDays(2)), Cliente = "Cliente 3" }
        };

        // GET: api/<ReservasController>
        [HttpGet]
        public IEnumerable<Reservas> Get()
        {
            return reservaciones;
            }

        // GET api/<ReservasController>/5
        [HttpGet("{id}")]
        public ActionResult<Reservas> Get(int id)
        {
            var r = reservaciones.FirstOrDefault(x => x.Id == id);
            if (r == null) return NotFound();
            return r;
        }

        // POST api/<ReservasController>
        [HttpPost]
        public ActionResult<Reservas> Post([FromBody] Reservas value)
        {
            value.Id = reservaciones.Any() ? reservaciones.Max(r => r.Id) + 1 : 1;
            reservaciones.Add(value);
            return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
        }

        // PUT api/<ReservasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Reservas value)
        {
            var idx = reservaciones.FindIndex(r => r.Id == id);
            if (idx == -1) return NotFound();
            value.Id = id;
            reservaciones[idx] = value;
            return NoContent();
        }

        // DELETE api/<ReservasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var r = reservaciones.FirstOrDefault(x => x.Id == id);
            if (r == null) return NotFound();
            reservaciones.Remove(r);
            return NoContent();
        }
    }
}
