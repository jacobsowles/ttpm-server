using AutoMapper;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TinyTwoProjectManager.API.Controllers;
using TinyTwoProjectManager.Models;
using TinyTwoProjectManager.Services;

namespace TinyTwoProjectManager.Web.Controllers
{
    [Authorize]
    [RoutePrefix("UserSettings")]
    public class UserSettingController : BaseController
    {
        private readonly UserSettingService _userSettingService;

        public UserSettingController(UserSettingService userSettingService)
        {
            _userSettingService = userSettingService;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            var userSettings = _userSettingService.GetByUser(User.Identity.GetUserId());
            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<IEnumerable<UserSetting>, IEnumerable<UserSettingDTO>>(userSettings));
        }
    }
}