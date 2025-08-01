using Catalogservice.Models;

using Microsoft.EntityFrameworkCore;

namespace Catalogservice.Data

{

    public class appdbcontext : DbContext

    {

        public appdbcontext(DbContextOptions<appdbcontext> options) : base(options)

        {

        }

        public DbSet<Catalog> CatalogServices { get; set; }

    }

}



 