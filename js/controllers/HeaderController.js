define(['app', 'userService', 'navigationService', 'notifyService'],
    function (app) {
        app.controller('HeaderController', function ($scope, userService, navigationService, notifyService) {
            $scope.isLoggedIn = userService.isLoggedIn();

            $scope.logout = function () {
                userService.logout().then(
                    function (serverResponse) {
                        notifyService.showInfo(serverResponse.message);
                        userService.clearCredentials();
                        navigationService.loadHome(true);
                    },
                    function (serverError) {
                        notifyService.showError("Unsuccessful Logout!", serverError);
                    }
                )
            };
        })
    }
);
