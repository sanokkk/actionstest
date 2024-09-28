using Actions.Instance.Services.Random;
using Autofac.Features.AttributeFilters;

namespace Actions.Instance.Services.Keyed;

public sealed class KeyedResolverService
{
    private readonly IRandomService _helloService;
    private readonly IRandomService _iqService;

    public KeyedResolverService([KeyFilter("hello")]IRandomService helloService, [KeyFilter("iq")]IRandomService iqService)
    {
        _helloService = helloService;
        _iqService = iqService;
    }

    public IRandomService ResolveRandomService(string key)
    {
        return key switch
        {
            "hello" => _helloService,
            "iq" => _iqService,
            _ => throw new InvalidOperationException("Not key defined")
        };
    }
}
