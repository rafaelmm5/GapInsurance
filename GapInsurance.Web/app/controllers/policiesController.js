'use strict';
app.controller('policiesController', ['$scope', 'policiesService', function ($scope, policiesService) {

    $scope.policies = [];
    $scope.policy = {};

    policiesService.getCustomerPolicies().then(function (results) {

        $scope.policies = results.data;
    }, function (error) {
    });

    $scope.getPolicy = function(id){
        
        policiesService.getCustomerPolicy(id).then(function(result){

            $scope.policy = result.data;
        }, function(error){

        });
       

    }


}]);