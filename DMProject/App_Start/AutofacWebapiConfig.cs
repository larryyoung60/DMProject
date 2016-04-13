using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Core;
using Autofac.Integration.WebApi;
using DMProject.Data;
using DMProject.Data.Infrastructure;
using DMProject.Data.Repositories;
using DMProject.Services;
using DMProject.Services.Utilities;
using DMProject.Services.Abstract;
using DMProject.Infrastructure.Core;

namespace DMProject.App_Start
{
    public class AutofacWebapiConfig
    {
        public static IContainer Container;
        public static void Initialize(HttpConfiguration config) {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver= new  AutofacWebApiDependencyResolver(container);
        }
        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
           

            // EF HomeCinemaContext
            builder.RegisterType<DMProjectContext>().As<DbContext>().InstancePerRequest();

            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            builder.RegisterGeneric(typeof(EntityBaseRepository<>)).As(typeof(IEntityBaseRepository<>)).InstancePerRequest();

            // Services
            builder.RegisterType<EncryptionService>().As<IEncryptionService>().InstancePerRequest();

            builder.RegisterType<MembershipService>().As<IMembershipService>().InstancePerRequest();

            // Generic Data Repository Factory
            builder.RegisterType<DataRepositoryFactory>().As<IDataRepositoryFactory>().InstancePerRequest();

            Container = builder.Build();
            return Container;
        }
    }
}