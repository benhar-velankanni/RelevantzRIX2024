
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

using ShippingServices.Data;


using ShippingServices.Model;
 
namespace ShippingServices.Controllers

{

    [Route("api/[controller]")]

    [ApiController]

    public class ShippingServiceController : ControllerBase

    {

        private readonly AppDbContext _Context;

        public ShippingServiceController(AppDbContext context)

        {

            _Context = context;

        }

        //Get: api/

        [HttpGet]

        public async Task<IActionResult> GetAll()

        {

            var shipments = await _Context.ShippingItems.ToListAsync();

            return Ok(shipments);

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)

        {

            var shipment = await _Context.ShippingItems.FindAsync(id);

            if (shipment == null) return NotFound();

            else return Ok(shipment);

        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] ShippingItem shippingItem)

        {

            _Context.ShippingItems.Add(shippingItem);

            await _Context.SaveChangesAsync();

            return CreatedAtAction(nameof(Create), shippingItem);

        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, [FromBody] ShippingItem shippingItem)

        {

            var shipment = await _Context.ShippingItems.FindAsync(id);

            if (shipment == null) return NotFound();

            shipment.ItemDescription = shippingItem.ItemDescription;

            shipment.ItemName = shippingItem.ItemName;

            shipment.ItemDescription = shippingItem.ItemDescription;

            shipment.DateTime = shippingItem.DateTime;

            await _Context.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)

        {

            var shipment = await _Context.ShippingItems.FindAsync(id);

            if (shipment == null) return NotFound();

            _Context.ShippingItems.Remove(shipment);

            await _Context.SaveChangesAsync();

            return NoContent();

        }


    }

}

