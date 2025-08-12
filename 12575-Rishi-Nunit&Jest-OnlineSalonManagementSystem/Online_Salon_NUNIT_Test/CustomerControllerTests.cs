using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineSalonManagementSystem.Controllers;
using OnlineSalonManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineSalonManagementSystem.Tests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        private OnlineSalonManagementDbContext _context;
        private CustomerController _controller;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<OnlineSalonManagementDbContext>()
                .UseInMemoryDatabase(databaseName: "CustomerTestDb")
                .Options;

            _context = new OnlineSalonManagementDbContext(options);
            _controller = new CustomerController(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
            _controller.Dispose();
        }

        [Test]
        public async Task Index_ReturnsAllCustomers()
        {
            _context.Customers.Add(new Customer { Id = 1, Name = "Alice", Email = "alice@example.com", Phone = "1234567890" });
            _context.SaveChanges();

            var result = await _controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<Customer>>(result.Model);
            Assert.AreEqual(1, ((List<Customer>)result.Model).Count);
        }

        [Test]
        public async Task Details_ExistingId_ReturnsCustomer()
        {
            var customer = new Customer { Id = 1, Name = "Alice", Email = "alice@example.com", Phone = "1234567890" };
            _context.Customers.Add(customer);
            _context.SaveChanges();

            var result = await _controller.Details(1) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(customer, result.Model);
        }

        [Test]
        public async Task Details_NonExistingId_ReturnsNotFound()
        {
            var result = await _controller.Details(999);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task Create_ValidCustomer_AddsCustomer()
        {
            var customer = new Customer { Id = 2, Name = "Bob", Email = "bob@example.com", Phone = "9876543210" };

            var result = await _controller.Create(customer) as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual(1, _context.Customers.Count());
        }

        [Test]
        public async Task Create_InvalidCustomer_ReturnsView()
        {
            _controller.ModelState.AddModelError("Name", "Required");

            var customer = new Customer { Email = "invalid@example.com", Phone = "1234567890" };

            var result = await _controller.Create(customer) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public async Task Edit_Get_ExistingId_ReturnsCustomer()
        {
            var customer = new Customer { Id = 1, Name = "Alice", Email = "alice@example.com", Phone = "1234567890" };
            _context.Customers.Add(customer);
            _context.SaveChanges();

            var result = await _controller.Edit(1) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(customer.Id, ((Customer)result.Model).Id);
        }

        [Test]
        public async Task Edit_Get_NonExistingId_ReturnsNotFound()
        {
            var result = await _controller.Edit(999);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task Edit_Post_ValidCustomer_UpdatesCustomer()
        {
            var customer = new Customer { Id = 1, Name = "Old", Email = "old@example.com", Phone = "1111111111" };
            _context.Customers.Add(customer);
            _context.SaveChanges();

            // Detach the tracked entity to avoid conflict
            _context.Entry(customer).State = EntityState.Detached;

            var updated = new Customer { Id = 1, Name = "Updated", Email = "new@example.com", Phone = "2222222222" };

            var result = await _controller.Edit(1, updated) as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Updated", _context.Customers.Find(1)?.Name);
        }

        [Test]
        public async Task Edit_Post_IdMismatch_ReturnsNotFound()
        {
            var customer = new Customer { Id = 1, Name = "Mismatch", Email = "mismatch@example.com", Phone = "0000000000" };

            var result = await _controller.Edit(2, customer);

            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task Delete_Get_ExistingId_ReturnsCustomer()
        {
            var customer = new Customer { Id = 1, Name = "DeleteMe", Email = "delete@example.com", Phone = "9999999999" };
            _context.Customers.Add(customer);
            _context.SaveChanges();

            var result = await _controller.Delete(1) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(customer.Id, ((Customer)result.Model).Id);
        }

        [Test]
        public async Task Delete_Get_NonExistingId_ReturnsNotFound()
        {
            var result = await _controller.Delete(999);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task DeleteConfirmed_ExistingId_DeletesCustomer()
        {
            var customer = new Customer { Id = 1, Name = "DeleteMe", Email = "delete@example.com", Phone = "9999999999" };
            _context.Customers.Add(customer);
            _context.SaveChanges();

            var result = await _controller.DeleteConfirmed(1) as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual(0, _context.Customers.Count());
        }
    }
}
