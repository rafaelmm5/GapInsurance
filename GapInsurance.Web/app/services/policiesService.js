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

    policiesServiceFactory.getCustomerPolicies = _getCustomerPolicies;
    policiesServiceFactory.getCustomerPolicy = _getCustomerPolicy;

    return policiesServiceFactory;

}]);