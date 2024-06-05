using ProjetoTeste.Repository;
using ProjetoTeste.Services;
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

        service.RegisterInjectionRepo();

        service.RegisterInjectionServices();

        #region Anotações

        //AppDomain.CurrentDomain.GetAssemblies() 
        //Está obtendo uma lista de todos os assemblies que foram carregados no domínio de aplicação atual. 

        //Ao passar os assemblies carregados para o AutoMapper, está dizendo ao AutoMapper para 
        //procurar nesses assemblies quaisquer classes que estendam Profile.  

        //Um domínio de aplicação(AppDomain) é um ambiente isolado onde aplicativos .NET são executados.Ele é criado pelo CLR 

        //Injeção dos serviços e repositorios 
        //Esse é um exemplo para fazer o registro pela reflexão
        //public static void AddImplementationsOfInterface<TInterface>(this IServiceCollection services, Assembly assembly)
        //{
        //    var interfaceType = typeof(TInterface);
        //    var types = assembly.GetTypes()
        //        .Where(t => t.IsClass && !t.IsAbstract && interfaceType.IsAssignableFrom(t))
        //        .ToList();

        //    foreach (var type in types)
        //    {
        //        services.AddTransient(interfaceType, type);
        //    }
        //} 

        //Outra forma melhor de fazer isso é pela lib Scan 

        //    services.Scan(scan => scan
        //    .FromAssemblyOf<IClientService>() // Assembly de referência
        //    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service"))) // Filtra classes terminadas em "Service"
        //    .AsImplementedInterfaces() // Registrar como as interfaces que implementa
        //    .WithTransientLifetime()); // Tempo de vida dos serviços


        #endregion

        service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        
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

        webApplication.MapControllers();

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
