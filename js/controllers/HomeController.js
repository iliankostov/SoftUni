define(['app', 'constants', 'validationService', 'authenticationService', 'userService'],
    function (app) {
        app.controller('HomeController', function ($scope, $rootScope, constants, validationService,
                                                   authenticationService, userService) {
            $scope.title = "Welcome to iBook";
            $scope.isLoggedIn = authenticationService.isLoggedIn();

            $rootScope.$on('userDataUpdate', function () {
                $rootScope.userDataUpdate = true;
            });

            if ($rootScope.userDataUpdate) {
                userService.GetUser().then(
                    function (data) {
                        userService.saveUserData(data);
                        $rootScope.userDataUpdate = false;
                        $scope.userData = userService.loadUserData();
                        setTitle();
                    },
                    function (error) {
                        console.error(error);
                    });
            } else {
                $scope.userData = userService.loadUserData();
                setTitle();
            }

            $scope.logout = function () {
                userService.Logout();
            };

            function setTitle() {
                $scope.title = $scope.userData.name + ' - News Feed';
            }
        })
    }
);
