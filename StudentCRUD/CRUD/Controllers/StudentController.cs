using CRUD.DBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDBContext _context;
        public StudentController(AppDBContext db)
        {
            _context = db;
        }
        [Route("Create")]
    }
}
