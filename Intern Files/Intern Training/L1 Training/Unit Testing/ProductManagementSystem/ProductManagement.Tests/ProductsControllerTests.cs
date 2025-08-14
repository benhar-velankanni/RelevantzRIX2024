using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ProductmangementSystem.Controllers;
using ProductmangementSystem.Data;
using ProductmangementSystem.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagement.Tests.Controllers
{
    [TestFixture]
    public class ProductsControllerTests
    {
        private ProductsController _controller;
        private ApplicationDbContext _context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(options);
            _context.Products.AddRange(
                new Product { Id = 1, Name = "Product A", Price = 100 },
                new Product { Id = 2, Name = "Product B", Price = 200 }
            );
            _context.SaveChanges();

            _controller = new ProductsController(_context);

        }

        [Test]
        public async Task Index_ReturnsViewWithProductList()
        {
            var result = await _controller.Index();
            Assert.That(result, Is.TypeOf<ViewResult>());
            var view = result as ViewResult;
            Assert.That(view.Model, Is.TypeOf<List<Product>>());
        }

        [Test]
        public async Task Details_ProductFound_ReturnsViewWithProduct()
        {
            var result = await _controller.Details(1);
            Assert.That(result, Is.TypeOf<ViewResult>());
            var view = result as ViewResult;
            Assert.That(view.Model, Is.TypeOf<Product>());
            var product = view.Model as Product;
            Assert.That(product.Id, Is.EqualTo(1));
        }

        [Test]
        public async Task Create_ValidProduct_ReturnsRedirectToAction()
        {
            var product = new Product { Id = 3, Name = "New Product", Price = 300 };
            var result = await _controller.Create(product);
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            Assert.That(_context.Products.Find(3), Is.Not.Null);
        }

        [Test]
        public async Task Edit_ProductFound_ReturnsViewWithProduct()
        {
            var result = await _controller.Edit(1);
            Assert.That(result, Is.TypeOf<ViewResult>());
            var view = result as ViewResult;
            Assert.That(view.Model, Is.TypeOf<Product>());
        }

        [Test]
        public async Task DeleteConfirmed_ValidId_RemovesProduct()
        {
            var result = await _controller.DeleteConfirmed(1);
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            Assert.That(_context.Products.Find(1), Is.Null);
        }
    }
}
