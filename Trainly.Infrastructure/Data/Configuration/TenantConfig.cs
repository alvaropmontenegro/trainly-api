using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trainly.Domain.Entities;

namespace Trainly.Infrastructure.Data.Configuration;

public class TenantConfig : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.ToTable("Tenants");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(200)
            .HasComment("Nome do Centro de Treinamento");

         builder.Property(t => t.Admin)  
            .IsRequired()
            .HasMaxLength(150)
            .HasComment("Nome do administrador responsável pelo Centro de Treinamento");

        builder.Property(t => t.Email)
            .IsRequired()
            .HasMaxLength(100)
            .HasComment("Email");

        builder.Property(t => t.Phone)
            .IsRequired()
            .HasMaxLength(100)
            .HasComment("Telefone");

        builder.Property(t => t.Address)
            .IsRequired()
            .HasMaxLength(150)
            .HasComment("Endereço");

        builder.Property(t => t.Plan)
            .IsRequired()
            .HasMaxLength(50)
            .HasComment("Plano");

        builder.Property(t => t.PlanExpirationDate)
            .HasComment("Data de expiração do plano");
        
        builder.Property(t => t.Language)
            .IsRequired()
            .HasMaxLength(50)
            .HasComment("Linguagem");
        
        builder.Property(t => t.Theme)
            .IsRequired()
            .HasMaxLength(50)
            .HasComment("Tema do Aplicativo");

        builder.Property(t => t.CreatedAt)
            .IsRequired()
            .HasComment("Data de criação");
    }
}