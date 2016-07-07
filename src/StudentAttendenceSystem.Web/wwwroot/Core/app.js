(function () {
    'use strict';

    angular.module('AttendenceSystemApp', ['ngRoute', 'ngAnimate']);
    angular.module('AttendenceSystemApp').config(function ($routeProvider){
        $routeProvider.

        when('/', {
            templateUrl: '/Core/Partials/showAttendance.html',
            controller: 'showAttendanceController'
        }).
        when('/addAttendance', {
            templateUrl: '/Core/Partials/addAttendance.html',
            controller: 'addAttendanceController'
        }).
        
        otherwise({
            redirectTo: '/index.html'
        });
    });

})();




