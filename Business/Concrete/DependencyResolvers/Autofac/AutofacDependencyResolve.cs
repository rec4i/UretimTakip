using Autofac;
using Business.Mappings;
using DataAccess.Concrete.EntityFramework.DbContexts;
using System.Reflection;
using Module = Autofac.Module;

namespace WebIU.DependencyResolvers.Autofac
{
    public class AutofacDependencyResolve : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var businesAssembly = Assembly.GetAssembly(typeof(GeneralMapping));
            var dalAssembly = Assembly.GetAssembly(typeof(AppIdentityDbContext));
            builder.RegisterAssemblyTypes(businesAssembly, dalAssembly).Where(p => p.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(businesAssembly, dalAssembly).Where(p => p.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(businesAssembly, dalAssembly).Where(p => p.Name.EndsWith("Accessor")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
