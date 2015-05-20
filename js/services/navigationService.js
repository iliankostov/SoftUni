define(['app'], function (app) {
    app.factory('navigationService', function ($location, $route) {
        var service = {};

        service.loadHome = function (routeReload) {
            $location.path('/');
            if (routeReload) {
                $route.reload();
            }
        };

        return service;
    })
});
