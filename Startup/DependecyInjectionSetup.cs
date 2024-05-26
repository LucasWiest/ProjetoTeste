using Microsoft.CodeAnalysis.CSharp.Syntax;
using static ProjetoTeste.Startup.DataBase;
using static ProjetoTeste.Startup.JWT;

namespace ProjetoTeste.Startup;
public static class DependecyInjectionSetup
{

    public static IServiceCollection RegisterServices(this IServiceCollection service, ConfigurationManager config)
    {
        service.RegisterJWT(config.GetSection("Jwt").Get<JWTOptions>());

        service.RegisterDB(config.GetSection("DataBase").Get<DBOptions>());

        service.RegisterSwagger();

        service.AddControllersWithViews();

        service.AddMvc();

        return service;
    } 

    public static WebApplication RegisterWeb (this WebApplication webApplication)
    {

        webApplication.WebSwagger();

        webApplication.UseHttpsRedirection();

        webApplication.UseStaticFiles();

        webApplication.UseRouting();

        webApplication.UseAuthorization();

        if (webApplication.Environment.IsDevelopment())
        {
            webApplication.UseMigrationsEndPoint();
            webApplication.UseSwagger();
            webApplication.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
        }
        else
        {
            webApplication.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            webApplication.UseHsts();
        }

        return webApplication;
    }

}
