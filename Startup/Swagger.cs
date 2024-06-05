using Microsoft.OpenApi.Models;

namespace ProjetoTeste.Startup;

public static class Swagger
{
    public static IServiceCollection RegisterSwagger(this IServiceCollection services)
    {

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Projetos de teste",
                Description = "esse projeto é para testar as skills",
                
                TermsOfService = new Uri("https://www.linkedin.com/in/lucas-finotti-wiest-a102061a8/"),
            });
        });

        return services; 
    }

    public static WebApplication WebSwagger (this WebApplication webApplication)
    {
        webApplication.UseSwagger();
        webApplication.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoTeste API v1");
            options.RoutePrefix = string.Empty;
        }); 

        return webApplication;
    }


}
