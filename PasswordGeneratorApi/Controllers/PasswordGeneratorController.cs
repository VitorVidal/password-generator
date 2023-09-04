using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PasswordGeneratorApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PasswordGeneratorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordGeneratorController : ControllerBase
    {
        private readonly ILogger<PasswordGeneratorController> _logger;
        private readonly IPasswordGeneratorServices _passwordGeneratorServices;

        public PasswordGeneratorController(ILogger<PasswordGeneratorController> logger, IPasswordGeneratorServices passwordGeneratorServices)
        {
            _logger = logger;
            _passwordGeneratorServices = passwordGeneratorServices;
        }       
       
        [HttpPost(Name = "Generate")]        
        public string Post([FromBody] int length)
        {
            _logger.LogInformation("New request to generate a new password");
            return _passwordGeneratorServices.GenerateNewPassword(length);
        }       
    }
}
