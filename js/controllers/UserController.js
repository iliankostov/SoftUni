define(['app', 'constants', 'HeaderController', 'userService', 'profileService',
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
                        $scope.userData = serverData;
                        if (!$scope.userData.profileImageData) {
                            $scope.userData.profileImageData = constants.baseProfilePicture;
                        }
                        if (!$scope.userData.coverImageData) {
                            $scope.userData.coverImageData = constants.baseCoverPicture;
                        }
                        $scope.title = $scope.userData.name;
                    },
                    function (serverError) {
                        console.error(serverError);
                    }
                );
            };

            $scope.createPost = function () {
                var postData = $scope.postData;
                postData.username = $scope.userData.username;
                postService.createPost(postData).then(
                    function (serverData) {
                        $scope.feedData.unshift(serverData);
                        $scope.postData.postContent = '';
                    },
                    function (serverError) {
                        console.log(serverError);
                    }
                );
            };

            profileService.getOwnFriends().then(
                function (serverData) {
                    $scope.friendsData = serverData;
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
