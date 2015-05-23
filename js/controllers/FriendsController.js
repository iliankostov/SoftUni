define(['app', 'constants', 'HeaderController', 'userService', 'profileService', 'navigationService'],
    function (app) {
        app.controller('FriendsController', function ($scope, constants, userService, profileService, navigationService) {
            $scope.isLoggedIn = userService.isLoggedIn();
            $scope.userData = profileService.loadUserData();
            $scope.title = $scope.userData.name +  ' - Friends';
            $scope.friendsData = [];

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

            $scope.cancel = function () {
                navigationService.loadHome();
            };
        })
    }
);
