'use strict';
app.controller('customersController', ['$scope', 'policiesService', '$routeParams', '$location', function ($scope, policiesService, $routeParams, $location) {

    $scope.customers = [];
    $scope.clients = [];
    $scope.customer = {};
    $scope.addOrEdit = "Add new customer";

    policiesService.getCustomers().then(function (results) {

        $scope.customers = results.data;
    }, function (error) {
    });

    policiesService.getClients().then(function (results) {

        $scope.clients = results.data;
    }, function (error) {
    });

  
    $scope.getCustomer = function(id){
        
        policiesService.getCustomer(id).then(function(result){

            $scope.customer = result.data;
            $scope.addOrEdit = "Edit customer";

        }, function(error){
        });
    }

    $scope.saveCustomer = function(){
        policiesService.saveCustomer($scope.customer).then(function(result){
            $location.path('/customers');
        }, function(error){
            if (error.status = 400 && error.statusText === "Bad Request"){
                alert(error.data.message);
            }
        });        
    }


    if ($routeParams.id){
        $scope.getCustomer($routeParams.id);
    }
}]);