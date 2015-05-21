define(['app', 'constants', 'validationService', 'authenticationService', 'userService'],
    function (app) {
        app.controller('HomeController', function ($scope, $rootScope, constants, validationService, authenticationService, userService) {
            $scope.title = "Welcome to iBook";
            $scope.isLoggedIn = authenticationService.isLoggedIn();

            if ($scope.isLoggedIn) {
                $scope.title = "News Feed";
            }

            $rootScope.$on('userDataUpdate', function () {
                $rootScope.userDataUpdate = true;
            });

            if ($rootScope.userDataUpdate) {
                userService.GetUser().then(
                    function (data) {
                        setUserData(data);
                        $rootScope.userDataUpdate = false;
                        $scope.userData = getUserData();
                    },
                    function (error) {

                        // TODO
                        console.log(error);
                    });
            } else {
                $scope.userData = getUserData();
            }

            $scope.logout = function () {
                userService.Logout();
            };

            function setUserData(data) {
                for (var d in data) {
                    if (data.hasOwnProperty(d)) {
                        if (d == 'profileImageData') {
                            sessionStorage[d] = data[d] || constants.baseProfilePicture;
                        } else if (d == 'coverImageData') {
                            sessionStorage[d] = data[d] || constants.baseCoverPicture;
                        } else {
                            sessionStorage[d] = data[d];
                        }
                    }
                }
            }

            function getUserData() {
                var data = {};
                for (var d in sessionStorage) {
                    if (sessionStorage.hasOwnProperty(d)) {
                        data[d] = sessionStorage[d];
                    }
                }
                return data;
            }
        })
    }
);
