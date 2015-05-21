define(['app', 'validationService', 'authenticationService', 'userService', 'ngFacePictureSelect', 'ngCoverPictureSelect'],
    function (app) {
        app.controller('UserController', function ($scope, validationService, authenticationService, userService) {
            $scope.title = "Edit settings";
            $scope.changePasswordData = {};
            $scope.isLoggedIn = authenticationService.isLoggedIn();

            userService.GetUser().then(
                function (serverData) {
                    $scope.userData = serverData;
                },
                function (serverError) {
                    $scope.userData = {};
                    console.error(serverError);
                }
            );

            $scope.changePassword = function () {
                var changePasswordData = $scope.changePasswordData;
                if (validationService.validateChangePasswordForm(changePasswordData.newPassword, changePasswordData.confirmPassword)) {
                    changePasswordData = validationService.escapeHtmlSpecialChars(changePasswordData);
                    userService.ChangePassword(changePasswordData);
                }
            };

            $scope.editProfile = function () {
                var userData = $scope.userData;
                if (validationService.validateEditProfileForm(userData.email)) {
                    userData = validationService.escapeHtmlSpecialChars(userData);
                    userService.EditProfile(userData);
                }
            };
            
            $scope.logout = function () {
                userService.Logout();
            };
        })
    }
);
