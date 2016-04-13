using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using DMProject.Infrastructure.Extensions;
using DMProject.Data.Repositories;
using DMProject.Entities;
using DMProject.Data.Infrastructure;

namespace DMProject.Infrastructure.Core
{
    public class ApiControllerBaseExtended : ApiController
    {
        protected List<Type> _requiredRepositories;

        protected readonly IDataRepositoryFactory _dataRepositoryFactory;
        protected IEntityBaseRepository<Error> _errorsRepository;
        protected IEntityBaseRepository<UserEntity> _userRepository;
        protected IEntityBaseRepository<Location> _locationRepository;
        protected IEntityBaseRepository<Menu> _memuRepository;
        protected IEntityBaseRepository<MenuPrivilege> _memupriRepository;
        protected IEntityBaseRepository<Privilege> _priRepository;
        protected IEntityBaseRepository<RoleDefine> _roleRepository;
        protected IEntityBaseRepository<UserRole> _userroleRepository;



        protected IUnitOfWork _unitOfWork;

        private HttpRequestMessage RequestMessage;

        public ApiControllerBaseExtended(IDataRepositoryFactory dataRepositoryFactory, IUnitOfWork unitOfWork)
        {
            _dataRepositoryFactory = dataRepositoryFactory;
            _unitOfWork = unitOfWork;
        }

        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage request, List<Type> repos, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage response = null;

            try
            {
                RequestMessage = request;
                InitRepositories(repos);
                response = function.Invoke();
            }
            catch (DbUpdateException ex)
            {
                LogError(ex);
                response = request.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                LogError(ex);
                response = request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        private void InitRepositories(List<Type> entities)
        {
            _errorsRepository = _dataRepositoryFactory.GetDataRepository<Error>(RequestMessage);

            if (entities.Any(e => e.FullName == typeof(UserEntity).FullName))
            {
                _userRepository = _dataRepositoryFactory.GetDataRepository<UserEntity>(RequestMessage);
            }

            if (entities.Any(e => e.FullName == typeof(Location).FullName))
            {
                _locationRepository = _dataRepositoryFactory.GetDataRepository<Location>(RequestMessage);
            }

            if (entities.Any(e => e.FullName == typeof(Menu).FullName))
            {
                _memuRepository = _dataRepositoryFactory.GetDataRepository<Menu>(RequestMessage);
            }

            if (entities.Any(e => e.FullName == typeof(MenuPrivilege).FullName))
            {
                _memupriRepository = _dataRepositoryFactory.GetDataRepository<MenuPrivilege>(RequestMessage);
            }

            if (entities.Any(e => e.FullName == typeof(Privilege).FullName))
            {
                _priRepository = _dataRepositoryFactory.GetDataRepository<Privilege>(RequestMessage);
            }
            if (entities.Any(e => e.FullName == typeof(RoleDefine).FullName))
            {
                _roleRepository = _dataRepositoryFactory.GetDataRepository<RoleDefine>(RequestMessage);
            }

            if (entities.Any(e => e.FullName == typeof(UserRole).FullName))
            {
                _userroleRepository = _dataRepositoryFactory.GetDataRepository<UserRole>(RequestMessage);
            }

        }

        private void LogError(Exception ex)
        {
            try
            {
                Error _error = new Error()
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    DateCreated = DateTime.Now
                };

                _errorsRepository.Add(_error);
                _unitOfWork.Commit();
            }
            catch { }
        }
    }
}