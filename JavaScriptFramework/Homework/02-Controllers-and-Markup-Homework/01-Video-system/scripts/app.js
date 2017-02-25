define(['angularAMD', 'angularRouter'], function (angularAMD) {

    var app = angular.module('app', ['ngRoute']);

    app.config(function ($routeProvider) {
        $routeProvider
            .when('/', angularAMD.route({
                templateUrl: 'templates/home-view.html',
                controller: 'HomeCtrl',
                controllerUrl: 'controllers/home-controller'
            }))
            .when('/videos', angularAMD.route({
                templateUrl: 'templates/video-view.html',
                controller: 'VideoCtrl',
                controllerUrl: 'controllers/video-controller'
            }))
            .otherwise({redirectTo: "/"});
    });

    return angularAMD.bootstrap(app);
});