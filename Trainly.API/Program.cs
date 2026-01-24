using Microsoft.EntityFrameworkCore;
using Trainly.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// ========================================
// CONFIGURAÇÃO DE SERVIÇOS (DI Container)
// ========================================

// Configuração do banco de dados SQL Server com Entity Framework Core
// A connection string é lida do appsettings.json
builder.Services.AddDbContext<TrainlyDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        // Configuração adicional para migrations em projeto separado
        sqlOptions => sqlOptions.MigrationsAssembly("Trainly.Infrastructure")
    )
);

// Adiciona suporte para controllers da API
builder.Services.AddControllers();

// Configuração do Swagger para documentação da API
// Útil para testar endpoints durante o desenvolvimento
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "Trainly API",
        Version = "v1",
        Description = "API para gerenciamento de treinos e academias"
    });
});

// Adiciona health checks para monitoramento da aplicação
builder.Services.AddHealthChecks();
//    .AddDbContextCheck<TrainlyDbContext>("database"); // Verifica conectividade com o banco

// Configuração de CORS (Cross-Origin Resource Sharing)
// Permite que aplicações frontend em outros domínios consumam a API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// ========================================
// CONFIGURAÇÃO DO PIPELINE DE REQUISIÇÕES
// ========================================

// Habilita Swagger apenas em ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Trainly API V1");
        c.RoutePrefix = string.Empty; // Swagger na raiz (http://localhost:5000)
    });
}

// Redireciona HTTP para HTTPS automaticamente
app.UseHttpsRedirection();

// Aplica a política de CORS configurada
app.UseCors("AllowAll");

// Mapeia os controllers da API
app.MapControllers();

// Mapeia o endpoint de health check
// Acessível em: GET /health
app.MapHealthChecks("/health");

// Inicia a aplicação
app.Run();