define(['app', 'constants', 'validationService', 'authenticationService', 'navigationService', 'userService'],
    function (app) {
        app.controller('WallController', function ($scope, $location, validationService, authenticationService,
                                                   navigationService, userService) {
            $scope.isLoggedIn = authenticationService.isLoggedIn();
            $scope.userData = userService.loadUserData();
            $scope.title = $scope.userData.name + ' - Wall';

            //TODO: load wall

            $scope.logout = function () {
                userService.Logout();
            };

            $scope.cancel = function () {
                navigationService.loadHome();
            };
        })
    }
);
