﻿using System;
using System.Threading.Tasks;
using Autofac;
using Loquacious.Interfaces;

namespace Loquacious.Game
{
    public static class Register
    {
        public static IContainer Container;

        public static void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<SinglePlayer>().AsImplementedInterfaces();
            builder.RegisterType<MultiPlayer>().AsImplementedInterfaces();
            builder.RegisterType<PlayerOne>().AsImplementedInterfaces();
            builder.RegisterType<PlayerTwo>().AsImplementedInterfaces();
        }
    }
}
