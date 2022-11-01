using BindingsWithSdk.Models;
using Dapr.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BindingsWithSdk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutputController : ControllerBase
    {
        private readonly DaprClient daprClient;

        public OutputController(DaprClient daprClient)
        {
            this.daprClient = daprClient;
        }

        public async Task<IActionResult> Get()
        {
            var model = new User
            {
                Name = "zyg",
                Email = "heavenwing@msn.com",
            };
            await daprClient.InvokeBindingAsync("user-output-binding", "create", model);
            return Ok(model);
        }
    }
}
