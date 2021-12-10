using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Hosting;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Web.BackOffice.Controllers;
using Umbraco.Cms.Web.Common.Attributes;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Extensions;


namespace uServer.Notifications
{
    public class VariablesHandler : INotificationHandler<ServerVariablesParsingNotification>
    {
        private readonly LinkGenerator _linkGenerator;
        private readonly ITypeFinder _typeFinder;
        

        public VariablesHandler(LinkGenerator linkGenerator, ITypeFinder typeFinder, IHostingEnvironment hostingEnvironment)
        {
            _linkGenerator = linkGenerator;
            _typeFinder = typeFinder;
            
        }
        public void Handle(ServerVariablesParsingNotification notification)
        {
            var controllers = _typeFinder.FindClassesOfTypeWithAttribute<UmbracoAuthorizedApiController, PluginControllerAttribute>().Where(x => x.GetCustomAttribute<PluginControllerAttribute>(true).AreaName == ServerConstants.Package.Name);
            
            var dictionary = new Dictionary<string, string>();

            foreach (var controller in controllers)
            {
                
                dictionary.Add(controller.Name.ToFirstLower(), _linkGenerator.GetUmbracoApiServiceBaseUrl(c =>controller.GetMethods().FirstOrDefault(), controller));
            }

            //notification.ServerVariables.Add(ServerConstants.Package.Alias, new Dictionary<string, object>
            //{
            //    { ServerConstants.Api.Controllers.ServerController, _linkGenerator.GetUmbracoApiServiceBaseUrl<ServerController>(controller => controller.GetAll())}
            //});

            notification.ServerVariables.Add("test",dictionary);
        }
    }

    public static class Extensions
    {
        /// <summary>
        /// Return the Url for a Web Api service
        /// </summary>
        /// <typeparam name="T">The <see cref="UmbracoApiControllerBase"/></typeparam>
        public static string GetUmbracoApiService(this LinkGenerator linkGenerator, string actionName, Type type, object id = null)
            => linkGenerator.GetUmbracoControllerUrl(
            actionName,
            type,
            new Dictionary<string, object>()
            {
                ["id"] = id
            });

        public static string GetUmbracoApiServiceBaseUrl(this LinkGenerator linkGenerator, Expression<Func<UmbracoApiController, object>> methodSelector, Type type)
            
        {
            var method = ExpressionHelper.GetMethodInfo(methodSelector);
            if (method == null)
            {
                throw new MissingMethodException("Could not find the method " + methodSelector + " on type " + typeof(Type) + " or the result ");
            }
            return linkGenerator.GetUmbracoApiService(method.Name, type).TrimEnd(method.Name);
        }
    }


}
