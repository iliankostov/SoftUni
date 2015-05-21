define(['app', 'validationService', 'authenticationService', 'userService'],
    function (app) {
        app.controller('HomeController', function ($scope, validationService, authenticationService, userService) {
            $scope.title = "Welcome to iBook";
            $scope.changePasswordData = {};
            $scope.isLoggedIn = authenticationService.isLoggedIn();

            if ($scope.isLoggedIn) {
                $scope.title = "News Feed";
            }

            userService.GetUser().then(
                function (serverData) {
                    $scope.userData = serverData;
                },
                function (serverError) {
                    $scope.userData = {};
                    console.error(serverError);
                }
            );

            $scope.logout = function () {
                userService.Logout();
            };
        })
    }
);
