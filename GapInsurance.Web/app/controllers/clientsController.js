'use strict';
app.controller('clientsController', ['$scope', 'policiesService', '$routeParams', '$location', function ($scope, policiesService, $routeParams, $location) {

    $scope.clients = [];
    $scope.client = {};
    $scope.addOrEdit = "Add new client";

    policiesService.getClients().then(function (results) {

        $scope.clients = results.data;
    }, function (error) {
    });

  
    $scope.getClient = function(id){
        
        policiesService.getClient(id).then(function(result){

            $scope.client = result.data;
            $scope.addOrEdit = "Edit client";

        }, function(error){
        });
    }

    $scope.saveClient = function(){
        policiesService.saveClient($scope.client).then(function(result){
            $location.path('/clients');
        }, function(error){
            if (error.status = 400 && error.statusText === "Bad Request"){
                alert(error.data.message);
            }
        });        
    }


    if ($routeParams.id){
        $scope.getClient($routeParams.id);
    }
}]);