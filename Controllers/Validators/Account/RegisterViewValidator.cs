using FluentValidation;
using ProjetoTeste.Views.Account;

namespace ProjetoTeste.Controllers.Validators.Account
{
    public class RegisterViewValidator : AbstractValidator<RegisterView>
    {
        public RegisterViewValidator() 
        {
            RuleFor(reg => reg.Email)
                .NotEmpty()
                .WithMessage("Não pode ser null");
            RuleFor(reg => reg.Password)
                .NotEmpty()
                .WithMessage("Senha não pode ser null");
            RuleFor(reg => reg.UserName)
                .NotEmpty()
                .WithMessage("UserName");
        }
    }
}
