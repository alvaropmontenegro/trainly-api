using Trainly.API.Configuration.DependencyInjection;
using Trainly.API.Configuration.Middleware;
using Trainly.Domain.Entities;
using Trainly.Domain.Interfaces;
using Trainly.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ========================================
// CONFIGURA��O DE SERVI�OS (DI Container)
// ========================================

// Adiciona suporte para controllers da API
builder.Services.AddControllers();

// Configura��o do banco de dados SQL Server com Entity Framework Core
builder.Services.AddDatabase(builder.Configuration);

// Configura��o do Swagger para documenta��o da API
builder.Services.AddSwaggerDocumentation();

// Configura��o de CORS (Cross-Origin Resource Sharing)
builder.Services.AddCorsPolicy();

// Adiciona health checks para monitoramento da aplica��o
builder.Services.AddHealthChecks();

// Application Services (Repositories, Handlers, etc)
builder.Services.AddApplicationServices();

var app = builder.Build();

// ========================================
// CONFIGURA��O DO PIPELINE DE REQUISI��ES
// ========================================

app.ConfigureMiddleware();

// Habilita Swagger apenas em ambiente de desenvolvimento
app.UseSwaggerDocumentation();

// Mapeia os controllers da API
app.ConfigureEndpoints();

// Inicia a aplica��o
app.Run();