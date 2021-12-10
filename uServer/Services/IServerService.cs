using System.Collections.Generic;
using uServer.ViewModels;

namespace uServer.Services
{
    public interface IServerService
    {
        IEnumerable<ServerRegistrationViewModel> GetAll();
    }
}
