using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

using CatalogServices.Data;


using CatalogServices.Model;

namespace CatalogServices.Controllers

{

    [Route("api/[controller]")]

    [ApiController]

    public class CatalogController : ControllerBase

    {

        private readonly AppDbContext _Context;

        public CatalogController(AppDbContext context)

        {

            _Context = context;

        }

        //Get: api/

        [HttpGet]

        public async Task<IActionResult> GetAll()

        {

            var catalogs = await _Context.Catalogs.ToListAsync();

            return Ok(catalogs);

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)

        {

            var catalog = await _Context.Catalogs.FindAsync(id);

            if (catalog == null) return NotFound();

            else return Ok(catalog);

        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] Catalog catalog)

        {

            _Context.Catalogs.Add(catalog);

            await _Context.SaveChangesAsync();

            return CreatedAtAction(nameof(Create), catalog);

        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, [FromBody] Catalog catalog)

        {

            var existingCatalog = await _Context.Catalogs.FindAsync(id);

            if (existingCatalog == null) return NotFound();

            existingCatalog.Name = catalog.Name;

            existingCatalog.Description = catalog.Description;

            await _Context.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)

        {

            var catalog = await _Context.Catalogs.FindAsync(id);

            if (catalog == null) return NotFound();

            _Context.Catalogs.Remove(catalog);

            await _Context.SaveChangesAsync();

            return NoContent();

        }


    }

}

