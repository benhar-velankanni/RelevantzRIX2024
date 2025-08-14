using CustomerService.Model;
using CustomerService.Unit_of_Work;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerServiceController(IUnitofWork unitwork) : ControllerBase
    {
        private readonly IUnitofWork _unitwork = unitwork;

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _unitwork.repository.GetAllData());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            return Ok(await _unitwork.repository.GetDatabyId(id));
        }
        [HttpPost]
        public async Task<IActionResult> InsertO(Customer customer){
            await _unitwork.repository.AddData(customer);
            await _unitwork.SaveData();
            return CreatedAtAction(nameof(GetbyId),new {id=customer.Id},customer);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateO(int id, Customer customer)
        {
            await _unitwork.repository.UpdateData(customer,id);
            await _unitwork.SaveData();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteD(int id)
        {
            var existing = await _unitwork.repository.GetDatabyId(id);
            await _unitwork.repository.DeleteData(id);
            await _unitwork.SaveData();
            return NoContent();
        }
    }
}
