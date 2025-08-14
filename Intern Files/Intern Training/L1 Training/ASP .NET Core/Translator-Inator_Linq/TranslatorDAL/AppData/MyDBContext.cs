using TranslatorMD;
using System.Data.Entity;

namespace TransatorDAL.AppData
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("DefaultConnection") { }

        public DbSet<Translation> Translations { get; set; }
    }
}
