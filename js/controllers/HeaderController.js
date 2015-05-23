define(['app', 'userService', 'profileService', 'notifyService'],
    function (app) {
        app.controller('HeaderController', function ($scope, userService) {
            $scope.isLoggedIn = userService.isLoggedIn();

            $scope.logout = function () {
                userService.Logout();
            };
        })
    }
);
