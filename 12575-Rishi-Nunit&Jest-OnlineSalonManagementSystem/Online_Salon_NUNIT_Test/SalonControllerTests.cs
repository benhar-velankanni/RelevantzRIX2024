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
    public class SalonControllerTests
    {
        private OnlineSalonManagementDbContext _context;
        private SalonController _controller;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<OnlineSalonManagementDbContext>()
                .UseInMemoryDatabase(databaseName: "SalonTestDb")
                .Options;

            _context = new OnlineSalonManagementDbContext(options);
            _controller = new SalonController(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
            _controller.Dispose();
        }

        [Test]
        public async Task Index_ReturnsViewWithSalons()
        {
            var result = await _controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<Salon>>(result.Model);
        }

        [Test]
        public async Task Details_NonExistingId_ReturnsNotFound()
        {
            var result = await _controller.Details(999);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task Create_ValidSalon_AddsSalon()
        {
            var salon = new Salon { Id = 2, Name = "Salon A", Address = "123 Main St", Phone = "1234567890", Email = "salon@example.com", Website = "www.salon.com" };

            var result = await _controller.Create(salon) as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual(1, _context.Salons.Count());
        }

        [Test]
        public async Task Create_InvalidSalon_ReturnsView()
        {
            _controller.ModelState.AddModelError("Name", "Required");

            var salon = new Salon { Address = "123 Main St", Phone = "1234567890", Email = "salon@example.com", Website = "www.salon.com" };

            var result = await _controller.Create(salon) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public async Task Edit_Get_ExistingId_ReturnsSalon()
        {
            var salon = new Salon { Id = 1, Name = "Salon B", Address = "456 Main St", Phone = "0987654321", Email = "salonb@example.com", Website = "www.salonb.com" };
            _context.Salons.Add(salon);
            _context.SaveChanges();

            var result = await _controller.Edit(1) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(salon.Id, ((Salon)result.Model).Id);
        }
        [Test]
        public async Task Edit_Get_ExistingId_ReturnsSalon1()
        {
            var salon = new Salon { Id = 1, Name = "Salon C", Address = "456 Main St", Phone = "0987654321", Email = "salonb@example.com", Website = "www.salonb.com" };
            _context.Salons.Add(salon);
            _context.SaveChanges();

            var result = await _controller.Edit(1) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(salon.Id, ((Salon)result.Model).Id);
        }
        [Test]
        public async Task Edit_Get_NonExistingId_ReturnsNotFound()
        {
            var result = await _controller.Edit(999);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task Edit_Post_ValidSalon_UpdatesSalon()
        {
            var salon = new Salon { Id = 1, Name = "OldName", Address = "123 Main St", Phone = "1234567890", Email = "old@example.com", Website = "www.old.com" };
            _context.Salons.Add(salon);
            _context.SaveChanges();

            // Detach the tracked entity to avoid conflict
            _context.Entry(salon).State = EntityState.Detached;

            var updated = new Salon { Id = 1, Name = "NewName", Address = "456 Main St", Phone = "0987654321", Email = "new@example.com", Website = "www.new.com" };

            var result = await _controller.Edit(1, updated) as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("NewName", _context.Salons.Find(1)?.Name);
        }

        [Test]
        public async Task Edit_Post_IdMismatch_ReturnsNotFound()
        {
            var salon = new Salon { Id = 1, Name = "Mismatch", Address = "789 Main St", Phone = "1231231234", Email = "mismatch@example.com", Website = "www.mismatch.com" };

            var result = await _controller.Edit(2, salon);

            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task Delete_Get_NonExistingId_ReturnsNotFound()
        {
            var result = await _controller.Delete(999);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task DeleteConfirmed_ExistingId_DeletesSalon()
        {
            var salon = new Salon { Id = 1, Name = "DeleteMe", Address = "123 Main St", Phone = "1234567890", Email = "delete@example.com", Website = "www.delete.com" };
            _context.Salons.Add(salon);
            _context.SaveChanges();

            var result = await _controller.DeleteConfirmed(1) as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual(0, _context.Salons.Count());
        }
    }
}

