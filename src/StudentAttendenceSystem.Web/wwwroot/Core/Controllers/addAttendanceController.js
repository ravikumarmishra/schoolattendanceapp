(function () {
    'use strict';

    angular
        .module('AttendenceSystemApp')
        .controller('addAttendanceController', addAttendanceController);

    addAttendanceController.$inject = ['$scope','$http'];

    function addAttendanceController($scope,$http) {
        /* jshint validthis:true */
        $scope.submitForm = function (isValid) {

          //  $scope.student.Date = new Date();
            // check to make sure the form is completely valid
            if (isValid) {
                
                $http.post('http://localhost:3045/api/StudentAttendence', $scope.student).success(function (response) {
                    //prompt('NAME:', response.StudentName);
                    //prompt('DATE:', response.Date);
                    //prompt('STATUS:', response.AttendenceStatus);
                    $scope.submittedData = response;
                    $scope.message = "submitted successfully!!!";
                });
                
            }
        };
       
    }
})();
