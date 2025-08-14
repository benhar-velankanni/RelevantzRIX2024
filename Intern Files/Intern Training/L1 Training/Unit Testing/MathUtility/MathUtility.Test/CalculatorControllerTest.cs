using MathUtility.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace MathUtility.Test
{
    [TestFixture]
    public class CalculatorControllerTests
    {
        private CalculatorController _calculatorController;

        [SetUp]
        public void Setup()
        {
            _calculatorController = new CalculatorController();
        }

        [TestCase(10, 20, 30)]
        [TestCase(-5, 5, 0)]
        [TestCase(0, 0, 0)]
        public void Add_Returns_Correct_Result(int a, int b, int expected)
        {
            var result = _calculatorController.Add(a, b) as OkObjectResult;
            Assert.That(result.Value, Is.EqualTo(expected));
        }

        [TestCase(30, 20, 10)]
        [TestCase(5, 10, -5)]
        [TestCase(0, 0, 0)]
        public void Subtract_Returns_Correct_Result(int a, int b, int expected)
        {
            var result = _calculatorController.Subtract(a, b) as OkObjectResult;
            Assert.That(result.Value, Is.EqualTo(expected));
        }

        [TestCase(10, 20, 200)]
        [TestCase(0, 5, 0)]
        [TestCase(-2, 3, -6)]
        public void Multiply_Returns_Correct_Result(int a, int b, int expected)
        {
            var result = _calculatorController.Multiply(a, b) as OkObjectResult;
            Assert.That(result.Value, Is.EqualTo(expected));
        }

        [TestCase(20, 10, 2)]
        [TestCase(9, 3, 3)]
        [TestCase(-6, -2, 3)]
        public void Divide_Returns_Correct_Result(int a, int b, int expected)
        {
            var result = _calculatorController.Divide(a, b) as OkObjectResult;
            Assert.That(result.Value, Is.EqualTo(expected));
        }

        [TestCase(20, 0)]
        [TestCase(0, 0)]
        public void Divide_ByZero_Returns_BadRequest(int a, int b)
        {
            var result = _calculatorController.Divide(a, b) as BadRequestObjectResult;
            Assert.That(result.Value, Is.EqualTo("No divide by zero."));
        }

        [TearDown]
        public void TearDown()
        {
            _calculatorController.Dispose();
        }
    }
}
