using Actions.Instance.Controllers;
using Actions.Instance.Services.Keyed;
using Actions.Instance.Services.Random;
using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using Microsoft.AspNetCore.Mvc;
using KeyedService = Autofac.Core.KeyedService;

namespace Actions.Instance.Configuration.DI;

public sealed class InstanceModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<RandomHelloStringService>().Named<IRandomService>("hello");
        builder.RegisterType<RandomIqStringService>().Named<IRandomService>("iq");
        builder.RegisterType<HeightRandomService>().Named<IRandomService>("height");

        builder.Register(f => new KeyedResolverService(
            f.ResolveNamed<IRandomService>("hello"),
            f.ResolveNamed<IRandomService>("iq"),
            f.ResolveNamed<IRandomService>("height"))).AsSelf();
    }
}
