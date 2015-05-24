define(['app', 'constants', 'HeaderController', 'userService', 'profileService', 'navigationService'],
    function (app) {
        app.controller('FriendsController', function ($scope, constants, userService, profileService, navigationService) {
            $scope.isLoggedIn = userService.isLoggedIn();
            $scope.myData = profileService.loadMyData();
            $scope.title = $scope.myData.name +  ' - Friends';
            $scope.friendsData = [];

            //todo get user friends
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
