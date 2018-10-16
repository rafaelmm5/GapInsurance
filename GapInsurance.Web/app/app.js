var app = angular.module('GapInsuranceApp', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar']);

app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/app/views/home.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/app/views/login.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "/app/views/signup.html"
    });

    $routeProvider.when("/policies", {
        controller: "policiesController",
        templateUrl: "/app/views/policies.html"
    });

    $routeProvider.when("/policies/add", {
        controller: "policiesController",
        templateUrl: "/app/views/policy-edit.html"
    });

    $routeProvider.when("/policies/:id", {
        controller: "policiesController",
        templateUrl: "/app/views/policy-edit.html"
    });

    $routeProvider.when("/customers", {
        controller: "customersController",
        templateUrl: "/app/views/customers.html"
    });

    $routeProvider.when("/customers/add", {
        controller: "customersController",
        templateUrl: "/app/views/customers-edit.html"
    });

    $routeProvider.when("/customers/:id", {
        controller: "customersController",
        templateUrl: "/app/views/customers-edit.html"
    });

    
    $routeProvider.when("/clients", {
        controller: "clientsController",
        templateUrl: "/app/views/clients.html"
    });

    $routeProvider.when("/clients/add", {
        controller: "clientsController",
        templateUrl: "/app/views/clients-edit.html"
    });

    $routeProvider.when("/clients/:id", {
        controller: "clientsController",
        templateUrl: "/app/views/clients-edit.html"
    });

    $routeProvider.otherwise({ redirectTo: "/home" });
});


var serviceBase = 'http://localhost:29247/';
app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngAuthApp'
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);