using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using uServer.Database;
using uServer.Database.Implementation;
using uServer.Extensions;
using uServer.Services;
using uServer.Services.Implementation;

namespace uServer.Compose
{
    public class Composer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.AddNotifications();
            builder.AddMappings();

            builder.Services.AddTransient<IServerRepository, ServerRepository>();
            builder.Services.AddTransient<IServerService, ServerService>();
        }
    }
}
