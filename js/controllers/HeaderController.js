define(['app', 'userService', 'profileService', 'notifyService'],
    function (app) {
        app.controller('HeaderController', function ($scope, $rootScope, userService, profileService) {
            $scope.isLoggedIn = userService.isLoggedIn();

            $rootScope.$on('userDataUpdate', function () {
                $rootScope.userDataUpdate = true;
            });

            if ($rootScope.userDataUpdate) {
                profileService.GetUser().then(
                    function (data) {
                        profileService.saveUserData(data);
                        $rootScope.userDataUpdate = false;
                        $scope.userData = profileService.loadUserData();
                    },
                    function (error) {
                        console.error(error);
                    });
            } else {
                $scope.userData = profileService.loadUserData();
            }

            $scope.logout = function () {
                userService.Logout();
            };
        })
    }
);
