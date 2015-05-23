define(['app', 'constants', 'HeaderController', 'FriendsController', 'userService', 'profileService',
        'ngInfiniteScroll'],
    function (app) {
        app.controller('HomeController', function ($scope, $rootScope, constants, userService, profileService) {
            var newsFeedStartPost;
            $scope.isLoggedIn = userService.isLoggedIn();
            $scope.myData = profileService.loadMyData();
            $scope.newsFeedBusy = false;
            $scope.feedData = [];
            if ($scope.isLoggedIn) {
                $scope.title = $scope.myData.name + ' - News Feed';
            } else {
                $scope.title = "Welcome to iBook";
            }

            $rootScope.$on('userDataUpdate', function () {
                $rootScope.userDataUpdate = true;
            });

            if ($rootScope.userDataUpdate) {
                profileService.getUser().then(
                    function (data) {
                        profileService.saveMyData(data);
                        $rootScope.userDataUpdate = false;
                        $scope.myData = profileService.loadMyData();
                    },
                    function (error) {
                        console.error(error);
                    });
            } else {
                $scope.myData = profileService.loadMyData();
            }

            $scope.loadNewsFeed = function () {
                if ($scope.isLoggedIn) {
                    if ($scope.newsFeedBusy){
                        return;
                    }
                    $scope.newsFeedBusy = true;

                    profileService.loadNewsFeed(newsFeedStartPost).then(
                        function (serverData) {
                            $scope.feedData = $scope.feedData.concat(serverData);
                            if($scope.feedData.length > 0){
                                newsFeedStartPost = $scope.feedData[$scope.feedData.length - 1].id;
                                $scope.newsFeedBusy = false;
                            }
                        },
                        function (serverError) {
                            console.error(serverError);
                        }
                    );
                }
            };
        })
    }
);
