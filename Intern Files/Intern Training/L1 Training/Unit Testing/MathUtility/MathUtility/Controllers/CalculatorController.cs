using Microsoft.AspNetCore.Mvc;

namespace MathUtility.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add(int a , int b)
        {
            int result = a + b;
            return Ok(result);
        }

        public IActionResult Subtract(int a, int b)
        {
            int result = a - b;
            return Ok(result);
        }

        public IActionResult Multiply(int a, int b)
        {
            int result = a * b;
            return Ok(result);
        }

        public IActionResult Divide(int a, int b)
        {
            if(b == 0) return BadRequest("No divide by zero.");
            int result = a / b;
            return Ok(result);
        }
    }
}
