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
    public class InventoryControllerTests
    {
        private OnlineSalonManagementDbContext _context;
        private InventoryController _controller;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<OnlineSalonManagementDbContext>()
                .UseInMemoryDatabase(databaseName: "InventoryTestDb")
                .Options;

            _context = new OnlineSalonManagementDbContext(options);
            _controller = new InventoryController(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
            _controller.Dispose();
        }





        [Test]
        public async Task Details_NonExistingId_ReturnsNotFound()
        {
            var result = await _controller.Details(999);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task Create_ValidInventory_AddsInventory()
        {
            var inventory = new Inventory { Id = 2, Name = "Conditioner", Quantity = 5, SalonId = 1 };

            var result = await _controller.Create(inventory) as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual(1, _context.Inventories.Count());
        }

        [Test]
        public async Task Create_InvalidInventory_ReturnsView()
        {
            _controller.ModelState.AddModelError("Name", "Required");

            var inventory = new Inventory { Quantity = 5, SalonId = 1 };

            var result = await _controller.Create(inventory) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public async Task Edit_Get_ExistingId_ReturnsInventory()
        {
            var inventory = new Inventory { Id = 1, Name = "Shampoo", Quantity = 10, SalonId = 1 };
            _context.Inventories.Add(inventory);
            _context.SaveChanges();

            var result = await _controller.Edit(1) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(inventory.Id, ((Inventory)result.Model).Id);
        }
        [Test]
        public async Task Edit_Get_ExistingId_ReturnsInventory2()
        {
            var inventory = new Inventory { Id = 1, Name = "Soap", Quantity = 16, SalonId = 1 };
            _context.Inventories.Add(inventory);
            _context.SaveChanges();

            var result = await _controller.Edit(1) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(inventory.Id, ((Inventory)result.Model).Id);
        }
        [Test]
        public async Task Edit_Get_ExistingId_ReturnsInventory3()
        {
            var inventory = new Inventory { Id = 1, Name = "clip", Quantity = 40, SalonId = 1 };
            _context.Inventories.Add(inventory);
            _context.SaveChanges();

            var result = await _controller.Edit(1) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(inventory.Id, ((Inventory)result.Model).Id);
        }

        [Test]
        public async Task Edit_Get_NonExistingId_ReturnsNotFound()
        {
            var result = await _controller.Edit(999);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task Edit_Post_ValidInventory_UpdatesInventory()
        {
            var inventory = new Inventory { Id = 1, Name = "OldName", Quantity = 10, SalonId = 1 };
            _context.Inventories.Add(inventory);
            _context.SaveChanges();

            // Detach the tracked entity to avoid conflict
            _context.Entry(inventory).State = EntityState.Detached;

            var updated = new Inventory { Id = 1, Name = "NewName", Quantity = 15, SalonId = 1 };

            var result = await _controller.Edit(1, updated) as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("NewName", _context.Inventories.Find(1)?.Name);
        }

        [Test]
        public async Task Edit_Post_IdMismatch_ReturnsNotFound()
        {
            var inventory = new Inventory { Id = 1, Name = "Mismatch", Quantity = 10, SalonId = 1 };

            var result = await _controller.Edit(2, inventory);

            Assert.IsInstanceOf<NotFoundResult>(result);
        }



        [Test]
        public async Task Delete_Get_NonExistingId_ReturnsNotFound()
        {
            var result = await _controller.Delete(999);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task DeleteConfirmed_ExistingId_DeletesInventory()
        {
            var inventory = new Inventory { Id = 1, Name = "DeleteMe", Quantity = 10, SalonId = 1 };
            _context.Inventories.Add(inventory);
            _context.SaveChanges();

            var result = await _controller.DeleteConfirmed(1) as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual(0, _context.Inventories.Count());
        }
    }
}

