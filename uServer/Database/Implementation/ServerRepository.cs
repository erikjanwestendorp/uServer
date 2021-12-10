using System.Collections.Generic;
using Umbraco.Cms.Core.Scoping;
using Umbraco.Extensions;
using uServer.Database.Dto;

namespace uServer.Database.Implementation
{
    internal class ServerRepository : IServerRepository
    {
        private readonly IScopeProvider _scopeProvider;

        public ServerRepository(IScopeProvider scopeProvider)
        {
            _scopeProvider = scopeProvider;
        }

        public IEnumerable<ServerDto> GetAll()
        {
            using (var scope = _scopeProvider.CreateScope(autoComplete: true))
            {
                var sql = scope.SqlContext.Sql()
                    .Select<ServerDto>()
                    .From<ServerDto>();

                return scope.Database.Fetch<ServerDto>(sql);

            }
        }
    }


}
