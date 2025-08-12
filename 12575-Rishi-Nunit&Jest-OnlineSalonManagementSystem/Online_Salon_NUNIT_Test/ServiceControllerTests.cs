using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineSalonManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace OnlineSalonManagementSystem.Controllers
{
    public class ServiceControllerTests
    {
        private OnlineSalonManagementDbContext _context;
        private ServiceController _controller;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<OnlineSalonManagementDbContext>()
                .UseInMemoryDatabase(databaseName: "ServiceTestDb")
                .Options;

            _context = new OnlineSalonManagementDbContext(options);
            _controller = new ServiceController(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
            _controller.Dispose();
        }

        [Test]
        public async Task Index_ReturnsViewWithServices()
        {
            var result = await _controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<Service>>(result.Model);
        }

        [Test]
        public async Task Details_NonExistingId_ReturnsNotFound()
        {
            var result = await _controller.Details(999);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task Create_ValidService_AddsService()
        {
            var service = new Service { Id = 2, Name = "Service A", Description = "This is service A", Price = 10.99m, SalonId = 1 };

            var result = await _controller.Create(service) as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual(1, _context.Services.Count());
        }

        [Test]
        public async Task Create_InvalidService_ReturnsView()
        {
            _controller.ModelState.AddModelError("Name", "Required");

            var service = new Service { Description = "This is service A", Price = 10.99m, SalonId = 1 };

            var result = await _controller.Create(service) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public async Task Edit_Get_ExistingId_ReturnsService()
        {
            var service = new Service { Id = 1, Name = "Service B", Description = "This is service B", Price = 20.99m, SalonId = 1 };
            _context.Services.Add(service);
            _context.SaveChanges();

            var result = await _controller.Edit(1) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(service.Id, ((Service)result.Model).Id);
        }
        [Test]
        public async Task Edit_Get_ExistingId_ReturnsService1()
        {
            var service = new Service { Id = 1, Name = "Service C", Description = "This is service C", Price = 20.99m, SalonId = 1 };
            _context.Services.Add(service);
            _context.SaveChanges();

            var result = await _controller.Edit(1) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(service.Id, ((Service)result.Model).Id);
        }
        [Test]
        public async Task Edit_Get_ExistingId_ReturnsService2()
        {
            var service = new Service { Id = 1, Name = "Service D", Description = "This is service D", Price = 20.99m, SalonId = 1 };
            _context.Services.Add(service);
            _context.SaveChanges();

            var result = await _controller.Edit(1) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(service.Id, ((Service)result.Model).Id);
        }

        [Test]
        public async Task Edit_Get_NonExistingId_ReturnsNotFound()
        {
            var result = await _controller.Edit(999);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task Edit_Post_ValidService_UpdatesService()
        {
            var service = new Service { Id = 1, Name = "OldName", Description = "This is service A", Price = 10.99m, SalonId = 1 };
            _context.Services.Add(service);
            _context.SaveChanges();

            // Detach the tracked entity to avoid conflict
            _context.Entry(service).State = EntityState.Detached;

            var updated = new Service { Id = 1, Name = "NewName", Description = "This is service A", Price = 10.99m, SalonId = 1 };

            var result = await _controller.Edit(1, updated) as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("NewName", _context.Services.Find(1)?.Name);
        }

        [Test]
        public async Task Edit_Post_IdMismatch_ReturnsNotFound()
        {
            var service = new Service { Id = 1, Name = "Mismatch", Description = "This is service A", Price = 10.99m, SalonId = 1 };

            var result = await _controller.Edit(2, service);

            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task Delete_Get_NonExistingId_ReturnsNotFound()
        {
            var result = await _controller.Delete(999);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task DeleteConfirmed_ExistingId_DeletesService()
        {
            var service = new Service { Id = 1, Name = "DeleteMe", Description = "This is service A", Price = 10.99m, SalonId = 1 };
            _context.Services.Add(service);
            _context.SaveChanges();

            var result = await _controller.DeleteConfirmed(1) as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual(0, _context.Services.Count());
        }
    }
}

