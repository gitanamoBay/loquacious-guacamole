using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Loquacious.Interfaces;

namespace Loquacious.Ai
{
    public static class Register
    {
        public static void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<RandomStratergy>().As<IStratergy>();
            builder.RegisterType<ArtificalIntelligence>().As<IAi>();
        }
    }
}
