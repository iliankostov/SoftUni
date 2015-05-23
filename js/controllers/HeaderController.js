define(['app', 'constants', 'userService', 'profileService', 'navigationService', 'notifyService'],
    function (app) {
        app.controller('HeaderController', function ($scope, constants, userService, profileService,
                                                     navigationService, notifyService) {
            $scope.isLoggedIn = userService.isLoggedIn();
            $scope.friendRequestsData = {};
            $scope.friendRequestsData.expanded = false;

            profileService.getFriendRequests().then(
                function (serverData) {
                    $scope.friendRequestsData = serverData;
                    $scope.friendRequestsData.forEach(function (request) {
                        if (!request.user.profileImageData) {
                            request.user.profileImageData = constants.baseProfilePicture;
                        }
                    })
                }
            );

            $scope.expandFriendRequests = function () {
                $scope.friendRequestsData.expanded = !$scope.friendRequestsData.expanded;
            };

            $scope.acceptFriendRequest = function (requestId) {
                console.log('accepted' + requestId);
            };

            $scope.rejectFriendRequest = function (requestId) {
                console.log('rejected' + requestId);
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
        })
    }
);
