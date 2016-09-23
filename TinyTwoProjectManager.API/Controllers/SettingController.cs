using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TinyTwoProjectManager.API.Controllers;
using TinyTwoProjectManager.Models;
using TinyTwoProjectManager.Models.BindingModels;
using TinyTwoProjectManager.Services;

namespace TinyTwoProjectManager.Web.Controllers
{
    [Authorize]
    [RoutePrefix("Settings")]
    public class SettingController : BaseController
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            var settings = _settingService.GetSettings();
            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<IEnumerable<Setting>, IEnumerable<SettingDTO>>(settings));
        }
    }
}