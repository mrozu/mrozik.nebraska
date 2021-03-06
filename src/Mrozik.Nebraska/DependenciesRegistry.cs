using Autofac;
using Mrozik.Nebraska.Data;
using Mrozik.Nebraska.Infrastructure;
using Mrozik.Nebraska.Mocks;
using Mrozik.Nebraska.Services;

namespace Mrozik.Nebraska
{
    public class DependenciesRegistry : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthMessageSender>().As<IEmailSender>();
            builder.RegisterType<DefaultUsersAndRolesInitializer>().As<IAsyncStartable>();

            builder.RegisterType<MockDatabase>().SingleInstance();
        }
    }
}