using CustomerService.Model;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Unit_of_Work.Repository.Interface
{
    public interface IRepository
    {
        Task<List<Customer>> GetAllData();
        Task<Customer> GetDatabyId(int id);
        Task AddData(Customer customer);
        Task UpdateData(Customer customer,int id);
        Task DeleteData(int id);
    }
}
