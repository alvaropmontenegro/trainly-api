using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trainly.Domain.Entities;

namespace Trainly.Infrastructure.Data.Configurations;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.HasOne(u => u.Tenant)   //chave estrangeira
            .WithMany()                        
            .HasForeignKey(u => u.TenantId)     
            .IsRequired()                       
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasComment("Nome do Usuário");

        builder.Property(w => w.Email)
            .IsRequired()
            .HasMaxLength(200)
            .HasComment("Email");
        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.Property(w => w.Password)
            .IsRequired()
            .HasMaxLength(200)
            .HasComment("Senha do Usuário");

        builder.Property(w => w.Role)
            .IsRequired()
            .HasMaxLength(100)
            .HasComment("Papel do Usuário");

        builder.Property(w => w.Phone)
            .IsRequired()
            .HasMaxLength(200)
            .HasComment("Telefone");

        builder.Property(w => w.Avatar)
            .IsRequired()
            .HasMaxLength(200)  //duvida aqui
            .HasComment("Foto do Usuário");  
        
        builder.Property(w => w.Language)
            .IsRequired()
            .HasMaxLength(100)  //duvida aqui
            .HasComment("Linguagem");  

        builder.Property(w => w.CreatedAt)
            .IsRequired()
            .HasMaxLength(200)  //duvida aqui
            .HasComment("Data de criação");  
    }
}