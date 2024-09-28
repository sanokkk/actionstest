using System.Reflection;
using Autofac;

namespace Actions.Instance.Configuration.DI;

public static class AutofacConfiguration
{
    public static void ConfigureContainer()
    {
        var builder = new ContainerBuilder();

        builder.RegisterModule(new InstanceModule());
        //builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

        var container = builder.Build();
    } 
}
