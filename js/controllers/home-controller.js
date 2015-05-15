define(['app'], function (app) {
    app.controller('HomeController', function ($scope, $location) {
        $scope.cancel = function() {
            $location.path('/');
        };
    });
});
