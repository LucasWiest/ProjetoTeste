using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.Win32;
using ProjetoTeste.Services.JWT;
using ProjetoTeste.Views.Account;

namespace ProjetoTeste.Services.Account
{
    public class AccountService : IAccountService
    {

        private readonly UserManager<IdentityUser> userManager;

        private readonly SignInManager<IdentityUser> signInManager;

        private readonly IJwtService jwtService;

        public AccountService(UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager, 
            IJwtService jwtService) 
        {
            this.userManager = userManager;
            this.signInManager = signInManager; 
            this.jwtService = jwtService;
        }

        public async Task<string> Register(RegisterView register)
        {
            try
            {
                var user = new IdentityUser
                {
                    UserName = register.UserName,
                    Email = register.Email
                };

                var result = await userManager.CreateAsync(user, register.Password);

                if (result.Succeeded)
                {
                    return await jwtService.GenerateJwtToken(user);
                }
                else
                {
                    throw new Exception(result.ToString());
                }
            }
            catch
            {
                throw;
            }

        } 

        public async Task<string> Login (LoginView login)
        {
            try
            {
                var user = new IdentityUser
                {
                    Email = login.Email,
                    PasswordHash = login.Password
                };

                var canLogin = await signInManager.CanSignInAsync(user);

                if (canLogin)
                {
                    return await jwtService.GenerateJwtToken(user);
                }
                else
                {
                    throw new Exception();
                }
            } 
            catch 
            {
                throw;
            }
        }

    }
}
