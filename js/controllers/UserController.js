define(['app', 'validationService', 'authenticationService', 'userService', 'ngFileSelect'], function (app) {
    app.controller('UserController', function ($scope, validationService, authenticationService, userService,
                                               baseFacePicture, baseCoverPicture) {
        $scope.title = "Edit settings";
        $scope.changePasswordData = {};
        $scope.editProfileData = {};
        $scope.editProfileData.facePicture = baseFacePicture;
        $scope.editProfileData.coverPicture = baseCoverPicture;
        $scope.isLoggedIn = authenticationService.isLoggedIn();

        $scope.changePassword = function () {
            var changePasswordData = $scope.changePasswordData;
            if (validationService.ValidateChangePasswordForm(changePasswordData.newPassword, changePasswordData.confirmPassword)) {
                changePasswordData = validationService.EscapeHtmlSpecialChars(changePasswordData);
                userService.ChangePassword(changePasswordData);
            }
        };

        $scope.logout = function () {
            userService.Logout();
        };
    })
});
