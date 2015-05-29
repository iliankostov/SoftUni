define(['app', 'constants', 'userService', 'profileService', 'navigationService', 'notifyService'],
    function (app) {
        app.controller('HeaderController', function ($scope, $timeout, constants, userService, profileService,
                                                     navigationService, notifyService) {
            $scope.isLoggedIn = userService.isLoggedIn();
            $scope.friendRequestsData = {};
            $scope.friendRequestsDataExpanded = false;

            profileService.getFriendRequests().then(
                function (serverData) {
                    serverData.forEach(function (request) {
                        if (!request.user.profileImageData) {
                            request.user.profileImageData = constants.baseProfilePicture;
                        }
                    });
                    $scope.friendRequestsData = serverData;
                }
            );

            $scope.expandFriendRequests = function () {
                $scope.friendRequestsDataExpanded = !$scope.friendRequestsDataExpanded;
            };

            $scope.acceptFriendRequest = function (requestId) {
                profileService.acceptFriendRequest(requestId).then(
                    function (serverData) {
                        notifyService.showInfo(serverData.message);
                        $scope.expandFriendRequests();
                    },
                    function (serverError) {
                        notifyService.showError("Cannot accept friend request.", serverError)
                    }
                )
            };

            $scope.rejectFriendRequest = function (requestId) {
                profileService.rejectFriendRequest(requestId).then(
                    function (serverData) {
                        notifyService.showInfo(serverData.message);
                        $scope.expandFriendRequests();
                    },
                    function (serverError) {
                        notifyService.showError("Cannot reject friend request.", serverError)
                    }
                )
            };

            $scope.logout = function () {
                userService.logout().then(
                    function (serverResponse) {
                        notifyService.showInfo(serverResponse.message);
                        userService.clearCredentials();
                        navigationService.loadHome(true);
                    },
                    function (serverError) {
                        notifyService.showError("Unsuccessful Logout!", serverError);
                    }
                )
            };

            $scope.searchUsersByName = function (searchDataWord) {
                if (searchDataWord !== '') {
                    userService.searchUsersByName(searchDataWord).then(
                        function (serverData) {
                            $scope.searchResults = serverData;
                            $scope.searchResults.forEach(function (user) {
                                if (!user.profileImageData) {
                                    user.profileImageData = constants.baseProfilePicture;
                                }
                            });
                        },
                        function (serverError) {
                            console.error(serverError);
                        }
                    );
                }
            };

            $scope.clearDropDown = function(){
                $timeout(function() {
                    $scope.searchResults = null;
                    $scope.searchDataWord = '';
                }, 250);
            };
        })
    }
);
