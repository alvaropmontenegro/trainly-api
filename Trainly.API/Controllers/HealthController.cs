using Microsoft.AspNetCore.Mvc;

namespace Trainly.API.Controllers;

/// <summary>
/// Controller responsável por endpoints de verificação de saúde da API
/// Útil para monitoramento e health checks em ambientes de produção
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    private readonly ILogger<HealthController> _logger;

    // Injeção de dependência do logger para registro de eventos
    public HealthController(ILogger<HealthController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Endpoint simples para verificar se a API está respondendo
    /// </summary>
    /// <returns>Mensagem de confirmação com timestamp</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Get()
    {
        _logger.LogInformation("Health check executado em {Time}", DateTime.UtcNow);

        return Ok(new
        {
            Status = "Healthy",
            Service = "Trainly API",
            Timestamp = DateTime.UtcNow,
            Version = "1.0.0"
        });
    }

    /// <summary>
    /// Endpoint detalhado que retorna informações sobre o ambiente
    /// </summary>
    /// <returns>Informações detalhadas sobre a aplicação</returns>
    [HttpGet("detailed")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetDetailed()
    {
        var response = new
        {
            Status = "Healthy",
            Service = "Trainly API",
            Timestamp = DateTime.UtcNow,
            Version = "1.0.0",
            Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production",
            MachineName = Environment.MachineName,
            ProcessorCount = Environment.ProcessorCount,
            // Tempo que a aplicação está rodando
            Uptime = TimeSpan.FromMilliseconds(Environment.TickCount64)
        };

        _logger.LogInformation("Health check detalhado executado");

        return Ok(response);
    }
}