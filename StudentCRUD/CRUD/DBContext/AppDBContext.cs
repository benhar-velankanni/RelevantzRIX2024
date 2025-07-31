using CRUD.Model;
using Microsoft.EntityFrameworkCore;
namespace CRUD.DBContext
{
    public class AppDBContext : DbContext
    {
              
        
        public AppDBContext(DbContextOptions<AppDBContext>options) : base(options) { 

        }
       
            public DbSet<Student> Students { get; set; }
        
    }
}
