using CustomerService.Data;
using CustomerService.Unit_of_Work.Repository.Implementation;
using CustomerService.Unit_of_Work.Repository.Interface;

namespace CustomerService.Unit_of_Work
{
    public class UnitofWork : IUnitofWork
    {
        private readonly AppDbContext _context;

        public IRepository repository { get; }
        public UnitofWork(AppDbContext context)
        {
            _context = context;
            repository = new Repository1(_context);
        }

        public async Task SaveData()
        {
            await _context.SaveChangesAsync();
        }
    }
}
