using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using DMProject.Infrastructure.Core;
using DMProject.Services.Abstract;
using DMProject.Services.Utilities;
using DMProject.Data.Repositories;
using DMProject.Data.Infrastructure;
using DMProject.Entities;
using DMProject.Models;
using DMProject.Infrastructure.Extensions;

namespace DMProject.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/pirvilege")]
    public class PrivilegeController : ApiControllerBase
    {

        private readonly PrivilegeService _prilegeService;
        private readonly IUnitOfWork _unitOfWork;
        public PrivilegeController(PrivilegeService prilegeService, 
                                 IEntityBaseRepository<Error> _errorsRepository, 
                                 IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _prilegeService = prilegeService;
        }


        // [Authorize(Roles = "AddPrivilege")]
        [AllowAnonymous]
        [HttpPost]
        [Route("addprivilege")]
        public HttpResponseMessage AddPrivilege(HttpRequestMessage request, PrivilegeViewModel roleview)
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
                    Privilege my = new Privilege();
                    my.UpdatePrivilegeEntity(roleview);
                    _prilegeService.AddPrivilege(my);

                    response = request.CreateResponse<Privilege>(HttpStatusCode.Created, my);
                }

                return response;
            });
        }
        [Authorize(Roles = "ModifyPrivilege")]
        [HttpPost]
        [Route("modifyprivilege")]
        public HttpResponseMessage ModifyPrivilege(HttpRequestMessage request, Privilege privilege)
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
                    string msg = _prilegeService.ModifyPrivilege(privilege);
                    if (msg == "成功!")
                        response = request.CreateResponse<Privilege>(HttpStatusCode.Created, privilege);

                    response = request.CreateResponse(HttpStatusCode.Created, new { message = "失败！",data= msg });
                }

                return response;
            });
        }


    }
}
