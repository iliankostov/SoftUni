define(['app', 'authentication', 'notifyService'], function (app) {
    app.controller('MainController', function ($scope, $location, $route, authentication, notifyService) {

        var ClearData = function () {
            $scope.loginData = "";
            $scope.registerData = "";
            $scope.userData = "";
            $scope.passwordData = "";
        };

        if (!authentication.isLoggedIn()) {
            $scope.isNotLoggedIn = true;
            $scope.isLoggedIn = false;
        } else {
            $scope.isNotLoggedIn = false;
            $scope.isLoggedIn = true;
        }

        $scope.login = function () {
            authentication.Login($scope.loginData,
                function(serverData) {
                    notifyService.showInfo("Successful Login!");
                    authentication.SetCredentials(serverData);
                    ClearData();
                    $location.path('/ilian');
                },
                function (serverError) {
                    notifyService.showError("Unsuccessful Login!", serverError)
                });
        };

        $scope.register = function () {
            authentication.Register($scope.registerData,
                function(serverData) {
                    notifyService.showInfo("Successful Register!");
                    authentication.SetCredentials(serverData);
                    ClearData();
                    $location.path('/user/home');
                },
                function (serverError) {
                    notifyService.showError("Unsuccessful Register!", serverError)
                });
        };

        $scope.logout = function () {
            authentication.Logout(
                function () {
                    notifyService.showInfo("Successful Logout!");
                    ClearData();
                    authentication.ClearCredentials();
                    $location.path('/');
                },
                function (serverError) {
                    notifyService.showError("Unsuccessful Logout!", serverError)
                }
            )

        };

        $scope.cancel = function () {
            $location.path('/');
        };
    });
});
