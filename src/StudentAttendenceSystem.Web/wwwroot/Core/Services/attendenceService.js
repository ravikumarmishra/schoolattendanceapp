(function () {
    'use strict';

    angular
        .module('AttendenceSystemApp')
        .factory('attendenceService', attendenceService);

    attendenceService.$inject = ['$http','$location'];

    function attendenceService($http,$location) {
        var service = {
            getData: getData,
            navigateTo: navigateTo
        };
        function getData() {
            return $http.get('http://localhost:3045/api/StudentAttendence').then(function (data) {
                return data;
            });
        }
        function navigateTo(path) {
            $location.path(path);
        }
        return service;
    }
})();