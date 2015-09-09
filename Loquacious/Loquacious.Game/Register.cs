using System;
using System.Threading.Tasks;
using Autofac;
using Loquacious.Interfaces;

namespace Loquacious.Game
{
    public static class Register
    {
        public static void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<SinglePlayerGame>().As<IGame>();
        }
    }
}
