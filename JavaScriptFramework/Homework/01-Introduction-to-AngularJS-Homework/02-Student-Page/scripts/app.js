define(['angularAMD', 'angularRouter'], function (angularAMD) {

    var app = angular.module('app', ['ngRoute']);

    app.config(function ($routeProvider) {
        $routeProvider
            .when('/', angularAMD.route({
                templateUrl: 'templates/home-view.html',
                controller: 'HomeCtrl',
                controllerUrl: 'controllers/home-controller'
            }))
            .when('/students', angularAMD.route({
                templateUrl: 'templates/student-view.html',
                controller: 'StudentsCtrl',
                controllerUrl: 'controllers/student-controller'
            }))
            .otherwise({redirectTo: "/"});
    });

    return angularAMD.bootstrap(app);
});