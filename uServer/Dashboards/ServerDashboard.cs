using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Dashboards;

namespace uServer.Dashboards
{
    public class ServerDashboard : IDashboard
    {
        public string Alias => ServerConstants.Dashboards.ServerDashboardAlias;
        public string View => ServerConstants.Dashboards.ServerDashboardView;

        public string[] Sections => new[]
        {
            Constants.Applications.Settings
        };
        public IAccessRule[] AccessRules
        {
            get
            {
                var rules = new IAccessRule[]
                {
                    new AccessRule {Type = AccessRuleType.Grant, Value = Constants.Security.AdminGroupAlias}
                };

                return rules;
            }
        }
    }
}
