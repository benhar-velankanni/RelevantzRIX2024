using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StorageConnectorService.Data;
using StorageConnectorService.Model;

namespace StorageConnectorService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageConnectorsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public StorageConnectorsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/StorageConnectors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StorageConnector>>> GetStorageConnectors()
        {
            return await _context.StorageConnectors.ToListAsync();
        }

        // GET: api/StorageConnectors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StorageConnector>> GetStorageConnector(int id)
        {
            var storageConnector = await _context.StorageConnectors.FindAsync(id);

            if (storageConnector == null)
            {
                return NotFound();
            }

            return storageConnector;
        }

        // PUT: api/StorageConnectors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStorageConnector(int id, StorageConnector storageConnector)
        {
            if (id != storageConnector.StorageConnectorId)
            {
                return BadRequest();
            }

            _context.Entry(storageConnector).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StorageConnectorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StorageConnectors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StorageConnector>> PostStorageConnector(StorageConnector storageConnector)
        {
            _context.StorageConnectors.Add(storageConnector);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStorageConnector", new { id = storageConnector.StorageConnectorId }, storageConnector);
        }

        // DELETE: api/StorageConnectors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStorageConnector(int id)
        {
            var storageConnector = await _context.StorageConnectors.FindAsync(id);
            if (storageConnector == null)
            {
                return NotFound();
            }

            _context.StorageConnectors.Remove(storageConnector);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StorageConnectorExists(int id)
        {
            return _context.StorageConnectors.Any(e => e.StorageConnectorId == id);
        }
    }
}
