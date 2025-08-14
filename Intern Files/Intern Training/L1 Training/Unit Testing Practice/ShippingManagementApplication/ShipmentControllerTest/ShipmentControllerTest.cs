//NUnit Controller Tester
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShipmentManagementWebApi.Data;
using ShipmentManagementWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShipmentManagementWebApi.Tests
{
    [TestFixture]
    public class ShipmentControllerTests
    {
        private AppDbContext _context;
        private ShipmentController _controller;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _context = new AppDbContext(options);
            _controller = new ShipmentController(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Test]
        public void GetAll_ReturnsAllShipments()
        {
            _context.Shipments.Add(new Shipment { Id = 1, Name = "Test", Type = "Air", Address = "Chennai" });
            _context.SaveChanges();

            var result = _controller.GetAll() as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);
            Assert.IsInstanceOf<List<Shipment>>(result.Value);
            Assert.AreEqual(1, ((List<Shipment>)result.Value).Count);
        }

        [Test]
        public void Get_ExistingId_ReturnsShipment()
        {
            var shipment = new Shipment { Id = 1, Name = "Test", Type = "Air", Address = "Chennai" };
            _context.Shipments.Add(shipment);
            _context.SaveChanges();

            var result = _controller.Get(1) as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(shipment, result.Value);
        }

        [Test]
        public void Get_NonExistingId_ReturnsNotFound()
        {
            var result = _controller.Get(999);

            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Create_AdminRole_AddsShipment()
        {
            var shipment = new Shipment { Id = 1, Name = "New", Type = "Sea", Address = "Mumbai" };

            var result = _controller.Create(shipment, "Admin") as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(shipment, result.Value);
            Assert.AreEqual(1, _context.Shipments.Count());
        }

        [Test]
        public void Create_NonAdminRole_ReturnsUnauthorized()
        {
            var shipment = new Shipment { Id = 1, Name = "New", Type = "Sea", Address = "Mumbai" };

            var result = _controller.Create(shipment, "User") as UnauthorizedObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Only admin can create shipments", result.Value);
        }

        [Test]
        public void Update_AdminRole_ExistingId_UpdatesShipment()
        {
            var shipment = new Shipment { Id = 1, Name = "Old", Type = "Air", Address = "Delhi" };
            _context.Shipments.Add(shipment);
            _context.SaveChanges();

            var updated = new Shipment { Name = "Updated", Type = "Sea", Address = "Mumbai" };

            var result = _controller.Update(1, updated, "Admin") as OkObjectResult;

            Assert.IsNotNull(result);
            var updatedShipment = result.Value as Shipment;
            Assert.AreEqual("Updated", updatedShipment.Name);
        }

        [Test]
        public void Update_NonAdminRole_ReturnsUnauthorized()
        {
            var updated = new Shipment { Name = "Updated", Type = "Sea", Address = "Mumbai" };

            var result = _controller.Update(1, updated, "User");

            Assert.IsInstanceOf<UnauthorizedObjectResult>(result);
        }

        [Test]
        public void Update_AdminRole_NonExistingId_ReturnsNotFound()
        {
            var updated = new Shipment { Name = "Updated", Type = "Sea", Address = "Mumbai" };

            var result = _controller.Update(999, updated, "Admin");

            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Delete_AdminRole_ExistingId_DeletesShipment()
        {
            var shipment = new Shipment { Id = 1, Name = "DeleteMe", Type = "Air", Address = "Delhi" };
            _context.Shipments.Add(shipment);
            _context.SaveChanges();

            var result = _controller.Delete(1, "Admin") as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Deleted", result.Value);
            Assert.AreEqual(0, _context.Shipments.Count());
        }

        [Test]
        public void Delete_NonAdminRole_ReturnsUnauthorized()
        {
            var result = _controller.Delete(1, "User");

            Assert.IsInstanceOf<UnauthorizedObjectResult>(result);
        }

        [Test]
        public void Delete_AdminRole_NonExistingId_ReturnsNotFound()
        {
            var result = _controller.Delete(999, "Admin");

            Assert.IsInstanceOf<NotFoundResult>(result);
        }
    }
}
