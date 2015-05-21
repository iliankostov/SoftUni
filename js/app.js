define(['angularAMD', 'angularRouter'], function (angularAMD) {

    var app = angular.module('app', ['ngRoute']);

    app.constant('baseServiceUrl', 'http://softuni-social-network.azurewebsites.net/api');

    app.config(function ($routeProvider) {
        $routeProvider
            .when('/', angularAMD.route({
                templateUrl: 'templates/home-view.html',
                controller: 'HomeController',
                controllerUrl: 'controllers/HomeController'
            }))
            .when('/login', angularAMD.route({
                templateUrl: 'templates/login-view.html',
                controller: 'LoginController',
                controllerUrl: 'controllers/LoginController'
            }))
            .when('/signup', angularAMD.route({
                templateUrl: 'templates/signup-view.html',
                controller: 'SignupController',
                controllerUrl: 'controllers/SignupController'
            }))
            .when('/wall', angularAMD.route({
                templateUrl: 'templates/user/wall-view.html',
                controller: 'UserController',
                controllerUrl: 'controllers/UserController'
            }))
            .when('/edit/password', angularAMD.route({
                templateUrl: 'templates/user/change-password-view.html',
                controller: 'UserController',
                controllerUrl: 'controllers/UserController'
            }))
            .when('/edit/profile', angularAMD.route({
                templateUrl: 'templates/user/edit-profile-view.html',
                controller: 'UserController',
                controllerUrl: 'controllers/UserController'
            }))
            .otherwise({redirectTo: "/"});
    });

    return angularAMD.bootstrap(app);
});
