'use strict';
app.controller('policiesController', ['$scope', 'policiesService', '$routeParams', '$location', function ($scope, policiesService, $routeParams, $location) {

    $scope.policies = [];
    $scope.customers = [];
    $scope.availablePolicies = [];
    $scope.policy = {};
    $scope.addOrEdit = "Add new customer policies";

    policiesService.getCustomerPolicies().then(function (results) {

        $scope.policies = results.data;
    }, function (error) {
    });

    policiesService.getCustomers().then(function (results) {

        $scope.customers = results.data;
    }, function (error) {
    });

    policiesService.getPolicies().then(function (results) {

        $scope.availablePolicies = results.data;
    }, function (error) {
    });

    $scope.getPolicy = function(id){
        policiesService.getCustomerPolicy(id).then(function(result){

            $scope.policy = result.data;
            $scope.addOrEdit = "Edit customer policies";

        }, function(error){
        });
    }

    $scope.savePolicy = function(){
        policiesService.saveCustomerPolicy($scope.policy).then(function(result){
            $location.path('/policies');
        }, function(error){
            if (error.status = 400 && error.statusText === "Bad Request"){
                alert(error.data.message);
            }
        });        
    }

    $scope.returnRiskType = function(val){
        switch(val){
            case 0:
                return "High";
            case 1:
                return "Medium High";
            case 2:
                return "Medium";
            case 3:
                return "Low";
        }
    }


    if ($routeParams.id){
        $scope.getPolicy($routeParams.id);
    }
}]);