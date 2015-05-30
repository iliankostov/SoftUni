define(['app', 'constants', 'HeaderController', 'PostController', 'CommentController', 'validationService', 'userService', 'profileService', 'ngInfiniteScroll'],
    function (app) {
        app.controller('HomeController', function ($scope, $rootScope, constants, validationService, userService, profileService) {
            var newsFeedStartPost;
            $scope.isLoggedIn = userService.isLoggedIn();
            $scope.myData = profileService.loadMyData();
            $scope.newsFeedBusy = false;
            $scope.friendsData = [];
            $scope.feedData = [];
            if ($scope.isLoggedIn) {
                $scope.title = 'News Feed';
            } else {
                $scope.title = "Welcome to iBook";
            }

            $rootScope.$on('myDataUpdate', function () {
                $rootScope.myDataUpdate = true;
            });

            if ($rootScope.myDataUpdate) {
                profileService.getMe().then(
                    function (data) {
                        profileService.saveMyData(data);
                        $rootScope.myDataUpdate = false;
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

            $scope.loadFriendsPreview = function () {
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

            $scope.loadNewsFeed = function () {
                if ($scope.isLoggedIn) {
                    if ($scope.newsFeedBusy){
                        return;
                    }
                    $scope.newsFeedBusy = true;

                    profileService.loadNewsFeed(newsFeedStartPost).then(
                        function (serverData) {
                            serverData.forEach(function (post) {
                                if (!post.author.profileImageData) {
                                    post.author.profileImageData = constants.baseProfilePicture;
                                }
                                post.postContent = validationService.escapeHtmlSpecialChars(post.postContent, true);
                            });
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
