define(['app', 'validationService', 'authenticationService', 'userService', 'ngFacePictureSelect', 'ngCoverPictureSelect'],
    function (app) {
        app.controller('UserController', function ($scope, validationService, authenticationService, userService) {
            $scope.title = "Edit settings";
            $scope.changePasswordData = {};
            $scope.editProfileFormData = {};
            $scope.editProfilePicturesData = {};
            $scope.isLoggedIn = authenticationService.isLoggedIn();

            $scope.changePassword = function () {
                var changePasswordData = $scope.changePasswordData;
                if (validationService.validateChangePasswordForm(changePasswordData.newPassword, changePasswordData.confirmPassword)) {
                    changePasswordData = validationService.escapeHtmlSpecialChars(changePasswordData);
                    userService.ChangePassword(changePasswordData);
                }
            };

            $scope.editProfile = function () {
                var editProfileFormData = $scope.editProfileFormData;
                if (validationService.validateEditProfileForm(editProfileFormData.username, editProfileFormData.email)) {
                    editProfileFormData = validationService.escapeHtmlSpecialChars(editProfileFormData);
                    for (var picture in $scope.editProfilePicturesData) {
                        if ($scope.editProfilePicturesData.hasOwnProperty(picture)) {
                            editProfileFormData[picture] = $scope.editProfilePicturesData[picture];
                        }
                    }
                    //userService.EditProfile(editProfileFormData);
                }
            };
            
            $scope.logout = function () {
                userService.Logout();
            };
        })
    }
);
