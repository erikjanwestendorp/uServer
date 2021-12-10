namespace uServer
{
    public static class ServerConstants
    {
        public static class Package
        {
            public const string Name = "uServer";
            public const string Alias = "uServer";
        }

        public static class Api
        {
            public static class Controllers
            {
                public const string ServerController = "serverController";
            }
        }
        public static class Trees
        {
            public const string ServerTreeAlias = "uServers";
            public const string ServerTreeTitle = "Servers";
            public const string TreeGroup = "thirdParty";
            public const string TreeRoutePath = "/server-dashboard";
        }

        public static class Dashboards
        {
            public const string ServerDashboardAlias = "uServerDashboard";
            public const string ServerDashboardView = "/App_Plugins/uServer/dashboard/dashboard.html";
        }
    }
}
