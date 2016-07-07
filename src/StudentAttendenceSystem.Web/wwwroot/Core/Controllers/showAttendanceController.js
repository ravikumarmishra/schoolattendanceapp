(function () {
    'use strict';

    angular
        .module('AttendenceSystemApp')
        .controller('showAttendanceController', showAttendanceController);
    showAttendanceController.$inject = ['$scope', 'attendenceService'];
    
    function showAttendanceController($scope, attendenceService) {
        attendenceService.getData().then(function (response) {
            $scope.attendenceDetails = response.data;
            console.log($scope.attendenceDetails);
        }
            ,function(error){
                alert(error.data.message);
        });
    }
})();
