using Microsoft.EntityFrameworkCore;
using ProjetoTeste.Models;

namespace ProjetoTeste.Data.Contexts;

public static class ProfessionsConfiguration
{
    public static ModelBuilder ProfessionsBuilder (this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Professions>(entity =>
        {
            entity.HasKey(e => e.Description);
            entity.Property(e => e.Description)
            .IsRequired()
            .HasColumnType("varchar(250)");

            entity.Property(e => e.AverageWage) 
            .IsRequired(false)
            .HasColumnType("decimal(18, 2)");

            entity.HasMany(e => e.Clients)
            .WithOne(p => p.Professions)
            .HasForeignKey(c => c.Profession); 

        }); 

        return modelBuilder;
    }

}
