using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trainly.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjustandoTabelaTenants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Theme",
                table: "Tenants",
                type: "INTEGER",
                maxLength: 50,
                nullable: false,
                comment: "Tema do Aplicativo",
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "PlanExpirationDate",
                table: "Tenants",
                type: "TEXT",
                nullable: false,
                comment: "Data de expiração do plano",
                oldClrType: typeof(DateOnly),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "Plan",
                table: "Tenants",
                type: "INTEGER",
                maxLength: 50,
                nullable: false,
                comment: "Plano",
                oldClrType: typeof(string),
                oldType: "STRING");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Tenants",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                comment: "Telefone",
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tenants",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                comment: "Nome do Centro de Treinamento",
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "Language",
                table: "Tenants",
                type: "INTEGER",
                maxLength: 50,
                nullable: false,
                comment: "Linguagem",
                oldClrType: typeof(string),
                oldType: "STRING");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Tenants",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                comment: "Email",
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tenants",
                type: "TEXT",
                nullable: false,
                comment: "Data de criação",
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Tenants",
                type: "TEXT",
                maxLength: 150,
                nullable: false,
                comment: "Endereço",
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Theme",
                table: "Tenants",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldMaxLength: 50,
                oldComment: "Tema do Aplicativo");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "PlanExpirationDate",
                table: "Tenants",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "TEXT",
                oldComment: "Data de expiração do plano");

            migrationBuilder.AlterColumn<string>(
                name: "Plan",
                table: "Tenants",
                type: "STRING",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldMaxLength: 50,
                oldComment: "Plano");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Tenants",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100,
                oldComment: "Telefone");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tenants",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200,
                oldComment: "Nome do Centro de Treinamento");

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "Tenants",
                type: "STRING",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldMaxLength: 50,
                oldComment: "Linguagem");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Tenants",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100,
                oldComment: "Email");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tenants",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldComment: "Data de criação");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Tenants",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 150,
                oldComment: "Endereço");
        }
    }
}
