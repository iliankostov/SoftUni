define(['app', 'constants', 'HeaderController', 'PostController', 'CommentController', 'userService', 'profileService', 'postService',
        'validationService', 'navigationService', 'notifyService', 'ngInfiniteScroll'],
    function (app) {
        app.controller('UserController', function ($scope, $routeParams, constants, userService, profileService,
                                                   postService, validationService, navigationService, notifyService) {
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

                    $scope.friendsSecurity = function () {
                        var isMe = $scope.userData.username === $scope.myData.username;

                        if (!$scope.isLoggedIn) {
                            return true;
                        } else {
                            return !($scope.userData.isFriend || isMe);
                        }
                    };
                },
                function (serverError) {
                    console.error(serverError);
                }
            );

            $scope.sendFriendRequest = function (username) {
                profileService.sendFriendRequest(username).then(
                    function (serverData) {
                        notifyService.showInfo(serverData.message);
                        navigationService.reload();
                    },
                    function (serverError) {
                        notifyService.showError("Cannot send friend request.", serverError);
                    }
                )
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
                                post.postContent = validationService.escapeHtmlSpecialChars(post.postContent, true);
                                post.comments.forEach(function (comment) {
                                    comment.commentContent = validationService.escapeHtmlSpecialChars(comment.commentContent, true);
                                });
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
