using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoTeste.Data.Contexts;
using ProjetoTeste.Models;
using ProjetoTeste.Types.Curreancy;
using System.Reflection.Emit;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ProjetoTeste.Data;

public class ApplicationDbContext
    : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { 
        //É possivel colocar para todas as querys serem notracking
        //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    } 

    public DbSet<Clients> Clients { get; set; }  

    public DbSet<Professions> Professions { get; set; }

    #region Anotações Migrations
    //Para usar em linha de comando(CMD): dotnet tool list --global

    //É possivel criar o nome para a nova migração
    //dotnet ef migrations add nomedamigração 
    //Se precisar remover a migração criada 
    //dotnet ef migrations remove
    //Faz o update em banco, validando se a tabale ja existe ou precisa altera-la
    //dotnet ef database update  

    //utils 
    //Mover para um diretorio especifico
    //dotnet ef migrations add InitialCreate --output-dir Your/Directory 
    //Listar Migrations 
    //dotnet ef migrations list
    //Verifica se há alterações nas models
    //dotnet ef migrations has-pending-model-changes

    //Se tiver 2 bancos para fazer a migração no 2 
    //migrationBuilder.ActiveProvider

    //Cuidados: 
    //-Juntado 2 colunas em 1, é necessário fazer um update na criada para pegar a info das 2 antes do dropcolumn 

    #endregion 


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ProfessionsBuilder();

        builder.ClientsBuilder();


        //Quanto fizer um tipo e quiser converter para a tipagem do banco
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.ClrType.GetProperties())
            {
                if (property.PropertyType == typeof(Currency) || property.PropertyType == typeof(Currency?))
                {
                    var converter = new CurrencyConverter();
                    builder.Entity(entityType.ClrType)
                        .Property(property.Name)
                        .HasConversion(converter);
                }
            } 

           
        }

        base.OnModelCreating(builder);
    }
}
