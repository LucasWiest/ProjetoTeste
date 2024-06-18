using Microsoft.AspNetCore.Identity;
using ProjetoTeste.Data;
using System.Data;
using System.Security.Claims;
using System.Security;

namespace ProjetoTeste.Startup;

public static class IndentifyConfig
{ 
    public static IServiceCollection RegisterIdentify (this IServiceCollection services)
    {

        services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();

        #region 
            //AspNetRoles:

            //Finalidade: Armazena as funções (roles)disponíveis no sistema.
            //Campos Comuns: Id, Name, NormalizedName, ConcurrencyStamp.
        
            //AspNetRoleClaims:

            //Finalidade: Associa claims(reivindicações) às funções. Claims são declarações sobre a entidade(usuário ou role) e são usadas para adicionar informações adicionais, como permissões específicas.
            //Campos Comuns: Id, RoleId, ClaimType, ClaimValue.
        
            //AspNetUsers:

            //Finalidade: Armazena informações sobre os usuários do sistema.
            //Campos Comuns: Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount.
        
            //AspNetUserClaims:

            //Finalidade: Armazena claims associadas aos usuários individuais.
            //Campos Comuns: Id, UserId, ClaimType, ClaimValue.
        
            //AspNetUserLogins:

            //Finalidade: Armazena informações de login externo, como logins via Google, Facebook, etc.
            //Campos Comuns: LoginProvider, ProviderKey, ProviderDisplayName, UserId.
        
            //AspNetUserRoles:

            //Finalidade: Relaciona usuários a funções. Permite associar múltiplas funções a um único usuário.
            //Campos Comuns: UserId, RoleId.
        
            //AspNetUserTokens:

            //Finalidade: Armazena tokens para os usuários.Utilizado para gerenciar coisas como autenticação multifator e recuperação de senha.
            //Campos Comuns: UserId, LoginProvider, Name, Value.
        #endregion

        services.Configure<IdentityOptions>(options =>
        {
            // Password settings.
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;

            // Lockout settings.
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            // User settings.
            options.User.AllowedUserNameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = false;
        });

        return services;
    }

}
