using Microsoft.AspNetCore.Mvc;
using MyProductWebAPI.Repository;
using MyProductWebAPI.Model;

namespace MyProductWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductDBController : ControllerBase
    {
        private readonly IProductRepository _repository;
        public ProductDBController(IProductRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var products = _repository.GetAllProducts();
            return Ok(products);
        }
        [HttpPost]
        public ActionResult<Product> AddProduct([FromBody] Product product)
        {
            if (product == null || string.IsNullOrEmpty(product.Name) || product.Price <= 0)
            {
                return BadRequest("Product cannot be null.");
            }
            _repository.AddProduct(product);
            return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);
        }
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _repository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPut("{id}")]
        public ActionResult<Product> Update(int id, Product updatedproduct)
        {
            if (updatedproduct == null || string.IsNullOrEmpty(updatedproduct.Name) || updatedproduct.Price <= 0)
            {
                return BadRequest("Invalid product data");
            }
            var existingproduct = _repository.GetProductById(id);
            if (existingproduct == null)
            {
                return NotFound();
            }
            existingproduct.Name = updatedproduct.Name;
            existingproduct.Price = updatedproduct.Price;
            existingproduct.Description = updatedproduct.Description;
            _repository.UpdateProduct(existingproduct);
            return Ok(existingproduct);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var product = _repository.GetProductById(id);
            if (product == null)
            {
                return NotFound("Product not found");
            }
            _repository.DeleteProduct(id);
            return NoContent();
        }
    }
}