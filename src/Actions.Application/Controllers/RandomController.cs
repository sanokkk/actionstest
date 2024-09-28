using Actions.Instance.Services.Keyed;
using Microsoft.AspNetCore.Mvc;

namespace Actions.Instance.Controllers;

[ApiController]
[Route("api")]
public sealed class RandomController : ControllerBase
{
    private readonly KeyedResolverService _keyedResolverService;
    private readonly ILogger<RandomController> _logger;

    public RandomController(
        ILogger<RandomController> logger,
         KeyedResolverService keyedResolverService)
    {
        _logger = logger;
        _keyedResolverService = keyedResolverService;
    }

    [HttpGet("typed")]
    public ActionResult Get([FromQuery] string serviceType)
    {
        _logger.LogInformation("Получил запрос");

        var service = _keyedResolverService.ResolveRandomService(serviceType);
        return Ok(service.GenerateRandomString());
    }
}
