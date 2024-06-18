using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetoTeste.Views.Account;

namespace ProjetoTeste.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<IdentityUser> userManager; 

        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        [HttpPost] 
        public async Task<IActionResult> Register([FromBody]RegisterView view)
        {
            try
            {
                var user = new IdentityUser
                {
                    UserName = view.UserName,
                    Email = view.Email

                };

                var result = await userManager.CreateAsync(user, view.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false); 
                    signInManager.
                } 
                else
                {
                    return BadRequest(result);
                }


                return Ok();
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex); 
                return BadRequest(ex.Message);
            }
        }


    }
}
