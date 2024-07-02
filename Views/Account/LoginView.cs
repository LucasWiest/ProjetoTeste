using System.ComponentModel.DataAnnotations;

namespace ProjetoTeste.Views.Account
{
    public class LoginView
    {
        [EmailAddress]
        public required string Email { get; set; }
        public required string Password { get; set; }

    }
}
