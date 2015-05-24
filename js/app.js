define(['angularAMD', 'angularRouter'], function (angularAMD) {

    var app = angular.module('app', ['ngRoute']);

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
            .when('/:username', angularAMD.route({
                templateUrl: 'templates/user/user-view.html',
                controller: 'UserController',
                controllerUrl: 'controllers/UserController'
            }))
            .when('/friends', angularAMD.route({
                templateUrl: 'templates/user/friends-view.html',
                controller: 'FriendsController'
                // todo replace friends controller with user controller and DI it in the view
                //controllerUrl: 'controllers/FriendsController'
            }))
            .when('/edit/password', angularAMD.route({
                templateUrl: 'templates/user/change-password-view.html',
                controller: 'SettingsController',
                controllerUrl: 'controllers/SettingsController'
            }))
            .when('/edit/profile', angularAMD.route({
                templateUrl: 'templates/user/edit-profile-view.html',
                controller: 'SettingsController',
                controllerUrl: 'controllers/SettingsController'
            }))
            .otherwise({redirectTo: "/"});
    });

    return angularAMD.bootstrap(app);
});
