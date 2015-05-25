define(['app', 'constants', 'HeaderController', 'userService', 'profileService',
        'ngInfiniteScroll'],
    function (app) {
        app.controller('HomeController', function ($scope, $rootScope, constants, userService, profileService) {
            var newsFeedStartPost;
            $scope.isLoggedIn = userService.isLoggedIn();
            $scope.myData = profileService.loadMyData();
            $scope.newsFeedBusy = false;
            $scope.friendsData = [];
            $scope.feedData = [];
            if ($scope.isLoggedIn) {
                $scope.title = 'News Feed';
                profileService.getMyFriendsPreview().then(
                    function (serverData) {
                        $scope.friendsData = serverData.friends;
                        $scope.friendsData.totalCount = serverData.totalCount;
                        $scope.friendsData.forEach(function (friend) {
                            if (!friend.profileImageData) {
                                friend.profileImageData = constants.baseProfilePicture;
                            }
                        })

                    },
                    function (serverError) {
                        console.error(serverError);
                    }
                );
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
                        $scope.title = $scope.myData.name + ' - ' + $scope.title;
                    },
                    function (error) {
                        console.error(error);
                    });
            } else {
                $scope.myData = profileService.loadMyData();
                if ($scope.isLoggedIn) {
                    $scope.title = $scope.myData.name + ' - ' + $scope.title;
                }
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
