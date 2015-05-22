define(['app', 'userService', 'profileService', 'ngInfiniteScroll'],
    function (app) {
        app.controller('HomeController', function ($scope, $rootScope, userService, profileService) {
            var newsFeedStartPost;
            $scope.isLoggedIn = userService.isLoggedIn();
            $scope.newsFeedBusy = false;
            $scope.feedsData = [];

            $scope.loadFeeds = function () {
                if ($scope.isLoggedIn) {
                    if ($scope.newsFeedBusy){
                        return;
                    }
                    $scope.newsFeedBusy = true;

                    profileService.loadFeeds(newsFeedStartPost).then(
                        function (serverData) {
                            console.log(serverData);
                            $scope.feedsData = $scope.feedsData.concat(serverData);
                            if($scope.feedsData.length > 0){
                                newsFeedStartPost = $scope.feedsData[$scope.feedsData.length - 1].id;
                                $scope.newsFeedBusy = false;
                            }
                        },
                        function (serverError) {
                            console.error(serverError);
                        }
                    );
                }
            };

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
