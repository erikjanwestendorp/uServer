using System.Collections.Generic;
using Umbraco.Cms.Core.Mapping;
using uServer.Database;
using uServer.Database.Dto;
using uServer.ViewModels;

namespace uServer.Services.Implementation
{
    public class ServerService : IServerService
    {
        private readonly IServerRepository _serverRepository;
        private readonly IUmbracoMapper _umbracoMapper;
        public ServerService(IServerRepository serverRepository, IUmbracoMapper umbracoMapper)
        {
            _serverRepository = serverRepository;
            _umbracoMapper = umbracoMapper;
        }
        public IEnumerable<ServerRegistrationViewModel> GetAll()
        {
            var servers = _serverRepository.GetAll();
            var result = _umbracoMapper.MapEnumerable<ServerDto, ServerRegistrationViewModel>(servers);

            return result;

        }
    }
}
