using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using ProjetoTeste.Data;
using System.Data.Common;

namespace ProjetoTeste.Startup; 

public static class DataBase
{
    public static IServiceCollection RegisterDB(this IServiceCollection service, DBOptions optionsDB) 
    {
        service.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(optionsDB.ConnectionString)
        );


        return service; 
    } 

    public class DBOptions
    {
        public required string ConnectionString { get; set; } 
    }
}
