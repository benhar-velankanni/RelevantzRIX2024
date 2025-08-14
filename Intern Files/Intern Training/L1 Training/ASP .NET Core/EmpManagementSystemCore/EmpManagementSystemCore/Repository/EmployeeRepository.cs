using EmpManagementSystemCore.Data;
using EmpManagementSystemCore.Entity;
using Microsoft.EntityFrameworkCore;

namespace EmpManagementSystemCore.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private AppDbContext _appDbContext;

        public EmployeeRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public async Task AddEmployesAsync(Employee employee)
        {
            _appDbContext.Employees.Add(employee);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployeeByIdAsync(int id)
        {
            var emp = await _appDbContext.Employees.FindAsync(id);
            if (emp != null) {
                _appDbContext.Employees.Remove(emp);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _appDbContext.Employees.Update(employee);
            await _appDbContext.SaveChangesAsync();
        }
        
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync() => await _appDbContext.Employees.ToListAsync();

        public async Task<Employee> GetEmployeeByIdAsync(int id) => await _appDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
    }
}
