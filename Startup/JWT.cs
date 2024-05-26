using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.CodeAnalysis.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ProjetoTeste.Startup;

public static class JWT
{

    public static IServiceCollection RegisterJWT(this IServiceCollection services, JWTOptions optionsJWT)
    {

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).RegisterJwtBearer(optionsJWT);


        return services;
    }

    public static AuthenticationBuilder RegisterJwtBearer(this AuthenticationBuilder auth, JWTOptions optionsJWT)
    {
        auth.AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                //Define o emissor esperado do token JWT. Este é o valor que será usado na validação do campo "iss" do token.
                ValidIssuer = "teste",
                //Define o programa que vai utilizar o JWT, é para validar se outros programas não vão gerar o mesmo token
                ValidAudience = optionsJWT.ValidAudience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuv0123456789"))
            };
        });

        return auth;
    }

    public class JWTOptions
    {
        public required string ValidAudience { get; set; }

    }

}
