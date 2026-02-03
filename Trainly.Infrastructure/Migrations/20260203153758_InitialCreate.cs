using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trainly.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false, comment: "Nome do treino"),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false, comment: "Descrição detalhada do treino"),
                    DifficultyLevel = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false, defaultValue: "Iniciante", comment: "Nível de dificuldade"),
                    DurationMinutes = table.Column<int>(type: "INTEGER", nullable: false, comment: "Duração estimada em minutos"),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true, comment: "Indica se o treino está ativo"),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "GETUTCDATE()", comment: "Data de criação"),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true, comment: "Data da última atualização")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_CreatedAt",
                table: "Workouts",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_IsActive",
                table: "Workouts",
                column: "IsActive");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Workouts");
        }
    }
}
