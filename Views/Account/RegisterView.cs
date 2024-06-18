using System.ComponentModel.DataAnnotations;

namespace ProjetoTeste.Views.Account
{
    public class RegisterView
    {
        [EmailAddress]
        public required string Email { get; set; } 
        public required string UserName { get; set; }
        public required string Password { get; set; }

    }
}
