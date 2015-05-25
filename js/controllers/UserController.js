define(['app', 'constants', 'HeaderController', 'userService', 'profileService', 'postService',
        'navigationService', 'notifyService', 'ngInfiniteScroll'],
    function (app) {
        app.controller('UserController', function ($scope, $routeParams, constants, userService, profileService,
                                                   postService, navigationService, notifyService) {
            var wallFeedStartPost;
            $scope.wallFeedBusy = false;
            $scope.isLoggedIn = userService.isLoggedIn();
            $scope.myData = profileService.loadMyData();
            $scope.postData = {};
            $scope.userData = {};
            $scope.userData.username = $routeParams.username;
            $scope.friendsData = [];
            $scope.feedData = [];


            userService.loadUserFullData($scope.userData.username).then(
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

            $scope.sendFriendRequest = function () {
                var username = $scope.userData.username;
                profileService.sendFriendRequest(username).then(
                    function (serverData) {
                        notifyService.showInfo(serverData.message);
                    },
                    function (serverError) {
                        notifyService.showError("Cannot send friend request.", serverError);
                    }
                )
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

            $scope.getUserFriendsPreview = function () {
                userService.getUserFriendsPreview($scope.userData.username).then(
                    function (serverData) {
                        serverData.friends.forEach(function (friend) {
                            if (!friend.profileImageData) {
                                friend.profileImageData = constants.baseProfilePicture;
                            }
                        });
                        $scope.friendsData = serverData.friends;
                        $scope.friendsDataTotalCount = serverData.totalCount;
                    },
                    function (serverError) {
                        console.error(serverError);
                    }
                );
            };

            $scope.getUserFriends = function () {
                userService.getUserFriends($scope.userData.username).then(
                    function (serverData) {
                        serverData.forEach(function (friend) {
                            if (!friend.profileImageData) {
                                friend.profileImageData = constants.baseProfilePicture;
                            }
                        });
                        $scope.friendsData = serverData;
                        $scope.friendsDataTotalCount = serverData.length;
                    },
                    function (serverError) {
                        console.error(serverError);
                    }
                );
            };

            $scope.getMyFriendsPreview = function () {
                profileService.getMyFriendsPreview().then(
                    function (serverData) {
                        serverData.friends.forEach(function (friend) {
                            if (!friend.profileImageData) {
                                friend.profileImageData = constants.baseProfilePicture;
                            }
                        });
                        $scope.friendsData = serverData.friends;
                        $scope.friendsDataTotalCount = serverData.totalCount;
                    },
                    function (serverError) {
                        console.error(serverError);
                    }
                );
            };

            $scope.getMyFriends = function () {
                profileService.getMyFriends().then(
                    function (serverData) {
                        serverData.forEach(function (friend) {
                            if (!friend.profileImageData) {
                                friend.profileImageData = constants.baseProfilePicture;
                            }
                        });
                        $scope.friendsData = serverData;
                        $scope.friendsDataTotalCount = serverData.length;
                    },
                    function (serverError) {
                        console.error(serverError);
                    }
                );
            };

            $scope.loadFriendsPreview = function () {
                if ($scope.userData.username != $scope.myData.username) {
                    $scope.getUserFriendsPreview();
                } else {
                    $scope.getMyFriendsPreview();
                }
            };

            $scope.loadFriends = function () {
                if ($scope.userData.username != $scope.myData.username) {
                    $scope.getUserFriends();
                } else {
                    $scope.getMyFriends();
                }
            };

            $scope.loadWallFeed = function () {
                if ($scope.isLoggedIn) {
                    if ($scope.wallFeedBusy) {
                        return;
                    }
                    $scope.wallFeedBusy = true;

                    userService.loadWallFeed($scope.userData.username, wallFeedStartPost).then(
                        function (serverData) {
                            serverData.forEach(function (post) {
                                if (!post.author.profileImageData) {
                                    post.author.profileImageData = constants.baseProfilePicture;
                                }
                            });
                            $scope.feedData = $scope.feedData.concat(serverData);
                            if ($scope.feedData.length > 0) {
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
