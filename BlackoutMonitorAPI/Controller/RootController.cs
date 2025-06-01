using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlackoutMonitorAPI.Controller
{
    [ApiController]
    [Route("/")]
    public class RootController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return Ok(new
            {
                message = "Bem-vindo à BlackoutMonitorAPI",
                healthcheck = "/api/healthcheck"
            });
        }
    }
}
