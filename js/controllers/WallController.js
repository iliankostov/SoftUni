define(['app', 'userService', 'profileService', 'postService', 'navigationService', 'ngCoverBackground'],
    function (app) {
        app.controller('WallController', function ($scope, userService, profileService, postService, navigationService) {
            $scope.isLoggedIn = userService.isLoggedIn();
            $scope.userData = profileService.loadUserData();
            $scope.title = $scope.userData.name + ' - Wall';
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

            //TODO: get wall posts

            $scope.logout = function () {
                userService.Logout();
            };

            $scope.cancel = function () {
                navigationService.loadHome();
            };
        })
    }
);
