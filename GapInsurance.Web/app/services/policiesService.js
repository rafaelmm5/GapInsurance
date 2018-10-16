'use strict';
app.factory('policiesService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var policiesServiceFactory = {};

    var _getCustomerPolicies = function () {

        return $http.get(serviceBase + 'api/CustomerPolicy').then(function (results) {
            return results;
        });
    };

    var _getCustomerPolicy = function (id){
        return $http.get(serviceBase + 'api/CustomerPolicy/' + id).then(function (results) {
            return results;
        });
    }

    var _getCustomers = function (){
        return $http.get(serviceBase + 'api/Customer/').then(function (results) {
            return results;
        });
    }

    var _getPolicies = function (){
        return $http.get(serviceBase + 'api/policy/').then(function (results) {
            return results;
        });
    }

    var _saveCustomerPolicy = function(customerPolicyDto){
        return $http.post(serviceBase + 'api/CustomerPolicy', customerPolicyDto).then(function (results) {
          return results;
        });
    }

    var _getCustomer = function(id){
        return $http.get(serviceBase + 'api/Customer/' + id).then(function (results) {
            return results;
        });
    }

    var _getClients = function(){
        return $http.get(serviceBase + 'api/Client/').then(function (results) {
            return results;
        });
    }

    var _getClient = function(id){
        return $http.get(serviceBase + 'api/Client/' + id).then(function (results) {
            return results;
        });
    }

    var _saveClient = function(client){
        return $http.post(serviceBase + 'api/Client', client).then(function (results) {
          return results;
        });
    }


    var _saveCustomer = function(customerDto){
        return $http.post(serviceBase + 'api/Customer', customerDto).then(function (results) {
          return results;
        });
    }


    policiesServiceFactory.saveCustomerPolicy = _saveCustomerPolicy;
    policiesServiceFactory.getCustomerPolicies = _getCustomerPolicies;
    policiesServiceFactory.getCustomerPolicy = _getCustomerPolicy;

    policiesServiceFactory.getCustomers = _getCustomers;
    policiesServiceFactory.getCustomer = _getCustomer;
    policiesServiceFactory.saveCustomer = _saveCustomer;

    policiesServiceFactory.getClients = _getClients;
    policiesServiceFactory.getClient = _getClient;
    policiesServiceFactory.saveClient = _saveClient;

    policiesServiceFactory.getPolicies = _getPolicies;


    return policiesServiceFactory;

}]);