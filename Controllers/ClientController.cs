using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoTeste.Services.Client;
using ProjetoTeste.Views.Client;

namespace ProjetoTeste.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly ILogger<ClientController> _logger;
        private readonly IClientService _clientService;

        public ClientController(ILogger<ClientController> logger, IClientService clientService) 
        { 
            this._logger = logger;
            this._clientService = clientService;
        }

        [HttpGet("test")]
        [Authorize]
        public IActionResult Test()
        {
            return Ok("Test successful");
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        { 
            try
            {
                var clients = await this._clientService.GetAll(); 

                if (clients == null || clients.Count == 0)
                    return NotFound("Não há clientes"); 

                return Ok(clients);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "Um erro");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ClientView clientView)
        {
            try
            {
                return Ok(await this._clientService.Save(clientView));
            } 
            catch (Exception ex)
            {
                this._logger.LogError(ex, "Um erro");
                return StatusCode(500, "Internal server error.");
            }
        }


    }
}
