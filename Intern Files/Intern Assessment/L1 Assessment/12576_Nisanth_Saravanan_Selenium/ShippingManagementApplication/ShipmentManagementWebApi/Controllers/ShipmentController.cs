using Microsoft.AspNetCore.Mvc;
using ShipmentManagementWebApi.Data;
using ShipmentManagementWebApi.Models;

[ApiController]
[Route("api/[controller]")]
public class ShipmentController : ControllerBase
{
    private readonly AppDbContext _context;

    public ShipmentController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_context.Shipments.ToList());

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var shipment = _context.Shipments.Find(id);
        if (shipment == null) return NotFound("Shipment Not Found!");
        return Ok(shipment);
    }

    [HttpPost]
    public IActionResult Create(Shipment shipment, [FromQuery] string role)
    {
        if (role != "Admin") return Unauthorized("Only admin can create shipments");
        _context.Shipments.Add(shipment);
        _context.SaveChanges();
        return Ok(shipment);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Shipment updatedshipment, [FromQuery] string role)
    {
        if (role != "Admin") return Unauthorized("Only admin can update shipments");
        var shipment = _context.Shipments.Find(id);
        if (shipment == null) return NotFound("Shipment Not Found!");

        shipment.Name = updatedshipment.Name;
        shipment.Type  = updatedshipment.Type;
        shipment.Address = updatedshipment.Address;


        _context.SaveChanges();
        return Ok(shipment);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id, [FromQuery] string role)
    {
        if (role != "Admin") return Unauthorized("Only admin can delete shipments");
        var shipment = _context.Shipments.Find(id);
        if (shipment == null) return NotFound("Shipment Not Found!");

        _context.Shipments.Remove(shipment);
        _context.SaveChanges();
        return Ok("Deleted");
    }
}
