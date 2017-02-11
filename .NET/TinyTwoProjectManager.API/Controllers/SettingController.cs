using AutoMapper;
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
    [RoutePrefix("Settings")]
    public class SettingController : BaseController
    {
        private readonly SettingService _settingService;

        public SettingController(SettingService settingService)
        {
            _settingService = settingService;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            var settings = _settingService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<IEnumerable<Setting>, IEnumerable<SettingDTO>>(settings));
        }
    }
}