angular.module("umbraco")
    .controller("uServer.dashboard.controller", function ($scope, uServerResource ) {

        var vm = this;
        vm.servers = [];

        function init() {
            

            uServerResource.getAll().then(success, error);

            function success(result) {
                vm.servers = result;
            }

            function error(result) {
                return $q.reject(result);
            }
        }
        

        init();

    });