using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using DMProject.Data.Repositories;
using DMProject.Entities;
using DMProject.Infrastructure.Extensions;

namespace DMProject.Infrastructure.Core
{
    public class DataRepositoryFactory : IDataRepositoryFactory
    {
        public IEntityBaseRepository<T> GetDataRepository<T>(HttpRequestMessage request) where T : class, IEntityBase, new()
        {
            return request.GetDataRepository<T>();
        }
    }

    public interface IDataRepositoryFactory
    {
        IEntityBaseRepository<T> GetDataRepository<T>(HttpRequestMessage request) where T : class, IEntityBase, new();
    }
}