(function () {
    'use strict';

    function uServerResource($http, $q) {
        var service = {
            getAll: getAll
        };

        var baseUrl = Umbraco.Sys.ServerVariables.uServer.serverController;

        return service;

        function getAll() {
            return $http.get(baseUrl + "GetAll").then(success, error);

            function success(result) {
                return result.data;
            }

            function error(result) {
                return $q.reject(result);
            }
        }

       
    }

    angular.module('umbraco.services').factory('uServerResource', uServerResource);
})();