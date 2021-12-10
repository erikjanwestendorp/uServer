using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Core.Models;
using uServer.Database.Dto;
using uServer.ViewModels;

namespace uServer.Mappings
{
    public class ServerRegistrationMappings : IMapDefinition
    {
        public void DefineMaps(IUmbracoMapper mapper)
        {
            mapper.Define<IServerRegistration, ServerRegistrationViewModel>((perm, context) => new ServerRegistrationViewModel(), Map);
            mapper.Define<ServerDto, ServerRegistrationViewModel>((perm, context) => new ServerRegistrationViewModel(), Map);
        }

        private void Map(IServerRegistration src, ServerRegistrationViewModel vm, MapperContext arg3)
        {
            vm.ServerIdentity = src.ServerIdentity;
            vm.ServerAddress = src.ServerAddress;
            vm.IsSchedulingPublisher = src.IsSchedulingPublisher;
            vm.IsActive = src.IsActive;
        }

        private void Map(ServerDto src, ServerRegistrationViewModel vm, MapperContext arg3)
        {
            vm.ServerIdentity = src.ServerIdentity;
            vm.ServerAddress = src.ServerAddress;
            vm.IsSchedulingPublisher = src.IsSchedulingPublisher;
            vm.IsActive = src.IsActive;
        }
    }
}
