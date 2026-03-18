using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trainly.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoTabelaUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", maxLength: 100, nullable: false, comment: "Papel do Usuário"),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false, comment: "Nome do Usuário"),
                    Email = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false, comment: "Email"),
                    Avatar = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false, comment: "Foto do Usuário"),
                    PasswordHash = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false, comment: "Senha do Usuário"),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false, comment: "Telefone"),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", maxLength: 200, nullable: false, comment: "Data de criação")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
