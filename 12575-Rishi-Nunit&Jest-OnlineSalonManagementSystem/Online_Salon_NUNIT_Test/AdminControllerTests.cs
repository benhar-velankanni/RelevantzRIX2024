using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineSalonManagementSystem.Controllers;
using OnlineSalonManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace OnlineSalonManagementSystem.Tests
{
    [TestFixture]
    public class AdminLogControllerTests
    {
        private OnlineSalonManagementDbContext _context;
        private AdminLogController _controller;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<OnlineSalonManagementDbContext>()
                .UseInMemoryDatabase(databaseName: "AdminLogTestDb")
                .Options;

            _context = new OnlineSalonManagementDbContext(options);
            _controller = new AdminLogController(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
             _controller.Dispose();
        }

        [Test]
        public async Task Register_ValidAdminLog_CreatesUser()
        {
            var adminLog = new AdminLog { Id = 1, Name = "Admin", Email = "admin@example.com", Password = "password" };

            var result = await _controller.Register(adminLog) as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Login", result.ActionName);
            Assert.AreEqual(1, _context.AdminLogs.Count());
        }

        [Test]
        public async Task Register_InvalidAdminLog_ReturnsView()
        {
            _controller.ModelState.AddModelError("Name", "Required");

            var adminLog = new AdminLog { Email = "invalid@example.com", Password = "password" };

            var result = await _controller.Register(adminLog) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
        }



        [Test]
        public async Task Login_InvalidCredentials_ReturnsView()
        {
            var adminLog = new AdminLog { Email = "invalid@example.com", Password = "wrongpassword" };

            var result = await _controller.Login(adminLog) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
        }



        [Test]
        public async Task Index_ReturnsAllAdminLogs()
        {
            _context.AdminLogs.Add(new AdminLog { Id = 1, Name = "Admin", Email = "admin@example.com", Password = "password" });
            _context.SaveChanges();

            var result = await _controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<AdminLog>>(result.Model);
            Assert.AreEqual(1, ((List<AdminLog>)result.Model).Count);
        }
    }
}

