using CustomerService.Data;
using CustomerService.Model;
using CustomerService.Unit_of_Work.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CustomerService.Unit_of_Work.Repository.Implementation
{
    public class Repository1(AppDbContext context) : IRepository
    {
        private readonly AppDbContext _context = context;
        public async Task AddData(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
        }

        public async Task DeleteData(int id)
        {
            var customerD = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customerD);
        }

        public async Task<List<Customer>> GetAllData()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetDatabyId(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(q => q.Id.Equals(id));
        }

        public async Task UpdateData(Customer customer,int id)
        {
            var existing = await _context.Customers.FirstOrDefaultAsync(q => q.Id.Equals(id));
            existing.CustomerName = customer.CustomerName;
            existing.CustomerEmail = customer.CustomerEmail;
        }

        
    }
}
