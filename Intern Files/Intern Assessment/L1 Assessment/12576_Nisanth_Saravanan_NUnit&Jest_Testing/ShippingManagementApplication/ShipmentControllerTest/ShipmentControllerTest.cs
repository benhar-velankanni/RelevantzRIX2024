using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShipmentManagementWebApi.Data;
using ShipmentManagementWebApi.Models;

namespace ShipmentControllerTest
{
    [TestFixture]
    public class ShipmentControllerTest
    {
        private AppDbContext _context;
        private ShipmentController _controller;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("TestDb")
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
        public void GetAll_ReturnsAllShipment()
        {
            //Arrange
            var shipment = new Shipment
            {
                Id = 1,
                Name = "Box A",
                Type = "Electronics",
                Address = "123 Avenue"
            };
            _context.Shipments.Add(shipment);
            _context.SaveChanges();

            //Act
            var result = _controller.GetAll() as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);
            Assert.IsNotNull(result.Value);
            Assert.IsInstanceOf<List<Shipment>>(result.Value);
            Assert.AreEqual(1, ((List<Shipment>)result.Value).Count);
        }

        [Test]
        public void GetById_ExistingId_ReturnsShipment()
        {
            //Arrange
            var shipment = new Shipment
            {
                Id = 1,
                Name = "Box A",
                Type = "Electronics",
                Address = "123 Avenue"
            };
            _context.Shipments.Add(shipment);
            _context.SaveChanges();

            //Act
            var result = _controller.Get(1) as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);
            Assert.IsNotNull(result.Value);
            Assert.IsInstanceOf<Shipment>(result.Value);
            Assert.AreEqual(shipment, result.Value);
        }

        [Test]
        public void GetById_NonExistingId_ReturnsNotFound()
        {
            //Act
            var result = _controller.Get(1) as NotFoundObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<NotFoundObjectResult>(result);
            Assert.IsNotNull(result.Value);
            Assert.IsInstanceOf<String>(result.Value);
            Assert.AreEqual("Shipment Not Found!", result.Value);
        }

        [Test]
        public void Create_AdminRole_ReturnsShipment()
        {
            //Arrange
            var shipment = new Shipment
            {
                Id = 1,
                Name = "Box A",
                Type = "Electronics",
                Address = "123 Avenue"
            };

            //Act
            var result = _controller.Create(shipment, "Admin") as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);
            Assert.IsNotNull(result.Value);
            Assert.IsInstanceOf<Shipment>(result.Value);
            Assert.AreEqual(shipment, result.Value);
        }

        [Test]
        public void Create_NonAdminRole_ReturnUnauthorized()
        {
            //Arrange
            var shipment = new Shipment
            {
                Id = 1,
                Name = "Box A",
                Type = "Electronics",
                Address = "123 Avenue"
            };

            //Act
            var result = _controller.Create(shipment, "User") as UnauthorizedObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<UnauthorizedObjectResult>(result);
            Assert.IsNotNull(result.Value);
            Assert.IsInstanceOf<String>(result.Value);
            Assert.AreEqual("Only admin can create shipments", result.Value);
        }

        [Test]
        public void Update_AdminRole_ReturnsOk()
        {
            //Arrange
            var shipment = new Shipment
            {
                Id = 1,
                Name = "Box A",
                Type = "Electronics",
                Address = "123 Avenue"
            };
            _context.Shipments.Add(shipment);
            _context.SaveChanges();

            var updatedShipment = new Shipment
            {
                Id = 1,
                Name = "Box A",
                Type = "Misc",
                Address = "123 Avenue"
            };

            //Act
            var result = _controller.Update(1, updatedShipment, "Admin") as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);
            Assert.IsNotNull(result.Value);
            Assert.IsInstanceOf<Shipment>(result.Value);
            var resultingShipment = result.Value as Shipment;
            Assert.AreEqual(updatedShipment.Type, resultingShipment.Type);
        }

        [Test]
        public void Update_NonAdminRole_ReturnsUnauthorized()
        {
            //Arrange
            var shipment = new Shipment
            {
                Id = 1,
                Name = "Box A",
                Type = "Electronics",
                Address = "123 Avenue"
            };
            _context.Shipments.Add(shipment);
            _context.SaveChanges();

            var updatedShipment = new Shipment
            {
                Id = 1,
                Name = "Box A",
                Type = "Misc",
                Address = "123 Avenue"
            };

            //Act
            var result = _controller.Update(1, updatedShipment, "User") as UnauthorizedObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<UnauthorizedObjectResult>(result);
            Assert.IsNotNull(result.Value);
            Assert.IsInstanceOf<String>(result.Value);
            Assert.AreEqual("Only admin can update shipments", result.Value);
        }

        [Test]
        public void Update_AdminRole_NonExistingId_ReturnsNotFound()
        {
            //Arrange
            var updatedShipment = new Shipment
            {
                Id = 1,
                Name = "Box A",
                Type = "Misc",
                Address = "123 Avenue"
            };

            //Act
            var result = _controller.Update(1, updatedShipment, "Admin") as NotFoundObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<NotFoundObjectResult>(result);
            Assert.IsNotNull(result.Value);
            Assert.IsInstanceOf<String>(result.Value);
            Assert.AreEqual("Shipment Not Found!", result.Value);
        }

        [Test]
        public void Delete_AdminRole_ReturnsOk()
        {
            //Arrange
            var shipment = new Shipment
            {
                Id = 1,
                Name = "Box A",
                Type = "Electronics",
                Address = "123 Avenue"
            };
            _context.Shipments.Add(shipment);
            _context.SaveChanges();

            //Act
            var result = _controller.Delete(1, "Admin") as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);
            Assert.IsNotNull(result.Value);
            Assert.IsInstanceOf<String>(result.Value);
            Assert.AreEqual("Deleted", result.Value);
        }

        [Test]
        public void Delete_NonAdminRole_ReturnsUnauthorized()
        {
            //Arrange
            var shipment = new Shipment
            {
                Id = 1,
                Name = "Box A",
                Type = "Electronics",
                Address = "123 Avenue"
            };
            _context.Shipments.Add(shipment);
            _context.SaveChanges();

            //Act
            var result = _controller.Delete(1, "User") as UnauthorizedObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<UnauthorizedObjectResult>(result);
            Assert.IsNotNull(result.Value);
            Assert.IsInstanceOf<String>(result.Value);
            Assert.AreEqual("Only admin can delete shipments", result.Value);
        }

        [Test]
        public void Delete_AdminRole_NonExistingId_ReturnsNotFound()
        {
            //Act
            var result = _controller.Delete(1, "Admin") as NotFoundObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<NotFoundObjectResult>(result);
            Assert.IsNotNull(result.Value);
            Assert.IsInstanceOf<String>(result.Value);
            Assert.AreEqual("Shipment Not Found!", result.Value);
        }

    }
}
