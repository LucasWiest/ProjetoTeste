using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProjetoTeste.Data;
using ProjetoTeste.Startup;
using System.Drawing;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.RegisterServices(builder.Configuration);

        var app = builder.Build();

        app.RegisterWeb();

        app.Run();
    }
}
