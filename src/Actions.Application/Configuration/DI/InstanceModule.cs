using Actions.Instance.Services.Random;
using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;

namespace Actions.Instance.Configuration.DI;

public sealed class InstanceModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<RandomHelloStringService>().Keyed<IRandomService>("hello");
        //builder.RegisterType<RandomIqStringService>().Named<IRandomService>("iq");
    }
}
