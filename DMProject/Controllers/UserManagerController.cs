using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DMProject.Infrastructure.Core;
using DMProject.Services.Abstract;
using DMProject.Services.Utilities;
using DMProject.Data.Repositories;
using DMProject.Data.Infrastructure;
using DMProject.Entities;
using DMProject.Models;
using AutoMapper;
using DMProject.Infrastructure.Extensions;

namespace DMProject.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/usermanager")]
    public class UserManagerController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<RoleDefine> _roleRepository;
        public UserManagerController(IEntityBaseRepository<RoleDefine> roleRepository, IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _roleRepository = roleRepository;
        }


        public HttpResponseMessage Get(HttpRequestMessage request, string filter)
        {
            filter = filter.ToLower().Trim();

            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                var customers = _roleRepository.GetAll()
                    .Where(c => c.name.ToLower().Contains(filter) ||
                    c.code.ToLower().Contains(filter) ||
                    c.status.ToLower().Contains(filter)).ToList();

                var customersVm = Mapper.Map<IEnumerable<RoleDefine>, IEnumerable<RoleViewModel>>(customers);

                response = request.CreateResponse<IEnumerable<RoleViewModel>>(HttpStatusCode.OK, customersVm);

                return response;
            });
        }
        [Authorize(Roles = "systemadmin")]
        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, RoleViewModel roleview)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    RoleDefine newRole = new RoleDefine();
                    newRole.UpdateRoleDefine(roleview);
                    _roleRepository.Add(newRole);

                    _unitOfWork.Commit();

                    // Update view model
                    roleview = Mapper.Map<RoleDefine, RoleViewModel>(newRole);
                    response = request.CreateResponse<RoleViewModel>(HttpStatusCode.Created, roleview);
                }

                return response;
            });
        }
    }
}
