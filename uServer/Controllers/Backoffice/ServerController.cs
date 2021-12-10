using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.BackOffice.Controllers;
using Umbraco.Cms.Web.BackOffice.Filters;
using Umbraco.Cms.Web.Common.Attributes;
using uServer.Services;
using uServer.ViewModels;

namespace uServer.Controllers.Backoffice
{
    [PluginController(ServerConstants.Package.Name)]
    [JsonCamelCaseFormatter]
    public class ServerController : UmbracoAuthorizedApiController
    {
        private readonly IServerRegistrationService _serverRegistrationService;
        private readonly IServerService _serverService;

        public ServerController(IServerRegistrationService serverRegistrationService,  IServerService serverService)
        {
            _serverRegistrationService = serverRegistrationService;
            _serverService = serverService;
        }

        [HttpGet]
        public IEnumerable<ServerRegistrationViewModel> GetAll()
        {
            var result = _serverService.GetAll();
            return result;
        }
    }

    [PluginController(ServerConstants.Package.Name)]
    [JsonCamelCaseFormatter]
    public class ServerTwoController : UmbracoAuthorizedApiController
    {
        private readonly IServerRegistrationService _serverRegistrationService;
        private readonly IServerService _serverService;

        public ServerTwoController(IServerRegistrationService serverRegistrationService, IServerService serverService)
        {
            _serverRegistrationService = serverRegistrationService;
            _serverService = serverService;
        }

        [HttpGet]
        public IEnumerable<ServerRegistrationViewModel> GetAll()
        {
            var result = _serverService.GetAll();
            return result;
        }
    }
}
