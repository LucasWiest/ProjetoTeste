using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetoTeste.Services.Account;
using ProjetoTeste.Views.Account;

namespace ProjetoTeste.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly AccountService accountService;

        public AccountController(AccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost] 
        public async Task<IActionResult> Login([FromBody]LoginView model)
        {
            try
            {
                throw new NotImplementedException();
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost] 
        public async Task<IActionResult> Register([FromBody]RegisterView view)
        {
            try
            {
                var jwt = await this.accountService.Register(view);  

                if (jwt == null || jwt.Count() == 0)
                {
                   return StatusCode(401, "Ocorreu um erro ao registar o usuário");
                }

                return Ok(jwt);
                
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex); 
                return BadRequest(ex.Message);
            }
        }


    }
}
