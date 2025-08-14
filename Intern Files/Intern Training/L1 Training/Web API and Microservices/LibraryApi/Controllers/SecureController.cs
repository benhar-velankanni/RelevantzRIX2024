using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers

{

    [Route("api/[controller]")]

    [ApiController]

    public class SecureController : ControllerBase

    {

        [HttpGet]

        [Authorize]

        public IActionResult GetSecret()

        {

            return Ok("This is protected Endpoint. You are Authenticated");

        }

    }

}