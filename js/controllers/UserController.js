define(['app', 'HeaderController', 'userService', 'profileService', 'postService', 'navigationService',
        'ngCoverBackground', 'ngInfiniteScroll'],
    function (app) {
        app.controller('UserController', function ($scope, userService, profileService, postService, navigationService) {
            var wallFeedStartPost;
            $scope.isLoggedIn = userService.isLoggedIn();
            $scope.userData = profileService.loadUserData();
            $scope.title = $scope.userData.name + ' - Wall';
            $scope.wallFeedBusy = false;
            $scope.feedData = [];
            $scope.postData = {};

            $scope.createPost = function () {
                var postData = $scope.postData;
                postData.username = $scope.userData.username;
                postService.createPost(postData).then(
                    function (serverData) {
                        console.log(serverData);
                        $scope.postData.postContent = '';
                    },
                    function (serverError) {
                        console.log(serverError);
                    }
                );
            };

            $scope.loadWallFeed = function () {
                if ($scope.isLoggedIn) {
                    if ($scope.wallFeedBusy){
                        return;
                    }
                    $scope.wallFeedBusy = true;

                    userService.loadWallFeed($scope.userData.username, wallFeedStartPost).then(
                        function (serverData) {
                            $scope.feedData = $scope.feedData.concat(serverData);
                            if($scope.feedData.length > 0){
                                wallFeedStartPost = $scope.feedData[$scope.feedData.length - 1].id;
                                $scope.wallFeedBusy = false;
                            }
                        },
                        function (serverError) {
                            console.error(serverError);
                        }
                    );
                }
            };

            $scope.cancel = function () {
                navigationService.loadHome();
            };
        })
    }
);
