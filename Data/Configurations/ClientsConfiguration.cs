using Microsoft.EntityFrameworkCore;
using ProjetoTeste.Models;

namespace ProjetoTeste.Data.Contexts;

public static class ClientsConfiguration 
{
    public static ModelBuilder ClientsBuilder(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clients>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                  .IsRequired()
                  .HasColumnType("uniqueidentifier")
                  .HasDefaultValueSql("NEWID()");

            entity.Property(e => e.Name)
                  .IsRequired()
                  .HasColumnType("varchar(255)");

            entity.Property(e => e.Birth)
                  .IsRequired()
                  .HasColumnType("date");

            entity.Property(e => e.Profession)
                  .IsRequired()
                  .HasColumnType("varchar(250)");

            entity.Property(e => e.GrossSalary)
                  .IsRequired()
                  .HasColumnType("decimal(18,2)");

            entity.Property(e => e.Discount)
                  .IsRequired()
                  .HasColumnType("decimal(18,2)");

            entity.Property(e => e.NetSalary)
                  .IsRequired()
                  .HasComputedColumnSql("[GrossSalary] - [Discount]")
                  .HasColumnType("decimal(18,2)");

            // Configuração da relação com Professions
            entity.HasOne(e => e.Professions)
                  .WithMany(p => p.Clients)
                  .HasForeignKey(e => e.Profession);


            entity.ToTable("Clients", "dbo");
        });

        return modelBuilder;
    }
}
