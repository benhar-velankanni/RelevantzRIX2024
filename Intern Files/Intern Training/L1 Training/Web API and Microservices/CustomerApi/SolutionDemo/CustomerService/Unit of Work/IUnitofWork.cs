using CustomerService.Unit_of_Work.Repository.Interface;

namespace CustomerService.Unit_of_Work
{
    public interface IUnitofWork
    {
        public IRepository repository { get; }
        Task SaveData();
    }
}
