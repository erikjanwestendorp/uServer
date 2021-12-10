using System.Collections.Generic;
using uServer.Database.Dto;

namespace uServer.Database
{
    public interface IServerRepository
    {
        IEnumerable<ServerDto> GetAll();
    }
}