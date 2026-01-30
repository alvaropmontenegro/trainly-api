using Trainly.API.Configuration.DependencyInjection;
using Trainly.API.Configuration.Middleware;

var builder = WebApplication.CreateBuilder(args);

// ========================================
// CONFIGURAÇÃO DE SERVIÇOS (DI Container)
// ========================================

// Adiciona suporte para controllers da API
builder.Services.AddControllers();

// Configuração do banco de dados SQL Server com Entity Framework Core
builder.Services.AddDatabase(builder.Configuration);

// Configuração do Swagger para documentação da API
builder.Services.AddSwaggerDocumentation();

// Configuração de CORS (Cross-Origin Resource Sharing)
builder.Services.AddCorsPolicy();

// Adiciona health checks para monitoramento da aplicação
builder.Services.AddHealthChecks();

// Application Services (Repositories, Handlers, etc)
builder.Services.AddApplicationServices();

var app = builder.Build();

// ========================================
// CONFIGURAÇÃO DO PIPELINE DE REQUISIÇÕES
// ========================================

app.ConfigureMiddleware();

// Habilita Swagger apenas em ambiente de desenvolvimento
app.UseSwaggerDocumentation();

// Mapeia os controllers da API
app.ConfigureEndpoints();

// Inicia a aplicação
app.Run();