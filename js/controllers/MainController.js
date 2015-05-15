define(['app'], function (app) {
    app.controller('MainController', function ($scope, $location) {
        $scope.cancel = function () {
            $location.path('/');
        };
    });
});
