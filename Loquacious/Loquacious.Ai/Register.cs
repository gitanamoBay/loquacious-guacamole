using Autofac;
using Loquacious.Interfaces;

namespace Loquacious.Ai
{
    public static class Register
    {
        public static IContainer Container;

        public static void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<RandomStratergy>().As<IStratergy>();
            builder.RegisterType<ArtificalIntelligence>().AsImplementedInterfaces();
        }
    }
}