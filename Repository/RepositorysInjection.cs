using ProjetoTeste.Repository.Client;

namespace ProjetoTeste.Repository;

public static class RepositorysInjection
{
    public static IServiceCollection RegisterInjectionRepo(this IServiceCollection services) 
    {
        return services.AddScoped<IClientRep, ClientRep>();
    }
}
