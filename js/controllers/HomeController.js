define(['app', 'userService', 'profileService'],
    function (app) {
        app.controller('HomeController', function ($scope, $rootScope, userService, profileService) {
            $scope.isLoggedIn = userService.isLoggedIn();
            $scope.feedsData = {};

            if ($scope.isLoggedIn) {
                profileService.loadFeeds().then(
                    function (serverData) {
                        $scope.feedsData = serverData;
                    },
                    function (serverError) {
                        console.error(serverError);
                    }
                );
            }

            $scope.logout = function () {
                userService.Logout();
            };

            $rootScope.$on('userDataUpdate', function () {
                $rootScope.userDataUpdate = true;
            });

            if ($rootScope.userDataUpdate) {
                profileService.GetUser().then(
                    function (data) {
                        profileService.saveUserData(data);
                        $rootScope.userDataUpdate = false;
                        $scope.userData = profileService.loadUserData();
                        setTitle();
                    },
                    function (error) {
                        console.error(error);
                    });
            } else {
                $scope.userData = profileService.loadUserData();
                setTitle();
            }

            function setTitle() {
                if ($scope.isLoggedIn) {
                    $scope.title = $scope.userData.name + ' - News Feed';
                } else {
                    $scope.title = "Welcome to iBook";
                }
            }
        })
    }
);
