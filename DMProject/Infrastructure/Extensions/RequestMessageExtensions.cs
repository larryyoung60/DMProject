using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Dependencies;
using DMProject.Services.Abstract;
using DMProject.Data.Repositories;
using DMProject.Entities;
using DMProject.Services.Abstract.Base;
namespace DMProject.Infrastructure.Extensions
{
    public static class RequestMessageExtensions
    {
        internal static IMembershipService GetMembershipService(this HttpRequestMessage request)
        {
            return request.GetService<IMembershipService>();
        }
        internal static IPrivilegeService GetPrivilegeService(this HttpRequestMessage request)
        {
            return request.GetService<IPrivilegeService>();
        }
        internal static IEntityBaseRepository<T> GetDataRepository<T>(this HttpRequestMessage request) where T : class, IEntityBase, new()
        {
            return request.GetService<IEntityBaseRepository<T>>();
        }

        private static TService GetService<TService>(this HttpRequestMessage request)
        {
            IDependencyScope dependencyScope = request.GetDependencyScope();
            TService service = (TService)dependencyScope.GetService(typeof(TService));

            return service;
        }
    }
}