using BindingsWithSdk.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BindingsWithSdk.Controllers
{
    [ApiController]
    public class InputController : ControllerBase
    {
        [HttpPost("/user-input-binding")]
        public IActionResult Post([FromBody] User user)
        {
            Console.WriteLine(user);
            return Ok(user);
        }
    }
}
