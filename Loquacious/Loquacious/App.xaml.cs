using System.Reflection;
using System.Windows;
using Autofac;
using Loquacious.Ai;

namespace Loquacious
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IContainer Container { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();

            Register.RegisterTypes(builder);
            Game.Register.RegisterTypes(builder);

            Container = builder.Build();

            Register.Container = Container;
            Game.Register.Container = Container;
        }
    }
}