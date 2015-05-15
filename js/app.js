define(['angularAMD', 'angularRouter'], function (angularAMD) {

    var app = angular.module('app', ['ngRoute']);

    app.constant('baseServiceUrl', 'http://softuni-social-network.azurewebsites.net/api');

    app.config(function ($routeProvider) {
        $routeProvider
            .when('/', angularAMD.route({
                templateUrl: 'templates/home-view.html',
                controller: 'MainController',
                controllerUrl: 'controllers/MainController'
            }))
            .when('/login', angularAMD.route({
                templateUrl: 'templates/login-view.html',
                controller: 'MainController',
                controllerUrl: 'controllers/MainController'
            }))
            .when('/signup', angularAMD.route({
                templateUrl: 'templates/signup-view.html',
                controller: 'MainController',
                controllerUrl: 'controllers/MainController'
            }))
            .when('/ilian', angularAMD.route({
                templateUrl: 'templates/wall-view.html',
                controller: 'MainController',
                controllerUrl: 'controllers/MainController'
            }))
            .otherwise({redirectTo: "/"});
    });

    return angularAMD.bootstrap(app);
});
