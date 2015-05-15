define(['angularAMD', 'angularRouter'], function (angularAMD) {

    var app = angular.module('app', ['ngRoute']);

    app.config(function ($routeProvider) {
        $routeProvider
            .when('/', angularAMD.route({
                templateUrl: 'templates/home-view.html',
                controller: 'HomeController',
                controllerUrl: 'controllers/home-controller'
            }))
            .when('/login', angularAMD.route({
                templateUrl: 'templates/login-view.html',
                controller: 'HomeController',
                controllerUrl: 'controllers/home-controller'
            }))
            .when('/signup', angularAMD.route({
                templateUrl: 'templates/signup-view.html',
                controller: 'HomeController',
                controllerUrl: 'controllers/home-controller'
            }))
            .otherwise({redirectTo: "/"});
    });

    return angularAMD.bootstrap(app);
});
