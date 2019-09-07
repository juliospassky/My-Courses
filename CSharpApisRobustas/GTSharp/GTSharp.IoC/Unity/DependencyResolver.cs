using GTSharp.Domain.Interfaces.Repositories;
using GTSharp.Domain.Interfaces.Repositories.Base;
using GTSharp.Domain.Interfaces.Services;
using GTSharp.Domain.Services;
using GTSharp.Infra.Persistence;
using GTSharp.Infra.Persistence.Repositories;
using GTSharp.Infra.Persistence.Repositories.Base;
using GTSharp.Infra.Transactions;
using prmToolkit.NotificationPattern;
using System.Data.Entity;
using Unity;
using Unity.Lifetime;

namespace GTSharp.IoC.Unity
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<DbContext, GTSharpContext>(new HierarchicalLifetimeManager());
            //UnitOfWork
            container.RegisterType<UnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<INotifiable, Notifiable>(new HierarchicalLifetimeManager());

            //Serviço de Domain
            //container.RegisterType(typeof(IServiceBase<,>), typeof(ServiceBase<,>));

            container.RegisterType<IServiceUser, ServiceUser>(new HierarchicalLifetimeManager());

            //Repository
            container.RegisterType(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));
            container.RegisterType<IRepositoryUser, RepositoryUser>(new HierarchicalLifetimeManager());
        }
    }
}
