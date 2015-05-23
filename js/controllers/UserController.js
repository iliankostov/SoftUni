define(['app', 'constants', 'HeaderController', 'FriendsController', 'userService', 'profileService',
        'postService', 'navigationService',
        'ngCoverBackground', 'ngInfiniteScroll'],
    function (app) {
        app.controller('UserController', function ($scope, $routeParams, constants, userService, profileService,
                                                   postService, navigationService) {
            var wallFeedStartPost;
            $scope.wallFeedBusy = false;
            $scope.isLoggedIn = userService.isLoggedIn();
            $scope.myData = profileService.loadMyData();
            $scope.userData = {};
            $scope.feedData = [];
            $scope.postData = {};


            $scope.loadUserFullData = function () {
                var username = $routeParams.username;
                userService.loadUserFullData(username).then(
                    function (serverData) {
                        // todo check if user has pictures
                        console.log(serverData);
                        $scope.userData = serverData;
                        $scope.title = $scope.userData.name + ' - Wall';
                    },
                    function (serverError) {
                        console.error(serverError);
                    }
                );
            };

            $scope.createPost = function () {
                var postData = $scope.postData;
                postData.username = $scope.myData.username;
                postService.createPost(postData).then(
                    function (serverData) {
                        // todo check server data for message
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
