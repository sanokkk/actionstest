using Actions.Instance.Services.Random;
using Autofac.Features.AttributeFilters;

namespace Actions.Instance.Services.Keyed;

public sealed class KeyedResolverService
{
    private readonly IRandomService _helloService;
    private readonly IRandomService _iqService;
    private readonly IRandomService _heightService;

    public KeyedResolverService([KeyFilter("hello")]IRandomService helloService, 
        [KeyFilter("iq")]IRandomService iqService,
        [KeyFilter("height")]IRandomService heightService)
    {
        _helloService = helloService;
        _iqService = iqService;
        _heightService = heightService;
    }

    public IRandomService ResolveRandomService(string key)
    {
        return key switch
        {
            "hello" => _helloService,
            "iq" => _iqService,
            "height" => _heightService,
            _ => throw new InvalidOperationException("Not key defined")
        };
    }
}
