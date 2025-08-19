using System.Text.Json;
using ProductManager.Models;

namespace ProductManager.Services
{
    public class ProductService
    {
        private readonly string _filePath = "Data/db.json";

        public List<Product> GetAll()
        {
            if (!File.Exists(_filePath)) return new List<Product>();
            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
        }

        public void SaveAll(List<Product> products)
        {
            var json = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        public Product? GetById(int id) => GetAll().FirstOrDefault(p => p.Id == id);

        public void Add(Product product)
        {
            var products = GetAll();
            product.Id = products.Any() ? products.Max(p => p.Id) + 1 : 1;
            products.Add(product);
            SaveAll(products);
        }

        public void Update(Product product)
        {
            var products = GetAll();
            var index = products.FindIndex(p => p.Id == product.Id);
            if (index != -1)
            {
                products[index] = product;
                SaveAll(products);
            }
        }

        public void Delete(int id)
        {
            var products = GetAll();
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                products.Remove(product);
                SaveAll(products);
            }
        }
    }

}
