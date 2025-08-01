using Catalogservice.Data;
using Catalogservice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Controllers

{

    [Route("api/[controller]")]

    [ApiController]

    public class CatalogController : ControllerBase

    {

        private readonly AppDBContext _context;

        public CatalogController(AppDBContext context)

        {

            _context = context;

        }

        [HttpGet]

        public async Task<IActionResult> getAll()

        {

            var shipments = await _context.CatalogServices.ToListAsync();

            return Ok(shipments);

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)

        {

            var shipment = await _context.CatalogServices.FindAsync(id);

            if (shipment is null)

            {

                return NotFound();

            }

            else

            {

                return Ok(shipment);

            }

        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] Catalog shipping)

        {

            _context.CatalogServices.Add(shipping);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Create), shipping);

        }

        [HttpPut("{id}")]

        public async Task<IActionResult> update(int id, Catalog shipping)

        {

            var shipment = await _context.CatalogServices.FindAsync(id);

            if (shipment is null)

            {

                return NotFound();

            }

            else

            {

                shipment.Name = shipping.Name;

                shipment.Description = shipping.Description;

                await _context.SaveChangesAsync();


                return Ok(shipment);

            }

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)

        {

            var shipment = await _context.CatalogServices.FindAsync(id);

            if (shipment is null)

            {

                return NotFound();

            }

            else

            {

                _context.CatalogServices.Remove(shipment);

                await _context.SaveChangesAsync();

                return Ok(shipment);

            }

        }

    }

}

