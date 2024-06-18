using ProjetoTeste.Services.Account;
using ProjetoTeste.Services.Client;
using ProjetoTeste.Services.JWT;

namespace ProjetoTeste.Services;

public static class ServicesInjection
{
    public static IServiceCollection RegisterInjectionServices (this IServiceCollection services)
    {
        return
            services.AddScoped<IClientService, ClientService>()
            .AddScoped<IJwtService, JwtService>() 
            .AddScoped<IAccountService, AccountService>(); 

    }

}
