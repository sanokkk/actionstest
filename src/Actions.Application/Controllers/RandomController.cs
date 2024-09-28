using Actions.Instance.Services.Random;
using Autofac.Features.AttributeFilters;
using Microsoft.AspNetCore.Mvc;

namespace Actions.Instance.Controllers;

[ApiController]
[Route("api")]
public sealed class RandomController : ControllerBase
{
    private readonly IRandomService _helloService;
    private readonly ILogger<RandomController> _logger;

    public RandomController([KeyFilter("hello")]IRandomService helloService, ILogger<RandomController> logger)
    {
        _helloService = helloService;
        _logger = logger;
    }

    [HttpGet]
    public ActionResult Get()
    {
        _logger.LogInformation("Получил запрос");
        return Ok(_helloService.GenerateRandomString());
    }
}
