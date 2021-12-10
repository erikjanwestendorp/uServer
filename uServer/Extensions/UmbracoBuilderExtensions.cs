using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Core.Notifications;
using uServer.Mappings;
using uServer.Notifications;

namespace uServer.Extensions
{
    public static class UmbracoBuilderExtensions
    {
        public static IUmbracoBuilder AddNotifications(this IUmbracoBuilder builder)
        {
            builder.AddNotificationHandler<ServerVariablesParsingNotification, VariablesHandler>();
            return builder;
        }
        
        public static IUmbracoBuilder AddMappings(this IUmbracoBuilder builder)
        {
            builder.WithCollectionBuilder<MapDefinitionCollectionBuilder>().Add<ServerRegistrationMappings>();
            return builder;
        }
    }
}
