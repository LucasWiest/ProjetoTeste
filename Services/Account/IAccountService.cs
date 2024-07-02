using ProjetoTeste.Views.Account;

namespace ProjetoTeste.Services.Account
{
    public interface IAccountService
    {
        Task<string> Register(RegisterView register); 

        Task<string> Login (LoginView register); 
    }
}
