using Microsoft.AspNetCore.Identity;

namespace ProjetoTeste.Services.JWT
{
    public interface IJwtService
    {
        public Task<string> GenerateJwtToken(IdentityUser user);
    }

}
