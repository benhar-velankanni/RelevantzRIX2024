using EmpManagementSystemCore.Entity;

namespace EmpManagementSystemCore.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();

        Task<Employee> GetEmployeeByIdAsync(int id);

        Task AddEmployesAsync(Employee employee);

        Task UpdateEmployeeAsync(Employee employee);

        Task DeleteEmployeeByIdAsync(int id);
    }
}
