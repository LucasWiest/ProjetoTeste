using ProjetoTeste.Services.Client;

namespace ProjetoTeste.Services;

public static class ServicesInjection
{
    public static IServiceCollection RegisterInjectionServices (this IServiceCollection services)
    {
        return
            services.AddScoped<IClientService, ClientService>(); 

    }

}
